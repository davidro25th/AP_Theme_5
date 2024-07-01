using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAccess.Tests.Utilities
{
    /// <summary>
    /// Proveedor de cadena de Conexion
    /// </summary>
    public static class ConnectionStringProvider
    {
        public static string GetConnectionString() => "Data.Source=Data.sqlite";
    }
}
