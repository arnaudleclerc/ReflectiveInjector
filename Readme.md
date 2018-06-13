# Dependency injection for .NET Core based on reflection

## Why using reflection for dependency injection

By default, .NET Core has the transitive dependencies activated. It means that, when you have a multiple layer application, all the classes declared in those libraries will be available to all the libraries referencing it. It means that, on an ASP.NET Core application for example, the Controllers stack can know about the real instance of a data provider, not only its abstraction.

Using reflection allows us to keep those classes internal to the library on which they are declared while still being able to register those classes into the dependency injection container of .NET Core.

## How do I use this library

Two .NET Standard 2.0 libraries are available on Nuget

### ReflectiveInjector.Core

The ReflectiveInjector.Core library contains the IRegister interface to implement when services have to be registered. This library should be added as a reference by the libraries having services to register.

The code of this library is available on src/ReflectiveInjector.Core.

https://www.nuget.org/packages/ReflectiveInjector.Core/

### ReflectiveInjector.Extensions

The ReflectiveInjector.Extensions contains the AddReflectorDependencies middleware to call at the start of the application. This method takes one parameter which is the start name of the libraries on which the reflection will be executed, looking for all the classes implementing the IRegistry interface.

The code of this library is available on src/ReflectiveInjector.Extensions.

https://www.nuget.org/packages/ReflectiveInjector.Extensions/ 

## Samples

One sample of a .NET Core Web application is available on samples/WebApp. This folder contains an .NET Core MVC project and one "business" library. The "business" library has public interface IDataBusiness and one internal class DataBusiness implementing IDataBusiness. The internal BusinessRegistry class registers the DataBusiness class into the dependency injection container.

The MVC Project has a dependency on the "business" library, as the HomeController needs an instance implementing the IDataBusiness interface. The call to the middleware is done on the Startup.cs.