namespace PlanDate.Extractor.Entities;

public record DayOfWeek : CreatioEntity
{
    public int Number { get; set; }
}

public enum DayOfWeekNumber
{
    Sunday = 1,
    Monday = 2,
    Tuesday = 3,
    Wednesday = 4,
    Thursday = 5,
    Friday = 6,
    Saturday = 7
}