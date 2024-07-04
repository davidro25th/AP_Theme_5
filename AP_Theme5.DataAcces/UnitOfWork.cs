using AP_Theme_5.Contracts;
using AP_Theme_5.DataAcces.Context;
using Microsoft.EntityFrameworkCore;

namespace AP_Theme_5.DataAcces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
