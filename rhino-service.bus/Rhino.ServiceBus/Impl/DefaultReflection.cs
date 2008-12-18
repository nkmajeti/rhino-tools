using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas;

namespace Rhino.ServiceBus.Impl
{
    public class DefaultReflection : IReflection
    {
        private readonly ILog logger = LogManager.GetLogger(typeof (DefaultReflection));

        private readonly IDictionary<Type, string> typeToWellKnownTypeName;
        private readonly IDictionary<string, Type> wellKnownTypeNameToType;

        public DefaultReflection()
        {
            wellKnownTypeNameToType = new Dictionary<string, Type>();
            typeToWellKnownTypeName = new Dictionary<Type, string>
            {
                {typeof (string), "string"},
                {typeof (int), "int"},
                {typeof (byte), "byte"},
                {typeof (bool), "bool"},
                {typeof (DateTime), "datetime"},
                {typeof (TimeSpan), "timespan"},
                {typeof (decimal), "decimal"},
                {typeof (float), "float"},
                {typeof (double), "double"},
                {typeof (char), "char"},
                {typeof (Guid), "guid"},
                {typeof (Uri), "uri"},
                {typeof (short), "short"},
                {typeof (long), "long"}
            };
            foreach (var pair in typeToWellKnownTypeName)
            {
                wellKnownTypeNameToType.Add(pair.Value, pair.Key);
            }
        }

        #region IReflection Members

        public object CreateInstance(Type type, params object[] args)
        {
            try
            {
                return Activator.CreateInstance(type, args);
            }
            catch (Exception e)
            {
                throw new MissingMethodException("No parameterless constructor defined for this object: " + type, e);
            }
        }

        public Type GetType(string type)
        {
            Type value;
            if (wellKnownTypeNameToType.TryGetValue(type, out value))
                return value;
            if(type.StartsWith("array_of_"))
            {
                return GetType(type.Substring("array_of_".Length));
            }
            return Type.GetType(type);
        }

        public void InvokeAdd(object instance, object item)
        {
            Type type = instance.GetType();
            MethodInfo method = type.GetMethod("Add", new[] {item.GetType()});
            method.Invoke(instance, new[] {item});
        }

        public void Set(object instance, string name, Func<Type, object> generateValue)
        {
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(name);
            if (property == null)
            {
                logger.InfoFormat("Could not find property {0} to set on {1}", name, type);
                return;
            }
            object value = generateValue(property.PropertyType);
            property.SetValue(instance, value, null);
        }

        public object Get(object instance, string name)
        {
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(name);
            if (property == null)
            {
                logger.InfoFormat("Could not find property {0} to get on {1}", name, type);
                return null;
            }
            return property.GetValue(instance, null);
        }

        public Type GetGenericTypeOf(Type type, object msg)
        {
            return GetGenericTypeOf(type, msg.GetType());
        }

        public Type GetGenericTypeOf(Type type, Type paramType)
        {
            return type.MakeGenericType(paramType);
        }

        public void InvokeConsume(object consumer, object msg)
        {
            Type type = consumer.GetType();
            MethodInfo consume = type.GetMethod("Consume", new[] {msg.GetType()});
            consume.Invoke(consumer, new[] {msg});
        }

        public object InvokeSagaPersisterGet(object persister, Guid correlationId)
        {
            Type type = persister.GetType();
            MethodInfo method = type.GetMethod("Get");
            return method.Invoke(persister, new object[] {correlationId});
        }

        public void InvokeSagaPersisterSave(object persister, ISaga entity)
        {
            Type type = persister.GetType();
            MethodInfo method = type.GetMethod("Save");
            method.Invoke(persister, new object[] {entity});
        }

        public void InvokeSagaPersisterComplete(object persister, ISaga entity)
        {
            Type type = persister.GetType();
            MethodInfo method = type.GetMethod("Complete");
            method.Invoke(persister, new object[] {entity});
        }

        public string GetNamespaceForXml(object msg)
        {
            Type type = msg.GetType();
            return GetNamespaceForXml(type);
        }

        private string GetNamespaceForXml(Type type)
        {
            string value;
            if(typeToWellKnownTypeName.TryGetValue(type, out value))
                return value;
            if (type.IsArray)
                return "array_of_" + GetNamespaceForXml(type.GetElementType());

            if (type.Namespace == null && type.Name.StartsWith("<>"))
                throw new InvalidOperationException("Anonymous types are not supported");

            if (type.Namespace == null) //global types?
            {
                return type.Name
                    .ToLowerInvariant();
            }
            var typeName = type.Namespace.Split('.')
                          .Last().ToLowerInvariant() + "." + type.Name.ToLowerInvariant();
            var indexOf = typeName.IndexOf('`');
            if (indexOf == -1)
                return typeName;
            typeName = typeName.Substring(0, indexOf)+ "_of_";
            foreach (var argument in type.GetGenericArguments())
            {
                typeName += GetNamespaceForXml(argument) + "_";
            }
            return typeName.Substring(0,typeName.Length-1);
        }

        public string GetName(object msg)
        {
            return msg.GetType().Name;
        }

        public string GetAssemblyQualifiedNameWithoutVersion(object msg)
        {
            Type type = msg.GetType();
            string value;
            if(typeToWellKnownTypeName.TryGetValue(type, out value))
                return value;

            Assembly assembly = type.Assembly;
            if (assembly.GlobalAssemblyCache == false)
                return type.FullName + ", " + assembly.FullName.Split(',')[0];
            return type.AssemblyQualifiedName;
        }

        public IEnumerable<string> GetProperties(object value)
        {
            return value.GetType().GetProperties()
                .Select(x => x.Name);
        }

        public Type[] GetMessagesConsumed(IMessageConsumer consumer)
        {
            Type consumerType = consumer.GetType();
            return GetMessagesConsumed(consumerType, type => false);
        }

        public Type[] GetMessagesConsumed(Type consumerType, Predicate<Type> filter)
        {
            var list = new HashSet<Type>();
            var toRemove = new HashSet<Type>();

            Type[] interfaces = consumerType.GetInterfaces();

            foreach (Type type in interfaces)
            {
                if (type.IsGenericType == false)
                    continue;

                Type definition = type.GetGenericTypeDefinition();

                if (filter(definition))
                {
                    toRemove.Add(type.GetGenericArguments()[0]);
                    continue;
                }

                if (definition != typeof (ConsumerOf<>))
                    continue;

                list.Add(type.GetGenericArguments()[0]);
            }
            list.ExceptWith(toRemove);
            return list.ToArray();
        }

        #endregion
    }
}