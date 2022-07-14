# Runtime-Composition

A C# .NET Framework 4.8 ASP.NET MVC web application demonstration the concept of run time composition.

The design behind this pattern is that the dependency graph is created during runtime, on a per client request basis. The composition is triggered through the context of the application's operating environment and the information received by the application. Information such as URI, environment variables, server technology, routing, decision trees, machine learning (ML) models, cache, cookies, locale, internet protocol (IP) address, internet service provider (ISP), host operationg system (OS), guest OS, browser, etc... can all be used to compose an application's dependency graph in real-time.

Runtime Composition is enabling a single physical deployment to service many different requirements without the need of having multiple code bases, branches or hosting multiple applications. It's the concept of one physical application acting as several logical applications.

Within the folder App_Start, the main registration for these dependencies are configured in UnityConfig.cs

The code below registers instances with different names. These names are used to call the individual instances throughout the application that have been registered against the interface ILanguage.
```
container
  .RegisterType<ILanguage, English>("en-GB")
  .RegisterType<ILanguage, Arabic>("ar-SA")
  .RegisterType<ILanguage, Japanese>("jp-JP");
```

The dependency factory is responsible for resolving and returning the instance as requested during run time of the application.
```
container.RegisterFactory<Func<string, ILanguage>>(l => new Func<string, ILanguage>(name => l.Resolve<ILanguage>(name)));
```

