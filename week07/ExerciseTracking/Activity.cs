using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy");
        string activityType = this.GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{date} {activityType} ({_minutes} min): Distance {distance:F1} km, Speed: {speed:F1} kph, Pace: {pace:F2} min per km";
    }
}