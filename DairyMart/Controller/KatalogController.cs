using System.Data;
using DairyMart.Models;

namespace DairyMart.Controllers
{
    public class KatalogController
    {
        private Produk modelProduk = new Produk();

        public DataTable LoadKatalog()
        {
            return modelProduk.AmbilDataKatalog();
        }
    }
}