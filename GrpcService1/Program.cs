using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.ConfigurationData;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using AP_Theme_5.DataAcces;
using AP_Theme_5.DataAcces.Context;
using AutoMapper;
using GrpcService1.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;

public class GrpcProgram
{
    public static void Main( string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

        // Add services to the container.
        builder.Services.AddGrpc();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<GreeterService>();
        app.MapGrpcService<WorkerService>();
        app.MapGrpcService<MeasurementUnitService>();
        app.MapGrpcService<VariableService>();
        app.MapGrpcService<AlarmConfigurationService>();
        app.MapGrpcService<AlarmService>();
        app.MapGrpcService<AuditEventService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        builder.Services.AddMediatR(new MediatRServiceConfiguration()
        {
            AutoRegisterRequestProcessors = true
        }
        .RegisterServicesFromAssemblies(  typeof(AssemblyReference).Assembly));
           
        

        builder.Services.AddSingleton("Data Source=Data.Sqlite");
        builder.Services.AddScoped<ApplicationContext>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IVariableRepository>();
        builder.Services.AddScoped<IWorkerRepository>();
        builder.Services.AddScoped<IAlarmRepository>();
        builder.Services.AddScoped<IAuditEventRepository>();
        builder.Services.AddScoped<IMeasurementUnitRepository>();
        builder.Services.AddAutoMapper(typeof(GrpcProgram).Assembly );

        app.Run();
    }
}


