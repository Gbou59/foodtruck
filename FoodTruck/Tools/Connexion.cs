using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Tools
{
    class Connexion
    {
        private static SqlConnection _instance;
        
        public static SqlConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance=new SqlConnection(@"Data Source=(LocalDb)\foodtrucksql;Integrated Security=True");
                }
                return Instance;
            }
        }

        private Connexion() { }

    }
}
