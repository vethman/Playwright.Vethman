# Playwright.Vethman
Demo project for using Playwright with NUnit

When I run a test that fails in headed mode (Headless = false), then the completion of a testrun takes 30 seconds. WaitForCompletion(int timeout) has a timeout value of -1. Why? If I run the same test headless, then there is no wait.

# Here is the stacktrace:

System.Private.CoreLib.dll!System.Threading.ManualResetEventSlim.Wait(int millisecondsTimeout, System.Threading.CancellationToken cancellationToken)	Unknown
System.Private.CoreLib.dll!System.Threading.ManualResetEventSlim.Wait(int millisecondsTimeout)	Unknown
nunit.framework.dll!NUnit.Framework.Api.NUnitTestAssemblyRunner.WaitForCompletion(int timeout) Line 250	C#
nunit.framework.dll!NUnit.Framework.Api.NUnitTestAssemblyRunner.Run(NUnit.Framework.Interfaces.ITestListener listener, NUnit.Framework.Interfaces.ITestFilter filter) Line 213	C#
nunit.framework.dll!NUnit.Framework.Api.FrameworkController.RunTests(System.Action<string> callback, string filter) Line 258	C#
[Native to Managed Transition]	
[Managed to Native Transition]	
nunit.engine.core.dll!NUnit.Engine.Drivers.NUnitNetStandardDriver.ExecuteMethod(System.Reflection.MethodInfo method, object[] args)	Unknown
nunit.engine.core.dll!NUnit.Engine.Drivers.NUnitNetStandardDriver.ExecuteMethod(string methodName, System.Type[] ptypes, object[] args)	Unknown
nunit.engine.core.dll!NUnit.Engine.Drivers.NUnitNetStandardDriver.Run(NUnit.Engine.ITestEventListener listener, string filter)	Unknown
nunit.engine.core.dll!NUnit.Engine.Runners.DirectTestRunner.RunTests(NUnit.Engine.ITestEventListener listener, NUnit.Engine.TestFilter filter)	Unknown
nunit.engine.core.dll!NUnit.Engine.Runners.AbstractTestRunner.Run(NUnit.Engine.ITestEventListener listener, NUnit.Engine.TestFilter filter)	Unknown
nunit.engine.dll!NUnit.Engine.Runners.MasterTestRunner.RunTests(NUnit.Engine.ITestEventListener listener, NUnit.Engine.TestFilter filter)	Unknown
nunit.engine.dll!NUnit.Engine.Runners.MasterTestRunner.Run(NUnit.Engine.ITestEventListener listener, NUnit.Engine.TestFilter filter)	Unknown
NUnit3.TestAdapter.dll!NUnit.VisualStudio.TestAdapter.NUnitEngine.NUnitEngineAdapter.Run(NUnit.Engine.ITestEventListener listener, NUnit.Engine.TestFilter filter)	Unknown
NUnit3.TestAdapter.dll!NUnit.VisualStudio.TestAdapter.Execution.Run(NUnit.Engine.TestFilter filter, NUnit.VisualStudio.TestAdapter.NUnitEngine.DiscoveryConverter discovery, NUnit.VisualStudio.TestAdapter.NUnit3TestExecutor nUnit3TestExecutor)	Unknown
NUnit3.TestAdapter.dll!NUnit.VisualStudio.TestAdapter.NUnit3TestExecutor.RunAssembly(string assemblyPath, System.Linq.IGrouping<string, Microsoft.VisualStudio.TestPlatform.ObjectModel.TestCase> testCases, NUnit.Engine.TestFilter filter)	Unknown
NUnit3.TestAdapter.dll!NUnit.VisualStudio.TestAdapter.NUnit3TestExecutor.RunTests(System.Collections.Generic.IEnumerable<Microsoft.VisualStudio.TestPlatform.ObjectModel.TestCase> tests, Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IRunContext runContext, Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IFrameworkHandle frameworkHandle)	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Execution.RunTestsWithTests.InvokeExecutor(Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework.Utilities.LazyExtension<Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.ITestExecutor, Microsoft.VisualStudio.TestPlatform.Common.Interfaces.ITestExecutorCapabilities> executor, System.Tuple<System.Uri, string> executorUri, Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Adapter.RunContext runContext, Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter.IFrameworkHandle frameworkHandle)	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Execution.BaseRunTests.RunTestInternalWithExecutors(System.Collections.Generic.IEnumerable<System.Tuple<System.Uri, string>> executorUriExtensionMap, long totalTests)	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Execution.BaseRunTests.RunTestsInternal()	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Execution.BaseRunTests.RunTests()	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Execution.ExecutionManager.StartTestRun(System.Collections.Generic.IEnumerable<Microsoft.VisualStudio.TestPlatform.ObjectModel.TestCase> tests, string package, string runSettings, Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol.TestExecutionContext testExecutionContext, Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ITestCaseEventsHandler testCaseEventsHandler, Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.IInternalTestRunEventsHandler runEventsHandler)	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.TestRequestHandler.OnMessageReceived.AnonymousMethod__4()	Unknown
Microsoft.TestPlatform.CrossPlatEngine.dll!Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.TestRequestHandler..ctor.AnonymousMethod__31_2(System.Action action)	Unknown
Microsoft.TestPlatform.CoreUtilities.dll!Microsoft.VisualStudio.TestPlatform.Utilities.JobQueue<System.Action>.SafeProcessJob(System.Action job)	Unknown
Microsoft.TestPlatform.CoreUtilities.dll!Microsoft.VisualStudio.TestPlatform.Utilities.JobQueue<System.Action>.BackgroundJobProcessor(string threadName)	Unknown
Microsoft.TestPlatform.CoreUtilities.dll!Microsoft.VisualStudio.TestPlatform.Utilities.JobQueue<System.__Canon>..ctor.AnonymousMethod__16_0()	Unknown
System.Private.CoreLib.dll!System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state)	Unknown
System.Private.CoreLib.dll!System.Threading.Tasks.Task.ExecuteWithThreadLocal(ref System.Threading.Tasks.Task currentTaskSlot, System.Threading.Thread threadPoolThread)	Unknown
