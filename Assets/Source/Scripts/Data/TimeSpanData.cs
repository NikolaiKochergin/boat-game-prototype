using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class TimeSpanData
    {
        public int Hours;
        public int Minutes;
        public int Seconds;

        public TimeSpanData(int timeSpanHours, int timeSpanMinutes, int timeSpanSeconds) =>
            (Hours, Minutes, Seconds) = (timeSpanHours, timeSpanMinutes, timeSpanSeconds);
    }
}