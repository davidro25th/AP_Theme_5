using AP_Theme_5.Domain;
using AP_Theme_5.DataAcces.Context;
using Microsoft.EntityFrameworkCore;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.ValueObjects;
using AP_Theme_5.DataAcces.FluentConfigurations.Alarms;
using AP_Theme_5.Domain.Entities.HistoricData;

namespace AP_Theme_5.CRUDapp;
internal class Program
{
    static void Main(string[] args)
    {
        ApplicationContext appContext = new ApplicationContext("Data Source = ProgramdB.sqlite");
        if (!appContext.Database.CanConnect())
        {
            appContext.Database.Migrate();
        }
        Worker Pepe = Worker.Create("98110307823");
        Pepe.Firstname = "Pepe";
        Pepe.Lastname = "Gonzalez";
        Pepe.PhoneNumber = "+5358481764";
        appContext.Workers.Add(Pepe);
        appContext.SaveChanges();
        MeasurementUnit Temperatura = new MeasurementUnit("Celcius");
        Temperatura.UnitType = "Temperatura";
        Variable CalderaTemp = new Variable("0020");
        CalderaTemp.Name = "Temperatura de Caldera";
        CalderaTemp.MeasurementUnit = Temperatura;
        appContext.Variables.Add(CalderaTemp);
        appContext.SaveChanges();
        AlarmConfiguration AlarmaConfig1 = new AlarmConfiguration(45.03, CalderaTemp);
        Alarm Alarma1 = new Alarm(AlarmaConfig1);
        appContext.AuditEvents.Add(Alarma1);
        AuditEvent Auditoria1 = new AuditEvent("Para todo", Pepe);
        appContext.AuditEvents.Add(Auditoria1);
        Worker? WorkerFromAuditE = appContext.Set<Worker>().FirstOrDefault(v => v.Id == Auditoria1.WorkerId);
        Alarm? Alarma2 = appContext.Set<Alarm>().FirstOrDefault();
        CalderaTemp.Code = "0021";
        appContext.Variables.Update(CalderaTemp);
        Variable? CalderaTemp1 = appContext.Set<Variable>().FirstOrDefault(m => m.Id == CalderaTemp.Id);
        Console.WriteLine($"Codigo de la variable {CalderaTemp1.Code} ");
        appContext.SaveChanges();

    }
}