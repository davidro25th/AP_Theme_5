using AP_Theme_5.Domain;
using AP_Theme_5.DataAcces.Context;
using Microsoft.EntityFrameworkCore;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.ValueObjects;

namespace AP_Theme_5.CRUDapp;
internal class Program
{
    static void Main(string[] args)
    {
        AplicationContext appContext = new AplicationContext("Data Source = ProgramdB.sqlite");
        if (!appContext.Database.CanConnect())
        {
            appContext.Database.Migrate();
        }
        Worker Pepe = Worker.Create("98110307823");
        Pepe.Firstname = "Pepe";
        Pepe.Lastname = "Gonzalez";
        Pepe.PhoneNumber = "+5358481764";
        appContext.Workers.Add(Pepe);
        MeasurementUnit Temperatura = new MeasurementUnit("Celcius");
        Temperatura.UnitType = "Temperatura";
        Variable CalderaTemp = new Variable("0020");
        CalderaTemp.Name = "Temperatura de Caldera";
        CalderaTemp.MeasurementUnit = Temperatura;
        appContext.Variables.Add(CalderaTemp);
        appContext.SaveChanges();
    }
}