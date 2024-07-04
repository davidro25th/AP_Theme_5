using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.HistoricalData;
using AP_Theme_5.DataAcces.Repositories.Types;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.Types;
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
        private IMeasurementUnitRepository _measurementUnitRepository;
        private IUnitOfWork _unitOfWork;

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
            string unitType,
            string unitName)
        {

            //Arrange
            Guid id = new Guid();
            MeasurementUnit measurementUnit = new MeasurementUnit(unitType, unitName);
            measurementUnit.Id = id;

            //MeasurementUnit measurementUnit = new MeasurementUnit(unitName);
            // measurementUnit.UnitType = unitType;
            //MeasurementUnit MeasurementUnit = new MeasurementUnit(code);
            // MeasurementUnit.Name = name;
            //MeasurementUnit.MeasurementUnit = measurementUnit;
            //TODO Add Remaining MeasurementUnit properties(done)**

            //Execute
            _measurementUnitRepository.AddMeasurementUnit(measurementUnit);
            _unitOfWork.SaveChanges();

            //Assert
            MeasurementUnit? loadedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(id);
            Assert.IsNotNull(loadedMeasurementUnit);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_MeasurementUnit_By_Id(int position)
        {
            //Arrange
            var MeasurementUnits = _measurementUnitRepository.GetAllMeasurementUnits().ToList();
            Assert.IsNotNull(MeasurementUnits);
            Assert.IsTrue(position < MeasurementUnits.Count);
            MeasurementUnit MeasurementUnitToGet = MeasurementUnits[position];

            //Execute
            MeasurementUnit? loadedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(MeasurementUnitToGet.Id);

            //Assert
            Assert.IsNotNull(loadedMeasurementUnit);

        }

        public void Can_Not_Get_MeasurementUnit_By_Invalid_Id()
        {
            //Arrange

            //Execute
            MeasurementUnit? loadedMeasurementUnit = _measurementUnitRepository.GetMeasurementUnitById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedMeasurementUnit);
        }
    }
}
