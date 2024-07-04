using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.HistoricalData;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.Entities.Types;
using AP_Theme_5.Domain.Types;
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


        [DataRow(15.4, Priority.High,"Temperatura del Tanque 2", "PBCl2", "Temperatura")]
        [DataRow(2, Priority.Low,"Presion en la Caldera 3", "PBCl3", "Presion")]

        [TestMethod]
        public void Can_Add_Alarm(
            double out_of_range,
            Priority Priority,            
            string name,
            string code,
            string unitType)
        {

            //Arrange
            Guid id = Guid.NewGuid();
            string unitName = "Celcius";
            Alarm alarm = new Alarm(new AlarmConfiguration(
                out_of_range, new Variable(name, code, new MeasurementUnit(unitName, unitType))));
            alarm.Id = id;
            alarm.AlarmConfiguration.Priority = Priority;
            alarm.AlarmConfiguration.AlarmVariable.Id = Guid.NewGuid();
            alarm.Recovery();
           

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
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Alarm(int position)
        {
            //Arrange
            var Alarms = _alarmRepository.GetAllAlarms();
            Assert.IsNotNull(Alarms);
            var count = Alarms.Count();
            var alarm = Alarms.ElementAt(position);
            Assert.IsNotNull(alarm);

            //Execute
            _alarmRepository.DeleteAlarm(alarm);
            _unitOfWork.SaveChanges();

            //Assert
            Alarms = _alarmRepository.GetAllAlarms();
            Assert.AreEqual(count - 1, Alarms.Count());
            var Deletedalarm = _alarmRepository.GetAlarmById(alarm.Id);
            Assert.IsNull(Deletedalarm);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Update_Alarm(int position)
        {
            //Arrange
            var Alarms = _alarmRepository.GetAllAlarms();
            Assert.IsNotNull(Alarms);
            var alarm = Alarms.ElementAt(position);
            Assert.IsNotNull(alarm);

            //Execute
            alarm.Recovery();
            _alarmRepository.UpdateAlarm(alarm);
            _unitOfWork.SaveChanges();

            //Assert
            var updatedAlarm = _alarmRepository.GetAlarmById(alarm.Id);
            Assert.IsNotNull(updatedAlarm);
            Assert.AreEqual(updatedAlarm.RecoveryDate, alarm.RecoveryDate);
        }
    }
}
