using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Shared.Domain
{
    public class Vehicle : BaseDomainModel
    {
        public int Year { get; set; }
        public string LicensePlateNumber { get; set; }
        public int MakeID { get; set; }
        public virtual Make Make { get; set; }
        public int ModelID { get; set; }
        public virtual Model Model { get; set; }
        public int ColourID { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }

}
