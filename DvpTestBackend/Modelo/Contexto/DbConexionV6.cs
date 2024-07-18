using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    public partial class DbConexionV6 : DbContext
    {
        private DbConexionV6(string stringConexion)
        :base(stringConexion)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = 900;
        }

        public static DbConexionV6 Create()
        {
            return new DbConexionV6("name=DbConexionV6");
        }
    }
}
