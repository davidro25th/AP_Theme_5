using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.HistoricalData;
using AP_Theme_5.DataAcces.Repositories.Types;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAccess.Tests
{
    [TestClass]
    public class MeasurementUnitTest
    {
        private IUnitOfWork _unitOfWork;
        private IMeasurementUnitRepository _measurementUnitRepository;

        public MeasurementUnitTest()
        {
            ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString());           
            _measurementUnitRepository = new MeasurementUnitRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Temperatura", "Celsius")]
        [DataRow("Presion", "Bar")]
        [TestMethod]
        public void Can_Add_MeasurementUnit(
            string unitName,
            string unitType)
        {

            //Arrange            
            MeasurementUnit measurementUnit = new MeasurementUnit(unitName, unitType);

            //Execute
            _measurementUnitRepository.AddMeasurementUnit(measurementUnit);
            _unitOfWork.SaveChanges();

            //Assert
            MeasurementUnit? loadedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(measurementUnit.Id);
            Assert.IsNotNull(loadedMeasurementUnit);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_MeasurementUnit_By_Id(int position)
        {
            //Arrange
            var measurementUnit = _measurementUnitRepository.GetAllMeasurementUnits().ToList();
            Assert.IsNotNull(measurementUnit);
            Assert.IsTrue(position < measurementUnit.Count);
            MeasurementUnit measurementUnitToGet = measurementUnit[position];

            //Execute
            MeasurementUnit? loadedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(measurementUnitToGet.Id);

            //Assert
            Assert.IsNotNull(loadedMeasurementUnit);

        }
        [TestMethod]
        public void Can_Not_Get_MeasurementUnit_By_Invalid_Id()
        {
            //Arrange

            //Execute
            MeasurementUnit? loadedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedMeasurementUnit);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_MeasurementUnit(int position)
        {
            //Arrange
            var MeasurementUnits = _measurementUnitRepository.GetAllMeasurementUnits();
            Assert.IsNotNull(MeasurementUnits);
            var count = MeasurementUnits.Count();
            var measurementUnit = MeasurementUnits.ElementAt(position);
            Assert.IsNotNull(measurementUnit);

            //Execute
            _measurementUnitRepository.DeleteMeasurementUnit(measurementUnit);
            _unitOfWork.SaveChanges();

            //Assert
            MeasurementUnits = _measurementUnitRepository.GetAllMeasurementUnits();
            Assert.AreEqual(count - 1, MeasurementUnits.Count());
            var DeletedWorker = _measurementUnitRepository.GetMeasurementUnitById(measurementUnit.Id);
            Assert.IsNull(DeletedWorker);
        }
        [DataRow(0, "Presion")]
        [TestMethod]
        public void Can_Update_MeasurementUnit(int position, string Type)
        {
            //Arrange
            var MeasurementUnits = _measurementUnitRepository.GetAllMeasurementUnits();
            Assert.IsNotNull(MeasurementUnits);
            var measurementUnit = MeasurementUnits.ElementAt(position);
            Assert.IsNotNull(measurementUnit);

            //Execute
            measurementUnit.UnitType = Type;
            _measurementUnitRepository.UpdateMeasurementUnit(measurementUnit);
            _unitOfWork.SaveChanges();

            //Assert
            var updatedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(measurementUnit.Id);
            Assert.IsNotNull(updatedMeasurementUnit);
            Assert.AreEqual(updatedMeasurementUnit.UnitType, measurementUnit.UnitType);
        }
    }
}
