class Program
{
    static int progress = 0;

    // Used to protect the shared progress variable
    static object progressLock = new object();


    static async Task Main(string[] args)
    {
        // =====================================================
        // 1. Thread Version
        // =====================================================

        Console.WriteLine("Thread Version");
        Console.WriteLine("------------------------");

        progress = 0;

        List<Thread> threads = new List<Thread>();

        for (int i = 1; i <= 5; i++)
        {
            int fileNumber = i;

            Thread thread = new Thread(() =>
            {
                DownloadFile(fileNumber);
            });

            threads.Add(thread);
            thread.Start();
        }


        // Wait until all threads finish
        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("All files downloaded using Threads");


        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine();


        // =====================================================
        // 2. Async / Await Version
        // =====================================================

        Console.WriteLine("Async/Await Version");
        Console.WriteLine("------------------------");

        progress = 0;

        List<Task> tasks = new List<Task>();

        for (int i = 1; i <= 5; i++)
        {
            tasks.Add(DownloadFileAsync(i));
        }


        // Wait for all download tasks together
        await Task.WhenAll(tasks);

        Console.WriteLine("All files downloaded using Async/Await");
    }


    // =====================================================
    // Thread download
    // =====================================================

    static void DownloadFile(int fileNumber)
    {
        Console.WriteLine($"File {fileNumber} started downloading");

        // Simulate download time
        Thread.Sleep(1000 + (fileNumber * 200));

        lock (progressLock)
        {
            progress += 20;

            Console.WriteLine($"File {fileNumber} downloaded");
            Console.WriteLine($"Progress: {progress}%");
        }
    }


    // =====================================================
    // Async download
    // =====================================================

    static async Task DownloadFileAsync(int fileNumber)
    {
        Console.WriteLine($"File {fileNumber} started downloading");

        // Simulate asynchronous download
        await Task.Delay(1000 + (fileNumber * 200));

        lock (progressLock)
        {
            progress += 20;

            Console.WriteLine($"File {fileNumber} downloaded");
            Console.WriteLine($"Progress: {progress}%");
        }
    }
}