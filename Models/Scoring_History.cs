using System;
using System.ComponentModel.DataAnnotations;


namespace ARIA_Net.Models
{
    public class Scoring_History
    {
        public int ID { get; set; }        
        public string Competition_Cd { get; set; }
        public string Project_Title { get; set; }
        public String NPI_Last_Name { get; set; }
        public string NPI_First_Name { get; set; }
        public byte Referee_Cd {get; set;}
        public String Reviewer_Last_Name {get; set; }
        public String Reviewer_First_Name {get; set; }
        public String Criteria_Name {get; set; }
        public double Score { get; set; }
        public string Comments {get; set; }

    }
}