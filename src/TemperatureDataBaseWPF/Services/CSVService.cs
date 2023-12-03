using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using TemperatureDataBaseWPF.Models;

namespace TemperatureDataBaseWPF.Services
{
    public class CSVService
    {
        private string _fileName;
        public CSVService()
        {
            _fileName = $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss tt}";
        }
        public async void SaveData(List<DataBaseModel> dataToSave)
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"DataBase-{_fileName}.csv");

            if (!File.Exists(csvPath))
            {
                using var streamWriter = new StreamWriter(csvPath);
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                await csvWriter.WriteRecordsAsync(dataToSave);
            }
            else
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    // Don't write the header again.
                    HasHeaderRecord = false,
                };
                using var streamWriter = File.Open(csvPath, FileMode.Append);
                using var writer = new StreamWriter(streamWriter);
                using var csvWriter = new CsvWriter(writer, config);
                await csvWriter.WriteRecordsAsync(dataToSave);
            }

        }
    }
}
