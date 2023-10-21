using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMatch.Shared.Entities
{
    public class Ubication
    {

        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Length { get; set; }

        public string PlaceName { get; set; }   
    }
}
