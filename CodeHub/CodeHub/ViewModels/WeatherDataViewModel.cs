
namespace CodeHub.ViewModels
{
    public class WeatherDataViewModel
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<Timeline> Timelines { get; set; }
    }

    public class Timeline
    {
        public string Timestep { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public List<Interval> Intervals { get; set; }
    }

    public class Interval
    {
        public DateTimeOffset StartTime { get; set; }
        public Values Values { get; set; }
    }

    public class Values
    {
        public double Temperature { get; set; }
    }
}
