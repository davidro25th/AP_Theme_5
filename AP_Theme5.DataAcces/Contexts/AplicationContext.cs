using AP_Theme_5.DataAcces.FluentConfigurations.Alarms;
using AP_Theme_5.DataAcces.FluentConfigurations.ConfigurationData;
using AP_Theme_5.DataAcces.FluentConfigurations.HistoricalData;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AP_Theme_5.DataAcces.Context
{

    public class AplicationContext : DbContext
    {
        #region Tables
        /// <summary>
        /// Tabla de Unidades de Medida
        /// </summary>       
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
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
        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(
                new DbContextOptionsBuilder(), connectionString).Options;
        }
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

        public AplicationContext(DbContextOptions<AplicationContext> options) :
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

            #region Base classes mapping

            modelBuilder.Entity<Variable>().ToTable("Variables");

            modelBuilder.Entity<Worker>().ToTable("Workers");

            modelBuilder.Entity<Alarm>().ToTable("Alarms");

            modelBuilder.Entity<AuditEvent>().ToTable("AuditEvent");

            

            #endregion

            modelBuilder.ApplyConfiguration(new VariableEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlarmEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuditEventEntityTypeConfiguration());
        }



    }
}