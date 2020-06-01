using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAppointment_Harman.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        [Display(Name = "Service")]
        public int ServiceMstID { get; set; }
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        [Display(Name = "Slot")]
        public int SlotTimeMstID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public Nullable<DateTime> Date { get; set; }

        public List<AppoinntmentCancel> AppoinntmentCancels { get; set; }
        public List<ProcessMst> ProcessMsts { get; set; }
        public ServiceMst ServiceMst { get; set; }
        public Customer Customer { get; set; }
        public SlotTimeMst SlotTimeMst { get; set; }
    }
}