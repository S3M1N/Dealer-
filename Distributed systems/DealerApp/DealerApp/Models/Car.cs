using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerApp.Models
{
    internal class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public DateTime Year { get; set; }
        public Decimal Price { get; set; }
        public bool Stat { get; set; }
    }
}
