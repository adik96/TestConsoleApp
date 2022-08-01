using AsyncAwait;
using AsyncEnumerable;
using TaskAwaiterHelper;
using CancellationTokenTesterSp;
using ConsoleApp1;

namespace Program
{
    static class Program
    {
        static async Task Main()
        {
            TaskAwaiterTester.Run();
            var result = await AsyncAwaitTest.WhenAllTest(new List<int> { 1, 2, 3, 5 });
            foreach (int i in result)
                Console.WriteLine(i);

            var result2 = await AsyncAwaitTest.WhenAnyTest(new List<int> { 1, 2, 3, 5 });
            var test = await result2;

            Console.WriteLine(test);

            await foreach (var it in AsyncEnumerableTester.ReadWordsFromStreamAsync())
                Console.WriteLine(it);

            await CancellationTokenTester.CancelTestTaskByEnter();

            await TaskGenerator.TasksTest();
            Multithreading.Test2();

            Console.ReadLine();
        }


    }
}
