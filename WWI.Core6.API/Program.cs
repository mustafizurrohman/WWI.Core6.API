// ***********************************************************************
// Assembly         : WWI.Core6.API
// Author           : Mustafizur Rohman
// Created          : 04-23-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-17-2020
// ***********************************************************************
// <copyright file="Program.cs" company="WWI.Core6.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using WWI.Core6.Core.Exceptions;

// ReSharper disable ClassNeverInstantiated.Global
namespace WWI.Core6.API;

/// <summary>
/// The program
/// </summary>
public static class Program
{

    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {

        try
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Information("Application starting up ...");
            CreateHostBuilder(args).Build().Run();
        }
        catch (FormatException ex)
        {
            Console.WriteLine("FATAL: Invalid appsettings JSON file ...");
            Console.WriteLine(Environment.NewLine + ex + Environment.NewLine);

            Console.WriteLine("Press ENTER to exit the application ...");
        }
        catch (Exception ex)
        {
            if (ex is AppSettingsValidationException) {
                Log.Error("Invalid values in appSettings file.");
                Log.Fatal("The application failed to start correctly.");
            }

            Log.Information("Press ENTER to exit the application ...");
        }
        finally
        {
            Log.CloseAndFlush();
            Console.ReadLine();
        }

    }

    /// <summary>
    /// Creates the host builder.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns>IHostBuilder.</returns>
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}