using System;
using System.IO;
using static TaskManager;

class Program
{
    static void Main(string[] args)
    {
        TaskManager manager = new TaskManager();

        manager.TaskCompleted += LogToConsole;
        manager.TaskCompleted += LogToFile;

        TaskItem myTask = new TaskItem { Id = 1, Title = "C# Delegates", IsCompleted = false };
        manager.CompleteTask(myTask);

        Console.ReadKey();
    }

    public static void LogToConsole(string taskName, string message)
    {
        Console.WriteLine($"[Console Log] Task: '{taskName}' - Message: {message}");
        Console.ResetColor();
    }

    public static void LogToFile(string taskName, string message)
    {
        string filePath = "tasks_log.txt";
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Task: '{taskName}' - {message}{Environment.NewLine}";

        File.AppendAllText(filePath, logEntry);
        Console.WriteLine($"[File Log] Task notification saved to {filePath}");
    }
}

public class TaskManager
{
    public delegate void TaskNotificationStrategy(string taskName, string message);
    public event TaskNotificationStrategy TaskCompleted;

    public void CompleteTask(TaskItem task)
    {
        if (!task.IsCompleted)
        {
            task.IsCompleted = true;
            TaskCompleted?.Invoke(task.Title, "Mission is completed");
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}