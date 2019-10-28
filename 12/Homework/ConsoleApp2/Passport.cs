using System;

namespace ConsoleApp2
{
    class Passport : BaseDocument
    {


        public Passport(string country, string personName, DateTime issueDate, string number) :
            base("Passport", number, issueDate)

        {
            Country = country;
            PersonName = personName;
        }


        public virtual string Country { get; set; }
        public virtual string PersonName { get; set; }
        public override string Description
        {
            get
            {
                return $"{base.Description}, country {Country}, name is {PersonName}";
            }
        }
        public void ChangeIssueDate(DateTime newIssueDate)
        {
            IssueDate = newIssueDate;
        }

    }
}
