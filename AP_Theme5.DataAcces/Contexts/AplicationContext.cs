using Microsoft.EntityFrameworkCore;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.Entities.Types;

namespace AP_Theme_5.DataAcces
{

    public class AplicationContext : DbContext
    {
        #region Tables
        /// <summary>
        /// Tabla de Unidades de Medida
        /// </summary>       
        public DbSet<MeasurementUnit> measurementUnits { get; set; }
        /// <summary>
        /// Tabla de Variables
        /// </summary>
        public DbSet<Variable> Variables { get; set; }
        /// <summary>
        /// Tabla de Trabajadores
        /// </summary>
        public DbSet<Worker> Workers { get; set; }
        /// <summary>
        /// Tabla de Alarmas
        /// </summary>      
        public DbSet<Alarm> Alarms { get; set; }
        /// <summary>
        /// Tabla de Eventos de Auditoria
        /// </summary>
        public DbSet<AuditEvent> AuditEvents { get; set; }
        #endregion
        
        /// <summary>
        /// Constructor requerido por Entity Framework
        /// </summary>
        public AplicationContext() { }
        /// <summary>
        /// Constructor de Aplication Context
        /// </summary>
        public AplicationContext(string conectionString)
            : base(GetOptions(conectionString))
        {
        }

        public AplicationContext(DbContextOptions<AplicationContext> options):
            base(options) 
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}