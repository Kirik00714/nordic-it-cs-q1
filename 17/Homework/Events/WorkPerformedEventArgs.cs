using System;

namespace Events
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(float percentage)
        {
            
            this.percentage = percentage;
        }
        public float percentage { get; set; }

    }
}
