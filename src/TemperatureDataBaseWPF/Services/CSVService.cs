using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using TemperatureDataBaseWPF.Models;

namespace TemperatureDataBaseWPF.Services
{
    public class CSVService
    {
        public CSVService()
        {
           SaveData();
        }
        public async void SaveData()
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"DataBase-{DateTime.Now:yyyy-MM-dd-hh-mm-ss tt}.csv");
            using var streamWriter = new StreamWriter(csvPath);
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            var DataTosave = new List<DataBaseModel>() { new DataBaseModel()};
            await csvWriter.WriteRecordsAsync(DataTosave);
        }
    }
}
