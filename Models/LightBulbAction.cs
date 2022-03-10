namespace AdventOfCode2015.Models
{
    public enum LightBulbActionType
    {
        TurnOn,
        TurnOff,
        Toggle
    }

    public record struct LightBulbAction((int X, int Y) From, (int X, int Y) To, LightBulbActionType ActionType);
}