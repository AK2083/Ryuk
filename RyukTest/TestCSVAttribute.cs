using CsvHelper;
using CsvHelper.Configuration;
using Ryuk.Model.Implementations;
using RyukTest.Model;
using System.Globalization;
using System.Reflection;

namespace RyukTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCSVAttribute : Attribute, ITestDataSource
    {
        private readonly string _filename;
        private readonly int _currentYear;

        public TestCSVAttribute(string filename, int currentYear)
        {
            _filename = Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);
            _currentYear = currentYear;
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

            using var reader = new StreamReader(_filename);
            using var csv = new CsvReader(reader, configPersons);
            var records = csv.GetRecords<TestInputData>().ToList();

            foreach (var item in records)
            {
                yield return new object[] {
                    new InputParameter
                    {
                        KVZ = item.KVZ,
                        PVZ = item.PVZ,
                        LZZ = item.LZZ,
                        VJAHR = _currentYear,
                        STKL = item.WageTaxClass,
                        JRE4 = item.Salary * 100,
                        RE4 = item.Salary * 100,
                    },
                    new OutputParameter
                    {
                        LSTLZZ = item.Target
                    }
                };
            }
        }

        public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        {
            if (data != null)
                return string.Format(
                    CultureInfo.CurrentCulture,
                    "WageTax: {0}, Income: {1}",
                    (data[0] as IInputParameter).STKL,
                    (data[0] as IInputParameter).JRE4 / 100
                );

            return null;
        }
    }
}
