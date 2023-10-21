using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PerfectMatch.Shared.Entities
{
    public class Appointment
    {
        public int Id { get; set; } 

        public string Date { get; set; }

        public string Hour { get; set; }

        public string Place { get; set; }

    }
}
