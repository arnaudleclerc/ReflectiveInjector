[![NuGet](https://img.shields.io/nuget/v/ReflectiveInjector.Extensions.svg)](https://www.nuget.org/packages/ReflectiveInjector.Extensions/)
[![NuGet](https://img.shields.io/nuget/v/ReflectiveInjector.Core.svg)](https://www.nuget.org/packages/ReflectiveInjector.Core/)

# Dependency injection for .NET Core based on reflection

## Keep your classes internal

Using reflection to look for dependencies injection allows us to keep the real instances of injectable interfaces internal to our libraries and therefore not exposing them to other parts of our applications.

## How do I use this library

Two .NET Standard 2.0 libraries are available on Nuget

### ReflectiveInjector.Core

The ReflectiveInjector.Core library contains the IRegister interface to implement when services have to be registered. This library should be added as a reference by the libraries having services to register.

The code of this library is available on src/ReflectiveInjector.Core.

[![NuGet](https://img.shields.io/nuget/v/ReflectiveInjector.Core.svg)](https://www.nuget.org/packages/ReflectiveInjector.Core/)

### ReflectiveInjector.Extensions

The ReflectiveInjector.Extensions contains the AddReflectorDependencies middleware to call at the start of the application. This method takes one parameter which is the start name of the libraries on which the reflection will be executed, looking for all the classes implementing the IRegistry interface.

The code of this library is available on src/ReflectiveInjector.Extensions.

[![NuGet](https://img.shields.io/nuget/v/ReflectiveInjector.Extensions.svg)](https://www.nuget.org/packages/ReflectiveInjector.Extensions/)

## Samples

One sample of a .NET Core Web application is available on samples/WebApp. This folder contains an .NET Core MVC project and one "business" library. The "business" library has public interface IDataBusiness and one internal class DataBusiness implementing IDataBusiness. The internal BusinessRegistry class registers the DataBusiness class into the dependency injection container.

The MVC Project has a dependency on the "business" library, as the HomeController needs an instance implementing the IDataBusiness interface. The call to the middleware is done on the Startup.cs.