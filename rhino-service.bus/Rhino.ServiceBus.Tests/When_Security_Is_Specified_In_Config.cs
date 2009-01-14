using System.IO;
using System.Security.Cryptography;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Rhino.ServiceBus.Convertors;
using Rhino.ServiceBus.DataStructures;
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;
using Xunit;

namespace Rhino.ServiceBus.Tests
{
    public class When_Security_Is_Specified_In_Config
    {
        private static IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer(new XmlInterpreter("AnotherBus.config"));
            container.Kernel.AddFacility("rhino.esb", new RhinoServiceBusFacility());
            return container;
        }

        [Fact]
        public void Will_register_wire_encrypted_string_convertor_on_container()
        {
            var container = CreateContainer();
            var convertor = container.Resolve<IValueConvertor<WireEcryptedString>>();
            Assert.IsType<WireEcryptedStringConvertor>(convertor);
        }


        public class ClassWithSecretField
        {
            public WireEcryptedString ShouldBeEncrypted
            {
                get; set;
            }

        }

        public const string encryptedMessage =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
<esb:messages xmlns:esb=""http://servicebus.hibernatingrhinos.com/2008/12/20/esb"" xmlns:tests.classwithsecretfield=""Rhino.ServiceBus.Tests.When_Security_Is_Specified_In_Config+ClassWithSecretField, Rhino.ServiceBus.Tests"" xmlns:datastructures.wireecryptedstring=""Rhino.ServiceBus.DataStructures.WireEcryptedString, Rhino.ServiceBus"">
  <tests.classwithsecretfield:ClassWithSecretField>
    <datastructures.wireecryptedstring:ShouldBeEncrypted>SK/bXI5J+5jA+ZICnpXWjg==</datastructures.wireecryptedstring:ShouldBeEncrypted>
  </tests.classwithsecretfield:ClassWithSecretField>
</esb:messages>";

        [Fact]
        public void Will_encrypt_fields_of_messages()
        {
            var container = CreateContainer();
            var serializer = container.Resolve<IMessageSerializer>();
            var memoryStream = new MemoryStream();
            serializer.Serialize(new[]
            {
                new ClassWithSecretField
                {
                    ShouldBeEncrypted = new WireEcryptedString{Value = "abc"}
                }
            },memoryStream);

            memoryStream.Position = 0;
            var msg = new StreamReader(memoryStream).ReadToEnd();

            
            Assert.Equal(encryptedMessage, msg);
        }

        [Fact]
        public void Will_decrypt_fields_of_messages()
        {
            var container = CreateContainer();
            var serializer = container.Resolve<IMessageSerializer>();
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(encryptedMessage);
            writer.Flush();
            memoryStream.Position = 0;

            var msg = (ClassWithSecretField)serializer.Deserialize(memoryStream)[0];

            Assert.Equal("abc", msg.ShouldBeEncrypted.Value);
        }

        [Fact]
        public void When_key_is_different_deserializing_key_will_fail()
        {
            var container = CreateContainer();
            var serializer = container.Resolve<IMessageSerializer>();
            var convertor = (WireEcryptedStringConvertor)container.Resolve<IValueConvertor<WireEcryptedString>>();

            var managed = new RijndaelManaged();
            managed.GenerateKey();

            convertor.Key = managed.Key;

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(encryptedMessage);
            writer.Flush();
            memoryStream.Position = 0;

            Assert.Throws<CryptographicException>(
                () => serializer.Deserialize(memoryStream)
                );
        }

        [Fact]
        public void When_IV_is_different_deserializing_key_will_fail()
        {
            var container = CreateContainer();
            var serializer = container.Resolve<IMessageSerializer>();
            var convertor = (WireEcryptedStringConvertor)container.Resolve<IValueConvertor<WireEcryptedString>>();

            var managed = new RijndaelManaged();
            managed.GenerateIV();

            convertor.IV = managed.IV;

            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write(encryptedMessage);
            writer.Flush();
            memoryStream.Position = 0;

            Assert.Throws<CryptographicException>(
                () => serializer.Deserialize(memoryStream)
                );
        }
    }
}