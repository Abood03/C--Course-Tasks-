namespace StringUtilities
{
    public static class StringHelper
    {
        public static string AddHello(string name)
        {
            return $"Hello {name}";
        }

        public static bool IsLong(string text)
        {
            return text.Length > 10;
        }
    }
}