namespace BetTracker.Helpers;

public class BetHelpers
{
    public static float DollarsToUnits(
        float dollars,
        float unitSize,
        int digits)
        => (float)Math.Round(dollars / unitSize, digits);
}