using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.HistoricalData;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.Entities.Types;
using AP_Theme_5.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAccess.Tests
{
    [TestClass]
    public class AlarmTest
    {
        public IAlarmRepository _alarmRepository;
        public IUnitOfWork _unitOfWork;

        public AlarmTest()
        {
            ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString());
            _alarmRepository = new AlarmRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }


        [DataRow(15.4, Priority.High, 15 / 12 / 2024, 16 / 12 / 2024,
            "Temperatura del Tanque 2", "PBCl2", "Temperatura", "Celsius")]
        [DataRow(2, Priority.Low, 15 / 8 / 2023, 16 / 8 / 2023,
            "Presion en la Caldera 3", "PBCl3", "Presion", "Bar")]

        [TestMethod]
        public void Can_Add_Alarm(
            double out_of_range,
            Priority Priority,
            string name,
            string code,
            string unitType,
            string unitName)
        {

            //Arrange
            Guid id = Guid.NewGuid();
            Alarm alarm = new Alarm(new AlarmConfiguration(
                out_of_range, new Variable(code)));


            //TODO Add Remaining Alarm properties

            //Execute
            _alarmRepository.AddAlarm(alarm);
            _unitOfWork.SaveChanges();

            //Assert
            Alarm? loadedAlarm = _alarmRepository.GetAlarmById(id);
            Assert.IsNotNull(loadedAlarm);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_Alarm_By_Id(int position)
        {
            //Arrange
            var alarms = _alarmRepository.GetAllAlarms().ToList();
            Assert.IsNotNull(alarms);
            Assert.IsTrue(position < alarms.Count);
            Alarm alarmToGet = alarms[position];

            //Execute
            Alarm? loadedAlarm = _alarmRepository.GetAlarmById(alarmToGet.Id);

            //Assert
            Assert.IsNotNull(loadedAlarm);

        }

        public void Can_Not_Get_Alarm_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Alarm? loadedAlarm = _alarmRepository.GetAlarmById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedAlarm);
        }
    }
}
