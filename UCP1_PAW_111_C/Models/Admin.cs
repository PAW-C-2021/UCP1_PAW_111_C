using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_111_C.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdAdmin { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
