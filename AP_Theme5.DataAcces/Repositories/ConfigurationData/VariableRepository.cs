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
    /// Implementacion del Repositorio Variable Repository
    /// </summary>
    public class VariableRepository :
        RepositoryBase, IVariableRepository
    {
        public VariableRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddVariable(Variable variable)
        {
            _context.Variables.Add(variable);
        }

        public void DeleteVariable(Variable variable)
        {
            _context.Variables.Remove(variable);
        }

        public IEnumerable<Variable> GetAllVariables()
        {
            return _context.Variables.ToList();
        }

        public Variable? GetVariableById(Guid id)
        {
            return _context.Variables.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateVariable(Variable variable)
        {
            _context.Variables.Update(variable);
        }
    }
}
