using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TaskAwaiterHelper;


public static class TaskAwaiterForProcessHelper
{
    public static TaskAwaiter<int> GetAwaiter(this Process process)
    {
        var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

        process.EnableRaisingEvents = true;
        process.Exited += (sender, args) =>
        {
            var senderProcess = sender as Process;

            if (senderProcess == null)
                return;

            tcs.SetResult(senderProcess.ExitCode);
        };

        return tcs.Task.GetAwaiter();
    }
}

public static class TaskAwaiterTester
{
    public static void Run()
    {
        var proces = Process.Start("mspaint.exe");

        var awaiter = proces.GetAwaiter();

        var result = awaiter.GetResult();
        Console.WriteLine(result);
    }
}