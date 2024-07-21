using System.Diagnostics;

namespace ReadFilesByTasks;

class Program
{
    static async Task Main(string[] args)
    {
        var pathDirectory = "./Files";
        var files = new DirectoryInfo(pathDirectory).GetFiles();
        var tasks = new  List<Task<int>>();
        var watch = new Stopwatch();
        watch.Start();
        foreach (var file in files)
        {
            Console.WriteLine(file.FullName);
            var reader = new ReaderFile(file.FullName);
            tasks.Add(reader.ReadFileAsync());
        }

        var result = await Task.WhenAll(tasks);
        foreach (var spaceAmount in result)
        {
            Console.WriteLine(spaceAmount);
        }
        watch.Stop();
        Console.WriteLine(watch.Elapsed);
    }
}
