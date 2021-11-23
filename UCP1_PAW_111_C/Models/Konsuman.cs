using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_111_C.Models
{
    public partial class Konsuman
    {
        public Konsuman()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdKonsumen { get; set; }
        public string Nama { get; set; }
        public string NoTelpon { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
