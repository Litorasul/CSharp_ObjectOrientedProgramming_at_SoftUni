using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using CustomTestingFramework.Utilities;
using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exeptions;

namespace CustomTestingFramework.TestRunner
{
    public class TestRunner
    {
        private readonly ICollection<string> resultInfo;

        public TestRunner()
        {
            resultInfo = new List<string>();
        }

        public ICollection<string> Run(string assemblyPath)
        {
            var testClasses = Assembly
                .LoadFrom(assemblyPath)
                .GetTypes()
                .Where(mi => mi.HasAttribute<TestClassAttribute>())
                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
                    .GetMethods()
                    .Where(mi => mi.HasAttribute<TestMethodAttribute>())
                    .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);

                foreach (var methodInfo in testMethods)
                {
                    try
                    {
                        methodInfo.Invoke(testClassInstance, null);
                        this.resultInfo.Add($"Method: {methodInfo.Name} - passed!");

                    }
                    catch (TestException te)
                    {

                        this.resultInfo.Add($"Method: {methodInfo.Name} - failed!");
                    }
                    catch
                    {
                        this.resultInfo.Add($"Method: {methodInfo.Name} - unexpected error occured!");
                    }
                }
            }

            return this.resultInfo;
        }
    }
}
