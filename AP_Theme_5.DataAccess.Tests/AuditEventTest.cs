using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.HistoricalData;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAccess.Tests
{
    [TestClass]
    public class AuditEventTest
    {
        private IAuditEventRepository _auditEventRepository;
        private IUnitOfWork _unitOfWork;

        public AuditEventTest()
        {
            ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString());
            _auditEventRepository = new AuditEventRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Accionamiento de la Valvula de Control 2", 25/2/2024, "01062512345", "+53238456", "Pedro", "Pedro Pedro")]
        [DataRow("Paro de Emergencia del Sistema", 25/3/2024, "01062512346", "+53238423", "Pedro", "Pedro Pedro")]
        [TestMethod]
        public void Can_Add_AuditEvent(
            string action,
            DateTime ocurrence,
            string identityCard,
            string phone_number,
            string firstname,
            string lastname)

        {

            //Arrange
            Guid id = Guid.NewGuid();
            AuditEvent auditEvent = new AuditEvent( action, Worker.Create(identityCard)  );
            //TODO Add Remaining AuditEvent properties

            //Execute
            _auditEventRepository.AddAuditEvent(auditEvent);
            _unitOfWork.SaveChanges();

            //Assert
            AuditEvent? loadedAuditEvent = _auditEventRepository.GetAuditEventById(id);
            Assert.IsNotNull(loadedAuditEvent);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_AuditEvent_By_Id(int position)
        {
            //Arrange
            var auditEvents = _auditEventRepository.GetAllAuditEvents().ToList();
            Assert.IsNotNull(auditEvents);
            Assert.IsTrue(position < auditEvents.Count);
            AuditEvent auditEventToGet = auditEvents[position];

            //Execute
            AuditEvent? loadedAuditEvent = _auditEventRepository.GetAuditEventById(auditEventToGet.Id);

            //Assert
            Assert.IsNotNull(loadedAuditEvent);

        }

        public void Can_Not_Get_AuditEvent_By_Invalid_Id()
        {
            //Arrange

            //Execute
            AuditEvent? loadedAuditEvent = _auditEventRepository.GetAuditEventById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedAuditEvent);
        }
    }
}
