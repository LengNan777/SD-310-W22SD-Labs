using System;
using System.Collections.Generic;

namespace Lab1.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string EquipmentName { get; set; } = null!;
        public int Amount { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
