using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_111_C.Models
{
    public partial class Produk
    {
        public Produk()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public int? Jumlah { get; set; }
        public string Harga { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
