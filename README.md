# Dependency Injection
![](./docs/qrcode.png)

# Topics
- Transient, scoped and singleton demo
- Registring mayhem
- Longer term maintnenace

# Talking points

## Dependency injection in the old days

Back in the old days before unit testing was a priorty and dependency injection was on the bleeding edge we had the following.

```c#
public class Service{

    ConcreteService _cs1; 
    ConcreteService2 _cs2;

    public Service() {
        // New these up internally
        _cs1 = new();
        _cs2 = new();
        ...
    }

    public

}

public class Consumer {
    Service _s;

    public Consumer() {
        _s = new Service();
    }
}
```

SOLID has been around for a while but people thought this was good enough. Why would you need interfaces and what not? Plus, C# is pretty backwards. If you used Java, you wouldn't run into this problem because everything is extendable?

Why would you need to inject something at runtime? You're always going to be using this 1:1 inner service. Keep it simple!

## Back in the old days

Who remembers these?

- [Ninject](https://github.com/ninject/Ninject)
- [Autofaq](https://autofac.org/)

This was how things were done before dependency injection was mainstream. DI was introduced in 2016 with ASP.NET core 1.0!  It's not too different to the way it's done now.

## What is it?

Demo with the C# in this project

## Why is it?

## All the things

![](./docs/meettheparents.png)

## More injection

[Decorators](https://en.wikipedia.org/wiki/Decorator_pattern) - Don't worry about it, I got chu fam.

We will be using [Scrutor](https://github.com/khellang/Scrutor) for more complicated injections as the vanilla does not support this.

Hypothetical payments pipeline
