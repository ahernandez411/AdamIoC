# AdamIoC
An implementation of an IoC Container

## Getting Started
In order to use AdamIoC you need to pull down the source code, build it in visual studio 2017, and place a reference to the AdamIoC assembly to your project.

### Prerequisites 
The project depends on .NET 4.6.1.

## Start using AdamIoC

### 1. Make an instance of the ContainerAdamIoC class.
```
var container = new ContainerAdamIoC();
```

### 2. Create the interface to implementation registrations
```
container.RegisterImplementation<ISomeInterface, SomeImplementation>();
```

### 2a. Optional parameters to method to control how often the instance should be created when resolving the instance
```
Tranient - Create a new instance every time a new instance is called for
Singleton - Share the same instance each time the code asks for it
```
### 2b. Supported was to use RegisterImplementation method
```
// this will take on the default LifecycleType of Transient
container.RegisterImplementation<ISomeInterface, SomeImplementation>(); 
container.RegisterImplementation<ISomeInterface, SomeImplementation>(LifecycleType.Transient);
container.RegisterImplementation<ISomeInterface, SomeImplementation>(LifecycleType.Singleton);
```

### 3. Getting an instance of an implementation
```
var instance = container.GetInstance<ISomeInterface>();
```

## Things to know
Each instance of the ContainerAdamIoC contains the registrations and the ability to create instances of an interface. If the code attempts to create an instance of a unregistered interface it will throw a NotRegisteredException.
