using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMatch.Shared.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Description { get; set;}

        public string Date { get; set;}
    }
}
