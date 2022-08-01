using System;

namespace AsyncAwait;

public static class AsyncAwaitTest
{
    public static Task<int> GetTestTaskAsync(int id)
    {
        return Task.FromResult(id);
    }

    public static async Task<IEnumerable<int>> WhenAllTest(IEnumerable<int> ids)
    {
        var getUserTasks = new List<Task<int>>();
        foreach (int id in ids)
        {
            getUserTasks.Add(GetTestTaskAsync(id));
        }

        return await Task.WhenAll(getUserTasks);
    }

    public static async Task<Task<int>> WhenAnyTest(IEnumerable<int> ids)
    {
        var getUserTasks = new List<Task<int>>();
        foreach (int id in ids)
        {
            getUserTasks.Add(GetTestTaskAsync(id));
        }

        return await Task.WhenAny(getUserTasks);
    }
}