using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.ConfigurationData;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AP_Theme_5.DataAcces.Repositories.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.DataAccess.Tests
{
    [TestClass]
    public class VariableTest
    {
        private IVariableRepository _variableRepository;
        private IUnitOfWork _unitOfWork;
        private IMeasurementUnitRepository _measurementUnitRepository;

        public VariableTest()
        {
            ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString() );
            _variableRepository = new VariableRepository(context);
            _measurementUnitRepository = new MeasurementUnitRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Temperatura del Tanque 2", "TCeTk2", "Temperatura", "Celsius")]
        [DataRow("Presion en la Caldera 4", "PBCl4", "Presion", "Bar")]
        [TestMethod]
        public void Can_Add_Variable(
            string name,
            string code,
            string unitType,
            string unitName)
        {

            //Arrange            
            MeasurementUnit measurementUnit = new MeasurementUnit(unitName, unitType);            
            Variable variable = new Variable(name, code, measurementUnit);          


            //Execute
            _measurementUnitRepository.AddMeasurementUnit(measurementUnit);
            _variableRepository.AddVariable(variable);
            _unitOfWork.SaveChanges();

            //Assert
            Variable? loadedVariable = _variableRepository.GetVariableById(variable.Id);
            Assert.IsNotNull(loadedVariable);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_Variable_By_Id(int position)
        {
            //Arrange
            var variables = _variableRepository.GetAllVariables().ToList();
            Assert.IsNotNull(variables);
            Assert.IsTrue(position < variables.Count);
            Variable variableToGet = variables[position];

            //Execute
            Variable? loadedVariable = _variableRepository.GetVariableById(variableToGet.Id);

            //Assert
            Assert.IsNotNull(loadedVariable);

        }
        [TestMethod]
        public void Can_Not_Get_Variable_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Variable? loadedVariable = _variableRepository.GetVariableById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedVariable);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Variable (int position)
        {
            //Arrange
            var Variables = _variableRepository.GetAllVariables();
            Assert.IsNotNull(Variables);
            var count = Variables.Count();
            var variable = Variables.ElementAt(position);
            Assert.IsNotNull(variable);

            //Execute
            _variableRepository.DeleteVariable(variable);
            _unitOfWork.SaveChanges();

            //Assert
            Variables = _variableRepository.GetAllVariables();
            Assert.AreEqual(count - 1, Variables.Count());
            var DeletedWorker = _variableRepository.GetVariableById(variable.Id);
            Assert.IsNull(DeletedWorker);
        }
        [DataRow(0, "Caldera")]
        [TestMethod]
        public void Can_Update_Variable(int position, string name)
        {
            //Arrange
            var Variables = _variableRepository.GetAllVariables();
            Assert.IsNotNull(Variables);
            var variable = Variables.ElementAt(position);
            Assert.IsNotNull(variable);

            //Execute
            variable.Name = name;
            _variableRepository.UpdateVariable(variable);
            _unitOfWork.SaveChanges();

            //Assert
            var updatedVariable = _variableRepository.GetVariableById(variable.Id);
            Assert.IsNotNull(updatedVariable);
            Assert.AreEqual(updatedVariable.Name, variable.Name);
        }

    }
}
