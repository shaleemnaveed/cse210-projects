using System;

class Program
{
    static void Main(string[] args)
    {
        Running running = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycling = new Cycling("03 Nov 2022", 45, 20.0);
        Swimming swimming = new Swimming("03 Nov 2022", 30, 24);

        List<Activity> _activities = new List<Activity> { running, cycling, swimming };

        foreach (Activity activity in _activities)
        {
            activity.DisplaySummary();
        }
    }
}