using System;

namespace Events
{
    public class FWWP : EventArgs
    {
        public FWWP(float pTFE)
        {
            
            this.pTFE = pTFE;
        }

       
        public float pTFE { get; set; }

    }
}
