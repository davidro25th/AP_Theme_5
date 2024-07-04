using AP_Theme_5.DataAcces.Context;
using AP_Theme_5.DataAcces.Repositories.Common;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.Domain.Types;
using System;

namespace AP_Theme_5.DataAcces.Repositories.Types
{
    /// <summary>
    /// Implementacion del Repositorio MeasurementUnit Repository
    /// </summary>
    public class MeasurementUnitRepository :
        RepositoryBase, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(ApplicationContext context) : base(context)
        {

        }
        /// <summary>
        /// Metodo para la adicion de una unidad de medida
        /// se valida que no exista otra unidad de medida con el mismo UnitName
        /// </summary>
        /// <param name="measurementUnit"></param>
        public void AddMeasurementUnit(MeasurementUnit measurementUnit)
        {
           _context.MeasurementUnits.Add(measurementUnit);
        }

        public void DeleteMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _context.MeasurementUnits.Remove(measurementUnit);
        }

        public IEnumerable<MeasurementUnit> GetAllMeasurementUnits()
        {
            return _context.MeasurementUnits.ToList();
        }

        public MeasurementUnit? GetMeasurementUnitById(Guid id)
        {
            return _context.MeasurementUnits.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _context.MeasurementUnits.Update(measurementUnit);
        }
    }
}
