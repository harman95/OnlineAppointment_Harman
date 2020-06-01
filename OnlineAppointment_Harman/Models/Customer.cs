using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineAppointment_Harman.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}