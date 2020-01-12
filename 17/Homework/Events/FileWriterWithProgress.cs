using System;
using System.IO;

namespace Events
{
    public class FileWriterWithProgress
    {
        public event EventHandler<WorkPerformedEventArgs> WritingPerformed;
        public event EventHandler WritingCompleted;

        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            if (percentageToFireEvent < 0 && percentageToFireEvent > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(percentageToFireEvent));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            using var file = File.OpenWrite(fileName);
            for (int i = 1; i < data.Length; i++)
            {
                file.WriteByte(data[i]);
                float percentage = default;
                if (percentage <= ((i + 1) / (float)data.Length))
                {
                    percentage = i * percentageToFireEvent * 100;
                    if (percentage < 100)
                    {
                        
                        WritingPerformed?.Invoke(this, new WorkPerformedEventArgs(percentage));
                    }
                }
            }
            WritingCompleted?.Invoke(this, null);
        }
    }
}
