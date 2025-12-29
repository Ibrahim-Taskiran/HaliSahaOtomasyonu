using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace HaliSahaOtomasyon 
{
    class SqlBaglantisi
    {
        public SqlConnection Baglanti()
        {



            // Başındaki @ işareti çok önemli, çünkü sunucu adında "\" işareti var.
            SqlConnection baglan = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SosyalHalisahaDB;Integrated Security=True");

            baglan.Open();
            return baglan;
        }
    }
}