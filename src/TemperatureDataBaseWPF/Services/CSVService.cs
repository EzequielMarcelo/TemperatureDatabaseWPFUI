using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using TemperatureDataBaseWPF.Models;

namespace TemperatureDataBaseWPF.Services
{
    public class CSVService
    {
        private bool _enableToSave;
        private string _fileName;
        private string _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Temperature Data");

        public CSVService()
        {
            _enableToSave = false;
            CreateDataBaseFolder();
        }
        private void CreateDataBaseFolder()
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
        }
        public async void SaveData(List<DataBaseModel> dataToSave)
        {
            if (!_enableToSave)
                return;

            var csvPath = Path.Combine(_folderPath, $"DataBase-{_fileName}.csv");

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
                    HasHeaderRecord = false,    // Don't write the header again.
                };
                using var streamWriter = File.Open(csvPath, FileMode.Append);
                using var writer = new StreamWriter(streamWriter);
                using var csvWriter = new CsvWriter(writer, config);
                await csvWriter.WriteRecordsAsync(dataToSave);
            }
        }
        public void ControlDataSave(bool enable)
        {
            _fileName = $"{DateTime.Now:yyyy-MM-dd-hh-mm-ss tt}";
            _enableToSave = enable;
        }
    }
}
