using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAppointment_Harman.Models
{
    public class ProcessMst
    {
        public int ID { get; set; }
        public int AppointmentID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Cancel Date")]
        public Nullable<DateTime> ProcessDate { get; set; }
        public string Remarks { get; set; }

        public Appointment Appointment { get; set; }
    }
}