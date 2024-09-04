using AP_Theme_5.GrpcProtos;
using Grpc.Net.Client;


namespace AP_Theme_5.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5001", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }


            var client0 = new AP_Theme_5.GrpcProtos.MeasurementUnit.MeasurementUnitClient(channel);
            var client1 = new AP_Theme_5.GrpcProtos.Variable.VariableClient(channel);
            var client2 = new AP_Theme_5.GrpcProtos.AlarmConfiguration.AlarmConfigurationClient(channel);
            var client3 = new AP_Theme_5.GrpcProtos.Alarm.AlarmClient(channel);
            var client4 = new AP_Theme_5.GrpcProtos.Worker.WorkerClient(channel);
            var client5 = new AP_Theme_5.GrpcProtos.AuditEvent.AuditEventClient(channel);


            Console.WriteLine("Presione una tecla para crear una unidad de medida");
            Console.ReadKey();
            var createResponse = client0.CreateMeasurementUnit(new CreateMeasurementUnitRequest() { Unitname = "celcius", Unittype = "Temp" });
            if (createResponse is null)
            {
                Console.WriteLine("Cannot create measurement unit");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener la unidad de medida");
            Console.ReadKey();
            var getResponse = client0.GetMeasurementUnit(new GetRequest() { Id = createResponse.Id });
            if (getResponse.MeasurementUnit is null)
            {
                Console.WriteLine("Cannot get Measurement Unit");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse.MeasurementUnit.Unittype} {getResponse.MeasurementUnit.Unitname}");

            }

            Console.WriteLine("Presione una tecla para modificar la unidad de medida");
            Console.ReadKey();
            createResponse.Unitname = "Kelvin";
            client0.UpdateMeasurementUnit(createResponse);

            var updatedGetResponse = client0.GetMeasurementUnit(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null && updatedGetResponse.KindCase == NullableMeasurementUnitDTO.KindOneofCase.MeasurementUnit && updatedGetResponse.MeasurementUnit.Unitname == "Kelvin")
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la unidad de medida");
            Console.ReadKey();

            client0.DeleteMeasurementUnit(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client0.GetMeasurementUnit(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null || deletedGetResponse.KindCase != NullableMeasurementUnitDTO.KindOneofCase.MeasurementUnit)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            Console.WriteLine("Presione una tecla para crear una Variable");
            Console.ReadKey();
            var createResponse1 = client1.CreateVariable(new CreateVariableRequest() { Code = "011014", Name = "Var", Measurementunit = createResponse });
            if (createResponse1 is null)
            {
                Console.WriteLine("Cannot create Variable");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener la variable");
            Console.ReadKey();
            var getResponse1 = client1.GetVariable(new GetRequest() { Id = createResponse.Id });
            if (getResponse1.Variable is null)
            {
                Console.WriteLine("Cannot get Variable");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse1.Variable.Name} {getResponse1.Variable.Code} {getResponse1.Variable.Measurementunit}");

            }

            Console.WriteLine("Presione una tecla para modificar la variable");
            Console.ReadKey();
            createResponse1.Name = "arv";
            client1.UpdateVariable(createResponse1);

            var updatedGetResponse1 = client1.GetVariable(new GetRequest() { Id = createResponse1.Id });
            if (updatedGetResponse1 is not null && updatedGetResponse1.KindCase == NullableVariableDTO.KindOneofCase.Variable && updatedGetResponse1.Variable.Name == "arv")
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la variable");
            Console.ReadKey();

            client1.DeleteVariable(new DeleteRequest() { Id = createResponse1.Id });
            var deletedGetResponse1 = client1.GetVariable(new GetRequest() { Id = createResponse1.Id });
            if (deletedGetResponse1 is null || deletedGetResponse1.KindCase != NullableVariableDTO.KindOneofCase.Variable)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            Console.WriteLine("Presione una tecla para crear una configuracion de alarma");
            Console.ReadKey();
            var createResponse2 = client2.CreateAlarmConfiguration(new CreateAlarmConfigurationRequest() { Alarmvariable = createResponse1, Outofrange = 25 });
            if (createResponse2 is null)
            {
                Console.WriteLine("Cannot create Alarm Configuration");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener la configuracion de alarma");
            Console.ReadKey();
            var getResponse2 = client2.GetAlarmConfiguration(new GetRequest() { });
            if (getResponse1.Variable is null)
            {
                Console.WriteLine("Cannot get Alarm Configuration");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse2.Alarmconfiguration.Alarmvariable} {getResponse2.Alarmconfiguration.Outofrange}");

            }

            Console.WriteLine("Presione una tecla para modificar la configuracion de alarma");
            Console.ReadKey();
            createResponse2.Outofrange = 10;
            client2.UpdateAlarmConfiguration(createResponse2);

            var updatedGetResponse2 = client2.GetAlarmConfiguration(new GetRequest() { });
            if (updatedGetResponse2 is not null && updatedGetResponse2.KindCase == NullableAlarmConfigurationDTO.KindOneofCase.Alarmconfiguration && updatedGetResponse2.Alarmconfiguration.Outofrange == 10)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la configuracion de alarma");
            Console.ReadKey();

            client2.DeleteAlarmConfiguration(new DeleteRequest() { });
            var deletedGetResponse2 = client2.GetAlarmConfiguration(new GetRequest() { });
            if (deletedGetResponse2 is null || deletedGetResponse2.KindCase != NullableAlarmConfigurationDTO.KindOneofCase.Alarmconfiguration)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            Console.WriteLine("Presione una tecla para crear una alarma");
            Console.ReadKey();
            var createResponse3 = client3.CreateAlarm(new CreateAlarmRequest() { Alarmconfiguration = createResponse2 });
            if (createResponse3 is null)
            {
                Console.WriteLine("Cannot create Alarm");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener la alarma");
            Console.ReadKey();
            var getResponse3 = client3.GetAlarm(new GetRequest() { Id = createResponse3.Id });
            if (getResponse3.Alarm is null)
            {
                Console.WriteLine("Cannot get Alarm");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse3.Alarm.Alarmconfiguration}");

            }

            Console.WriteLine("Presione una tecla para modificar la alarma");
            Console.ReadKey();
            createResponse3.Alarmconfiguration.Outofrange = 10;
            client2.UpdateAlarmConfiguration(createResponse2);

            var updatedGetResponse3 = client3.GetAlarm(new GetRequest() { Id = createResponse3.Id });
            if (updatedGetResponse3 is not null && updatedGetResponse3.KindCase == NullableAlarmDTO.KindOneofCase.Alarm && updatedGetResponse3.Alarm.Alarmconfiguration.Outofrange == 10)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la alarma");
            Console.ReadKey();

            client3.DeleteAlarm(new DeleteRequest() { Id = createResponse3.Id });
            var deletedGetResponse3 = client3.GetAlarm(new GetRequest() { Id = createResponse3.Id });
            if (deletedGetResponse3 is null || deletedGetResponse3.KindCase != NullableAlarmDTO.KindOneofCase.Alarm)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            Console.WriteLine("Presione una tecla para crear un trabajador");
            Console.ReadKey();
            var createResponse4 = client4.CreateWorker(new CreateWorkerRequest() { IdentityCard = "01101464003" });
            if (createResponse4 is null)
            {
                Console.WriteLine("Cannot create Worker");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener el trabajador");
            Console.ReadKey();
            var getResponse4 = client4.GetWorker(new GetRequest() { Id = createResponse4.Id });
            if (getResponse4.Worker is null)
            {
                Console.WriteLine("Cannot get Worker");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse4.Worker.IdentityCard}");

            }

            Console.WriteLine("Presione una tecla para modificar el trabajador");
            Console.ReadKey();
            createResponse4.IdentityCard = "01101464005";
            client4.UpdateWorker(createResponse4);

            var updatedGetResponse4 = client4.GetWorker(new GetRequest() { Id = createResponse4.Id });
            if (updatedGetResponse4 is not null && updatedGetResponse4.KindCase == NullableWorkerDTO.KindOneofCase.Worker && updatedGetResponse4.Worker.IdentityCard == "01101464005")
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar el trabajador");
            Console.ReadKey();

            client4.DeleteWorker(new DeleteRequest() { Id = createResponse4.Id });
            var deletedGetResponse4 = client4.GetWorker(new GetRequest() { Id = createResponse4.Id });
            if (deletedGetResponse4 is null || deletedGetResponse4.KindCase != NullableWorkerDTO.KindOneofCase.Worker)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            Console.WriteLine("Presione una tecla para crear un evento de auditoria");
            Console.ReadKey();
            var createResponse5 = client5.CreateAuditEvent(new CreateAuditEventRequest() { Worker = createResponse4, Action = "Cierre de una valvula" });
            if (createResponse5 is null)
            {
                Console.WriteLine("Cannot create AuditEvent");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener el evento");
            Console.ReadKey();
            var getResponse5 = client5.GetAuditEvent(new GetRequest() { Id = createResponse5.Id });
            if (getResponse5.Auditevent is null)
            {
                Console.WriteLine("Cannot get AuditEvent");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa {getResponse5.Auditevent.Worker} {getResponse5.Auditevent.Action}");

            }

            Console.WriteLine("Presione una tecla para modificar el evento");
            Console.ReadKey();
            createResponse5.Action = "Cierre de dos valvulas";
            client5.UpdateAuditEvent(createResponse5);

            var updatedGetResponse5 = client5.GetAuditEvent(new GetRequest() { Id = createResponse5.Id });
            if (updatedGetResponse5 is not null && updatedGetResponse5.KindCase == NullableAuditEventDTO.KindOneofCase.Auditevent && updatedGetResponse5.Auditevent.Action == "Cierre de dos valvulas")
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar el evento");
            Console.ReadKey();

            client5.DeleteAuditEvent(new DeleteRequest() { Id = createResponse5.Id });
            var deletedGetResponse5 = client5.GetAuditEvent(new GetRequest() { Id = createResponse5.Id });
            if (deletedGetResponse5 is null || deletedGetResponse5.KindCase != NullableAuditEventDTO.KindOneofCase.Auditevent)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            channel.Dispose();

        }
    }
}

