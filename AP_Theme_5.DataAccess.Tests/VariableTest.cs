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
    [TestClass]
    public class VariableTest
    {
        private IVariableRepository _variableRepository;
        private IUnitOfWork _unitOfWork;

        public VariableTest()
        {
            ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString() );
            _variableRepository = new VariableRepository(context);
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
            Guid id = Guid.NewGuid();
            Variable variable = new Variable(code);
            //TODO Add Remaining Variable properties

            //Execute
            _variableRepository.AddVariable(variable);
            _unitOfWork.SaveChanges();

            //Assert
            Variable? loadedVariable = _variableRepository.GetVariableById(id);
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

        public void Can_Not_Get_Variable_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Variable? loadedVariable = _variableRepository.GetVariableById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedVariable);
        }

    }
}
