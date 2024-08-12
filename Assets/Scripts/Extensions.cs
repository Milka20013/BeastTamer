using System;

public static class Extensions
{
    public static string AsRoundStr(this float value, int decimalPoints = 1)
    {
        return Math.Round(value, decimalPoints).ToString();
    }
}
