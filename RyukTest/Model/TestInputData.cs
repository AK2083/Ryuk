using CsvHelper.Configuration.Attributes;

namespace RyukTest.Model
{
    public class TestInputData
    {
        [Index(0)]
        public int Salary { get; set; }
        [Index(1)]
        public decimal Target { get; set; }
        [Index(2)]
        public int WageTaxClass { get; set; }
        [Index(3)]
        public decimal KVZ { get; set; }
        [Index(4)]
        public int PVZ { get; set; }
        [Index(5)]
        public int LZZ { get; set; }
        public int MUZZ { get; set; }
    }
}
