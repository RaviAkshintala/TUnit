﻿using System.Reflection;
using TUnit.Core;
using TUnit.Engine;

namespace TUnit.TestAdapter;

internal class TestCollector(CacheableAssemblyLoader assemblyLoader, TestsLoader testsLoader)
{
    public IEnumerable<TestDetails> TestsFromSources(IEnumerable<string> sources)
    {
        var allAssemblies = sources
            .Select(assemblyLoader.GetOrLoadAssembly)
            .OfType<Assembly>()
            .ToArray();
        
        return allAssemblies
            .Select(x => new TypeInformation(x))
            .SelectMany(x => testsLoader.GetTests(x, allAssemblies));
    }
}