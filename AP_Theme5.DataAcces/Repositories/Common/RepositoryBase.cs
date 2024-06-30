using AP_Theme_5.DataAcces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.Repositories.Common
{
    /// <summary>
    /// Clase base para los repositorios
    /// </summary>
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Contexto para el soporte de datos
        /// </summary>
        protected ApplicationContext _context;
        /// <summary>
        /// Las clases derivadas necesitan un contexto para construirse
        /// </summary>
        protected RepositoryBase(ApplicationContext _context) { }

    }
}
