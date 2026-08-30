using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var result = AnalyzeText("C# is fun.");
        var report = new StringBuilder();
        report.AppendLine($"Words: {result.Words}");
        report.AppendLine($"Chars: {result.Chars}");
        report.AppendLine($"MostFrequent: {result.MostFrequent}");
        report.AppendLine($"Longest: {result.Longest}");
        report.AppendLine($"Sentences: {result.Sentences}");

        Console.WriteLine(report.ToString());
        ComparePerformance();
    }
    public static void ComparePerformance()
    {
        const int iterations = 10_000;
        Stopwatch stopwatch = new Stopwatch();

        string normalString = "";

        stopwatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            normalString += "C#";
        }

        stopwatch.Stop();

        Console.WriteLine(
            $"String concatenation: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");


        stopwatch.Restart();

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            builder.Append("C#");
        }

        string builderResult = builder.ToString();

        stopwatch.Stop();

        Console.WriteLine(
            $"StringBuilder: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }
    public static (int Words, int Chars, string MostFrequent,string Longest, int Sentences) AnalyzeText(string s)
    {
        int sentenceCount = 0;
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int wordCount = words.Length;
        int charCount = s.Length;
        string longestWord = "";
        foreach (char ch in s)
        {
            if (ch=='.'||ch=='?'||ch=='!')
            {
                sentenceCount++;
            }
        }
        foreach (var item in words)
        {
            string q=item.Trim('.', ',', '!', '?');
            if (q.Length > longestWord.Length)
            {
                longestWord = q;
            }
        }
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (var word in words)
        {
            string cleanWord = word.Trim('.', ',', '!', '?').ToLower();
            if (wordCounts.ContainsKey(cleanWord))
            {
                wordCounts[cleanWord]++;
            }
            else
            {
                wordCounts.Add(cleanWord, 1);
            }
        }

        string mostFrequentWord = "";
        int highestCount = 0;

        foreach (var pair in wordCounts)
        {
            if (pair.Value>highestCount)
            {
                highestCount = pair.Value;
                mostFrequentWord = pair.Key;
            }
        }
       
        
        return (wordCount, charCount, mostFrequentWord, longestWord, sentenceCount);
        
    }


   
}