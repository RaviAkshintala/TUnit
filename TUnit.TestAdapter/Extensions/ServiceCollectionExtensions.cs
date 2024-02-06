﻿using Microsoft.Extensions.DependencyInjection;

namespace TUnit.TestAdapter.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTestAdapterServices(this IServiceCollection services)
    {
        return services.AddSingleton<TestsLoader>()
            .AddSingleton<AsyncTestRunExecutor>()
            .AddSingleton<TestCollector>()
            .AddSingleton<SourceLocationHelper>()
            .AddSingleton<ReflectionMetadataProvider>()
            .AddSingleton<TUnitTestFilterProvider>()
            .AddSingleton<TestClassCreator>()
            .AddSingleton<TestMethodRetriever>()
            .AddSingleton<TestGrouper>()
            .AddSingleton<CombinativeSolver>()
            .AddSingleton<SingleTestExecutor>();
    }
}