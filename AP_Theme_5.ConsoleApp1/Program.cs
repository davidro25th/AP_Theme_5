using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using AP_Theme_5.GrpcProtos;


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
            var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new AP_Theme_5.GrpcProtos.MeasurementUnit.MeasurementUnitClient(channel);

            Console.WriteLine("Presione una tecla para crear una unidad de medida");
            Console.ReadKey();
            var createResponse = client.CreateMeasurementUnit(new CreateMeasurementUnitRequest() { Unitname = "Celcius", Unittype = "Temperatura" });
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

            /* Console.WriteLine("Presione una tecla para obtener la unidad de medida");
             Console.ReadKey();
             var getResponse = client.GetMeasurementUnit(new GetRequest() { Id = createResponse.Id });
             if (getResponse.Price is null)
             {
                 Console.WriteLine("Cannot get price");
                 channel.Dispose();
                 return;
             }
             else
             {
                 Console.WriteLine($"Obtención exitosa {getResponse.Price.Value} {getResponse.Price.MoneyType.ToString()}");

             }

             Console.WriteLine("Presione una tecla para modificar el precio");
             Console.ReadKey();
             createResponse.Value = 20;
             client.UpdatePrice(createResponse);

             var updatedGetResponse = client.GetPrice(new GetRequest() { Id = createResponse.Id });
             if (updatedGetResponse is not null && updatedGetResponse.KindCase == NullablePriceDTO.KindOneofCase.Price && updatedGetResponse.Price.Value == 20)
             {
                 Console.WriteLine($"Modificación exitosa.");
             }

             Console.WriteLine("Presione una tecla para eliminar el precio");
             Console.ReadKey();

             client.DeletePrice(createResponse);
             var deletedGetResponse = client.GetPrice(new GetRequest() { Id = createResponse.Id });
             if (deletedGetResponse is null || deletedGetResponse.KindCase != NullablePriceDTO.KindOneofCase.Price)
             {
                 Console.WriteLine($"Eliminación exitosa.");
             }*/


            channel.Dispose();

        }
    }
}