using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();

    }
}
