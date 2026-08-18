using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Provides useful extension methods for strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts the string to title case.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The string formatted in title case.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the string is null.
    /// </exception>
    /// <example>
    /// <code>
    /// "hello world".ToTitleCase();
    /// // Hello World
    /// </code>
    /// </example>
    public static string ToTitleCase(this string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(value.ToLower());
    }


    /// <summary>
    /// Shortens a string to the specified maximum length.
    /// </summary>
    /// <param name="value">The string to truncate.</param>
    /// <param name="maxLength">
    /// The maximum number of characters allowed.
    /// </param>
    /// <returns>
    /// The original string if it is shorter than maxLength,
    /// otherwise a truncated string.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the string is null.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when maxLength is negative.
    /// </exception>
    /// <example>
    /// <code>
    /// "Hello World".Truncate(5);
    /// // Hello
    /// </code>
    /// </example>
    public static string Truncate(this string value, int maxLength)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        if (maxLength < 0)
            throw new ArgumentOutOfRangeException(nameof(maxLength));

        if (value.Length <= maxLength)
            return value;

        return value.Substring(0, maxLength);
    }


    /// <summary>
    /// Checks whether a string has a valid email format.
    /// </summary>
    /// <param name="value">The email address to validate.</param>
    /// <returns>
    /// True if the email format is valid; otherwise false.
    /// </returns>
    /// <example>
    /// <code>
    /// bool valid = "test@gmail.com".IsValidEmail();
    /// // true
    /// </code>
    /// </example>
    public static bool IsValidEmail(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        return Regex.IsMatch(value, pattern);
    }


    /// <summary>
    /// Converts a string into a URL-friendly slug.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>
    /// A lowercase slug where spaces are replaced with hyphens.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the string is null.
    /// </exception>
    /// <example>
    /// <code>
    /// "Learning C Sharp".ToSlug();
    /// // learning-c-sharp
    /// </code>
    /// </example>
    public static string ToSlug(this string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        string slug = value.Trim().ToLowerInvariant();

        // Remove special characters while keeping letters and numbers
        slug = Regex.Replace(
            slug,
            @"[^\p{L}\p{Nd}\s-]",
            ""
        );

        // Replace spaces with -
        slug = Regex.Replace(
            slug,
            @"\s+",
            "-"
        );

        // Remove repeated -
        slug = Regex.Replace(
            slug,
            @"-+",
            "-"
        );

        return slug.Trim('-');
    }
}