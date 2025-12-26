namespace PlanDate.Extractor.Entities;

public record DayOfWeek : CreatioEntity
{
    public DayOfWeekNumber Number { get; set; }
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