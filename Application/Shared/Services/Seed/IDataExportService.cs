namespace Application.Shared.Services.Seed;

public interface IDataExportService
{
    Task ExportDataAsync(string path);
}