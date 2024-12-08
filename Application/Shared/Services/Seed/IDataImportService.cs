namespace Application.Shared.Services.Seed;

public interface IDataImportService
{
    Task ImportDataAsync(string path);
}