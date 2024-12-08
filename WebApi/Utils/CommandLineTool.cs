using Application;
using Application.Shared.Services.Seed;
using Persistence;

namespace WebApi.Utils;

public static class CommandLineTool
{
    // TODO: ADD MIGRATION
    public static async Task Run(string[] args, IConfiguration configuration)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: <export-data|seed>");
            return;
        }

        var operation = args[0].ToLower();

        var exportFilePath = "./data/seed.json";
        var seedFilePath = "./data/seed.json";

        if (operation == "export-data")
            PrepareFilePath(exportFilePath);
        else if (operation == "seed")
            if (!File.Exists(seedFilePath))
            {
                Console.WriteLine($"Seed file does not exist: {seedFilePath}");
                return;
            }

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging();
        serviceCollection.AddPersistence(configuration);
        serviceCollection.AddApplication();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var exportService = serviceProvider.GetRequiredService<IDataExportService>();
        var importService = serviceProvider.GetRequiredService<IDataImportService>();

        try
        {
            switch (operation)
            {
                case "export-data":
                    Console.WriteLine($"Exporting data to {exportFilePath}...");
                    await exportService.ExportDataAsync(exportFilePath);
                    Console.WriteLine("Export completed successfully.");
                    break;
                case "seed":
                    Console.WriteLine($"Seeding data from {seedFilePath}...");
                    await importService.ImportDataAsync(seedFilePath);
                    Console.WriteLine("Seed completed successfully.");
                    break;
                default:
                    Console.WriteLine("Invalid operation. Use 'export-data' or 'seed'.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static void PrepareFilePath(string filePath)
    {
        try
        {
            var directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine($"Created directory: {directory}");
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
                Console.WriteLine($"Created file: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to prepare file path: {ex.Message}");
            throw;
        }
    }
}