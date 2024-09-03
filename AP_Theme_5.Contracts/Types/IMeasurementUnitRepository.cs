using AP_Theme_5.Domain.Entities.Configuration_Data;

namespace AP_Theme_5.Contracts.Types
{
    /// <summary>
    /// Describe las funcionalidades necesarias para dar persistencia a un objeto del tipo MeasurementUnit
    /// </summary>
    public interface IMeasurementUnitRepository
    {
        /// <summary>
        /// Agrega una unidad de medida al soporte de datos
        /// </summary>
        /// <param name="measurementUnit"></param>
        void AddMeasurementUnit(MeasurementUnit measurementUnit);
        /// <summary>
        /// Obtiene una unidad de medida de la base de datos teniendo su Id
        /// </summary>
        /// <param name="measurementUnitId"></param>
        /// <returns></returns>
        MeasurementUnit? GetMeasurementUnitById(Guid measurementUnitId);
        /// <summary>
        /// Obtiene Todas las unidades de medida de la base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<MeasurementUnit> GetAllMeasurementUnits();
        /// <summary>
        /// Actualiza una unidad de medida en la base de datos
        /// </summary>
        /// <param name="measurementUnit"></param>
        void UpdateMeasurementUnit(MeasurementUnit measurementUnit);
        /// <summary>
        /// Elimina una unidad de medida de la base de datos
        /// </summary>
        /// <param name="measurementUnit"></param>
        void DeleteMeasurementUnit(MeasurementUnit measurementUnit);
    }
}
