namespace EFCoreReproduce;

public static class DateOnlyExtensions
{
    public static string ToUIDateOnlyString(this DateOnly date)
    {
        return date.ToString("dd-MM-yyyy");
    }
}
