using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTripster.ViewModels
{
    internal class SessionViewModel
    { 
        public int id { get; set; } 
        public string CategoryName { get; set; }

        public string TrainerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Capacity { get; set; }
        public int AvailableSlots { get; set; }



#region computed properties

      

        public string DateDisplay => $"{StartDate:MMM dd, yyyy} - {EndDate:MMM dd, yyyy}";

        public string TimeDisplay => $"{StartDate:hh:mm tt} - {EndDate:hh:mm tt}";
        public TimeSpan Duration => EndDate - StartDate;

        public string Status
        {
            get
            {
                if (StartDate>DateTime.Now)
                {
                    return "Upcoming";
                }
                else if (StartDate<=DateTime.Now && EndDate>=DateTime.Now)
                {
                    return "Ongoing";
                }
                else
                {
                    return "Completed";
                }
            }


        }




        #endregion


    }
}
