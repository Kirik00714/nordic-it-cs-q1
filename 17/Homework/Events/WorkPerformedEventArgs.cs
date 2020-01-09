using System;

namespace Events
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(double percentage)
        {
            
            this.percentage = percentage;
        }
        public double percentage { get; set; }

    }
}
