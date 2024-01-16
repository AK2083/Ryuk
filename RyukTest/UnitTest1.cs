using Ryuk;
using Ryuk.Model.Implementations;
using RyukTest.Model;
using System.Diagnostics;

namespace RyukTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [TestCSV("WageTax2023aData.csv")]
        public void TestWageTax2023a(TestInputData TargetCl)
        {
            var input = new InputParameter
            {
                KVZ = TargetCl.KVZ,
                PVZ = TargetCl.PVZ,
                LZZ = TargetCl.LZZ,
                VJAHR = 2023,
                STKL = TargetCl.WageTaxClass,
                JRE4 = TargetCl.Salary * 100,
                RE4 = TargetCl.Salary * 100,
            };

            var taxWorkflow = new WageTaxWorkflow2023(input);
            taxWorkflow.Init();

            Trace.WriteLine($"WageTaxClass: {TargetCl.WageTaxClass}");
            Assert.AreEqual(TargetCl.Target, taxWorkflow.OutputPara.LSTLZZ / 100, $"{TargetCl.Salary} - {taxWorkflow.OutputPara.LSTLZZ / 100}");
        }
    }
}