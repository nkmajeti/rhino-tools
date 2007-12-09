import namespaces from "assembly://Binsor.Presentation.Framework/DefaultImport.boo"

class WellKnown:
	public static Types = (ICommand, IView, ILayout, ILayoutRegistry, IModuleLoader, IPresenter, IApplicationContext )
	public static Singletons = (ICommand, IModuleLoader, ILayoutRegistry, IApplicationContext )
	public static Assemblies = ("Binsor.Presentation.Framework", )

def InitializeContainer( *assemblies as (string) ):
	facility 'common.resolvers', AddCommonResolversFacility
	for assembly in cat(WellKnown.Assemblies, assemblies):
		for type as Type in Assembly.Load(assembly).GetTypes():
			continue unless type.IsClass and not type.IsAbstract
			ProcessType(type)
			
def ProcessType(type as Type):
	for wellKnownType in WellKnown.Types:
		continue unless wellKnownType.IsAssignableFrom(type)
		lifeStyle = LifestyleType.Transient
		lifeStyle = LifestyleType.Singleton if wellKnownType in WellKnown.Singletons
		component ExtractName(type), ExtractInterface(wellKnownType, type), type, lifeStyle
		
		
def ExtractName(service as Type):
	att as (ComponentAttribute) = service .GetCustomAttributes(ComponentAttribute, false)
	return service.Name if att.Length == 0
	return att[0].Name

def ExtractInterface(service as Type, impl as Type):
	for interfaceType in impl.GetInterfaces():
		return interfaceType if service.IsAssignableFrom(interfaceType)
	return service
	
def PrintRegisteredComponents():
	# quick way to do reflection, quack
	kernel as duck = IoC.Container.Kernel
	for handler in kernel.NamingSubSystem.GetHandlers():
		print "${handler.ComponentModel.Name} => ${handler.ComponentModel.Service}"
		