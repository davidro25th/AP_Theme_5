using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.Common;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAcces.Repositories.ConfigurationData
{
    /// <summary>
    /// Implementacion del Repositorio Worker Repository
    /// </summary>
    public class WorkerRepository :
        RepositoryBase, IWorkerRepository
    {
        public WorkerRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddWorker(Worker worker)
        {
           _context.Workers.Add(worker);
        }

        public void DeleteWorker(Worker worker)
        {
            _context.Workers.Remove(worker);
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _context.Workers.ToList();
        }

        public Worker? GetWorkerById(Guid id)
        {
            return _context.Workers.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateWorker(Worker worker)
        {
            _context.Workers.Update(worker);
        }
    }
}
