using System;


namespace ConsoleApp1
{
    public static class TaskGenerator
    {
        public static async Task TasksTest()
        {
            var tasks = GenerateTasks();

            foreach (var task in tasks)
                task.Start();

            Console.WriteLine("-----------------PRZED await Task.WhenAll");
            await Task.WhenAll(tasks);
            Console.WriteLine("-----------------PO await Task.WhenAll");
        }

        public static List<Task> GenerateTasks()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var task = new Task((param) =>
                {
                    while (true)
                    {
                        Console.WriteLine(param);
                        Task.Delay(1000);
                    }
                    
                }, i);

                tasks.Add(task);
            }
            

            return tasks;
        }
    }
}
