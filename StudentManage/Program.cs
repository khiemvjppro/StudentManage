using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace StudentManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=nana01218909214;Database=demoapi;");
            // connection.Open();
            // //command
            // NpgsqlCommand cmd = new NpgsqlCommand("select * from Student", connection);
            // NpgsqlDataReader npgsqlDataReader = cmd.ExecuteReader();
            // while (npgsqlDataReader.Read())
            // {
            //     System.Console.WriteLine(npgsqlDataReader[1]);
            // }
            // connection.Close();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
