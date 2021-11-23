using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_111_C.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdKonsumen { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdProduk { get; set; }
        public string TotalBiaya { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Konsuman IdKonsumenNavigation { get; set; }
        public virtual Produk IdProdukNavigation { get; set; }
    }
}
