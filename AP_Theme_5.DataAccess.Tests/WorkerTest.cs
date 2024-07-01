using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.ConfigurationData;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAccess.Tests
{
    public class WorkerTest
    {
        private IWorkerRepository _workerRepository;
        private IUnitOfWork _unitOfWork;

        public WorkerTest()
        {
            DataAcces.Context.ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString());
            _workerRepository = new WorkerRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("01062587963", "+53654569", "Juana", "de Arco")]
        [DataRow("01062587964", "+53654560", "Juan", "de los Palostres")]
        [TestMethod]
        public void Can_Add_Worker(
            string identityCard,
            string phone_number,
            string firstname,
            string lastname)
        {

            //Arrange
            Guid id = Guid.NewGuid();
            Worker worker = Worker.Create(identityCard);
            //TODO Add Remaining Worker properties

            //Execute
            _workerRepository.AddWorker(worker);
            _unitOfWork.SaveChanges();

            //Assert
            Worker? loadedWorker = _workerRepository.GetWorkerById(id);
            Assert.IsNotNull(loadedWorker);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_Worker_By_Id(int position)
        {
            //Arrange
            var workers = _workerRepository.GetAllWorkers().ToList();
            Assert.IsNotNull(workers);
            Assert.IsTrue(position < workers.Count);
            Worker workerToGet = workers[position];

            //Execute
            Worker? loadedWorker = _workerRepository.GetWorkerById(workerToGet.Id);

            //Assert
            Assert.IsNotNull(loadedWorker);

        }

        public void Can_Not_Get_Worker_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Worker? loadedWorker = _workerRepository.GetWorkerById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedWorker);
        }
    }
}

//TODO Clean the Code (Test Classes and Repositories)
//TODO Fix a typo in Domain.HistoricData (Should be "HistoricalData")
//TODO Fix a missmatch in Domain: namespace HistoricalData and "Historical Data" Folder name