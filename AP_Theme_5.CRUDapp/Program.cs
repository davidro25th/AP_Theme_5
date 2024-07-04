using AP_Theme_5.Domain;
using AP_Theme_5.DataAcces.Context;
using Microsoft.EntityFrameworkCore;
using AP_Theme_5.Domain.Entities.Configuration_Data;
using AP_Theme_5.Domain.ValueObjects;
using AP_Theme_5.DataAcces.FluentConfigurations.Alarms;
using AP_Theme_5.Domain.Entities.HistoricData;
using AP_Theme_5.Domain.Types;
using System.Threading.Tasks.Dataflow;
using AP_Theme_5.DataAcces.Repositories.HistoricalData;
using AP_Theme_5.DataAcces;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.DataAccess.Tests.Utilities;
using AP_Theme_5.Contracts;
using AP_Theme_5.DataAcces.Repositories.ConfigurationData;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces.Repositories.Types;
namespace AP_Theme_5.CRUDapp;
internal class Program
{
    
    static void Main(string[] args)
    {
        ApplicationContext context = new ApplicationContext(
                ConnectionStringProvider.GetConnectionString());
        IAlarmRepository _alarmRepository;
        IVariableRepository _variableRepository;
        IWorkerRepository _workerRepository;
        IAuditEventRepository _auditEventRepository;
        IMeasurementUnitRepository _measurementUnitRepository;
        IUnitOfWork _unitOfWork;
        _alarmRepository = new AlarmRepository(context);        
        _auditEventRepository = new AuditEventRepository(context);
        _variableRepository = new VariableRepository(context);
        _workerRepository = new WorkerRepository(context);
        _measurementUnitRepository = new MeasurementUnitRepository(context);
        _unitOfWork = new UnitOfWork(context);
        Worker pepe = Worker.Create("98110307823");
        _workerRepository.AddWorker(pepe);
        _unitOfWork.SaveChanges();
        pepe.Firstname = "Pepe";
        pepe.Lastname = "Pepito";
        pepe.SetPhoneNumber("5358481764");
        _workerRepository.UpdateWorker(pepe);
        _unitOfWork.SaveChanges();
        Worker pepe1 = Worker.Create("69031615730");
        pepe1.Firstname = "Pepe1";
        pepe1.Lastname = "Pepito1";
        pepe1.SetPhoneNumber("5359446621");
        _workerRepository.AddWorker(pepe1);
        _unitOfWork.SaveChanges();
        List<Worker> workers = (List<Worker>)_workerRepository.GetAllWorkers();
        Worker pepe2 = _workerRepository.GetWorkerById(pepe.Id);
    }
}