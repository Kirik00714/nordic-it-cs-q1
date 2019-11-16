using System;

namespace Events
{
    public class FileWriterWithProgress
    { 
        public event EventHandler<FWWP> WritingPerformed;
        public event EventHandler WritingCompleted;
        
        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {
                
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new ArgumentNullException(nameof(fileName));
                }
                if (percentageToFireEvent < 0 && percentageToFireEvent> 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(percentageToFireEvent));
                }
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }

                for (int i = 0; i < data.Length; i++)
                {
                    float result = i * percentageToFireEvent * 100;
                    if (result > 100)
                    {
                        break;
                    }
                    if (i % percentageToFireEvent != 0)
                    {
                        WritingPerformed?.Invoke(this, new FWWP(result));
                    }
                }

                WritingCompleted?.Invoke(this, null);
            
        }
    }
}
