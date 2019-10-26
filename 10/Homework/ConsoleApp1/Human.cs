namespace ConsoleApp1
{
    class Human
    {

        public string Name;
        public  int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }
        public int AfterFourYears
            => age + 4;
        
        public string Description
            => $"Name: {Name}, age in 4 years: {AfterFourYears}.";


    }

            

        
       
        
    
}
