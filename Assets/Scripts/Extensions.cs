using System;

public static class Extensions
{
    public static string AsRoundStr(this float value, int decimalPoints = 1)
    {
        return Math.Round(value, decimalPoints).ToString();
    }

    public static string ToFirstLower(this string value)
    {
        char first = char.ToLower(value[0]);
        string str = first + value.Remove(0, 1);
        return str;
    }

    public static string ToPascalCase(this string value)
    {
        value = value.ToFirstLower();
        var parts = value.Split();
        return string.Join("", parts);
    }
}
