using CsvHelper;
using CsvHelper.Configuration;
using RyukTest.Model;
using System.Globalization;
using System.Reflection;

namespace RyukTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCSVAttribute : Attribute, ITestDataSource
    {
        private readonly string _pathToData;

        public TestCSVAttribute(string filename)
        {
            _pathToData = Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);
        }

        public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
        {
            var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                TrimOptions = TrimOptions.Trim,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using var reader = new StreamReader(_pathToData);
            using var csv = new CsvReader(reader, configPersons);
            var records = csv.GetRecords<TestInputData>().ToList();

            foreach (var item in records)
            {
                yield return new object[] { item };
            }
        }

        public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));

            return null;
        }
    }
}
