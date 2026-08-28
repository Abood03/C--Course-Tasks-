using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // =====================================================
        // 1. Create directories
        // =====================================================

        string notesFolder = Path.Combine("Notes", "2024", "June");
        string backupFolder = Path.Combine("Notes", "2024", "Backup");
        string archiveFolder = Path.Combine("Notes", "2024", "Archive");

        Directory.CreateDirectory(notesFolder);
        Directory.CreateDirectory(backupFolder);
        Directory.CreateDirectory(archiveFolder);

        Console.WriteLine("Directories Created");

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 2. Write note using StreamWriter
        // =====================================================

        string notePath = Path.Combine(notesFolder, "note1.txt");

        using (StreamWriter writer = new StreamWriter(notePath))
        {
            writer.WriteLine("My First Note");
            writer.WriteLine("Abood Alabadi");
        }

        Console.WriteLine("Note Created");

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 3. Read note using StreamReader
        // =====================================================

        Console.WriteLine("Read Note");

        using (StreamReader reader = new StreamReader(notePath))
        {
            string text = reader.ReadToEnd();

            Console.WriteLine(text);
        }

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 4. Append text to existing file
        // =====================================================

        using (StreamWriter writer = new StreamWriter(notePath, true))
        {
            writer.WriteLine("This line was appended later.");
        }

        Console.WriteLine("Text Appended");

        Console.WriteLine("-----------------------------");


        // Read again after append
        using (StreamReader reader = new StreamReader(notePath))
        {
            Console.WriteLine(reader.ReadToEnd());
        }

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 5. Copy file
        // =====================================================

        string copyPath = Path.Combine(backupFolder, "note1_copy.txt");

        File.Copy(notePath, copyPath, true);

        Console.WriteLine("File Copied");

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 6. Move file
        // =====================================================

        string movedPath = Path.Combine(archiveFolder, "note1_archive.txt");

        if (File.Exists(movedPath))
        {
            File.Delete(movedPath);
        }

        File.Move(copyPath, movedPath);

        Console.WriteLine("File Moved");

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 7. FileInfo
        // =====================================================

        FileInfo fileInfo = new FileInfo(notePath);

        Console.WriteLine("File Information");

        Console.WriteLine($"Name: {fileInfo.Name}");
        Console.WriteLine($"Size: {fileInfo.Length} bytes");
        Console.WriteLine($"Creation Date: {fileInfo.CreationTime}");
        Console.WriteLine($"Last Modified: {fileInfo.LastWriteTime}");

        Console.WriteLine("-----------------------------");


        // =====================================================
        // 8. DirectoryInfo
        // =====================================================

        DirectoryInfo directoryInfo = new DirectoryInfo(notesFolder);

        Console.WriteLine("Directory Information");

        Console.WriteLine($"Name: {directoryInfo.Name}");
        Console.WriteLine($"Full Path: {directoryInfo.FullName}");
        Console.WriteLine($"Creation Date: {directoryInfo.CreationTime}");
        Console.WriteLine($"Last Modified: {directoryInfo.LastWriteTime}");
    }
}