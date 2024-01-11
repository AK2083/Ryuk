namespace RyukTest
{
    public class RyukTest_2023_1
    {
        private readonly int CurrentYear = 2023;

        [Theory]
        [InlineData(5000, 0)]
        [InlineData(7500, 0)]
        [InlineData(10000, 0)]
        [InlineData(12500, 0)]
        [InlineData(15000, 0)]
        [InlineData(17500, 283)]
        [InlineData(20000, 723)]
        [InlineData(22500, 1199)]
        [InlineData(25000, 1700)]
        [InlineData(27500, 2217)]
        [InlineData(30000, 2750)]
        [InlineData(32500, 3298)]
        [InlineData(35000, 3862)]
        [InlineData(37500, 4442)]
        [InlineData(40000, 5038)]
        [InlineData(42500, 5649)]
        [InlineData(45000, 6277)]
        [InlineData(47500, 6920)]
        [InlineData(50000, 7579)]
        [InlineData(52500, 8254)]
        [InlineData(55000, 8945)]
        [InlineData(57500, 9651)]
        [InlineData(60000, 10378)]
        [InlineData(62500, 11206)]
        [InlineData(65000, 12053)]
        [InlineData(67500, 12920)]
        [InlineData(70000, 13807)]
        [InlineData(72500, 14714)]
        [InlineData(75000, 15640)]
        [InlineData(77500, 16586)]
        [InlineData(80000, 17538)]
        [InlineData(82500, 18490)]
        [InlineData(85000, 19442)]
        [InlineData(87500, 20395)]
        [InlineData(90000, 21441)]
        public void Compare_TargetTaxesWithActualTaxesWithWageTaxClassI_ReturnTrue(int salary, int targetWageTax)
        {
            var lsto = new WageTaxWorkflow2023(new InputParameter
            {
                KVZ = 1.60,
                PVZ = 1,
                LZZ = 1,
                VJAHR = CurrentYear,
                STKL = 1,
                JRE4 = salary * 100,
                RE4 = salary * 100,
            });
            lsto.Init();

            Assert.True(
                lsto.OutputPara.LSTLZZ == (targetWageTax * 100),
                $"Actual: {lsto.OutputPara.LSTLZZ}, Target: {(targetWageTax * 100)}"
            );
        }

        [Theory]
        [InlineData(5000, 0)]
        [InlineData(7500, 0)]
        [InlineData(10000, 0)]
        [InlineData(12500, 0)]
        [InlineData(15000, 0)]
        [InlineData(17500, 0)]
        [InlineData(20000, 0)]
        [InlineData(22500, 296)]
        [InlineData(25000, 696)]
        [InlineData(27500, 1172)]
        [InlineData(30000, 1674)]
        [InlineData(32500, 2192)]
        [InlineData(35000, 2727)]
        [InlineData(37500, 3277)]
        [InlineData(40000, 3843)]
        [InlineData(42500, 4425)]
        [InlineData(45000, 5023)]
        [InlineData(47500, 5637)]
        [InlineData(50000, 6266)]
        [InlineData(52500, 6912)]
        [InlineData(55000, 7574)]
        [InlineData(57500, 8251)]
        [InlineData(60000, 8950)]
        [InlineData(62500, 9742)]
        [InlineData(65000, 10553)]
        [InlineData(67500, 11385)]
        [InlineData(70000, 12236)]
        [InlineData(72500, 13108)]
        [InlineData(75000, 13999)]
        [InlineData(77500, 14910)]
        [InlineData(80000, 15840)]
        [InlineData(82500, 16789)]
        [InlineData(85000, 17741)]
        [InlineData(87500, 18694)]
        [InlineData(90000, 19740)]
        public void Compare_TargetTaxesWithActualTaxesWithWageTaxClassII_ReturnTrue(int salary, int targetWageTax)
        {
            var lsto = new WageTaxWorkflow2023(new InputParameter
            {
                KVZ = 1.60,
                PVZ = 0,
                LZZ = 1,
                VJAHR = CurrentYear,
                STKL = 2,
                JRE4 = salary * 100,
                RE4 = salary * 100,
            });
            lsto.Init();

            Assert.True(
                lsto.OutputPara.LSTLZZ == (targetWageTax * 100),
                $"Actual: {lsto.OutputPara.LSTLZZ}, Target: {(targetWageTax * 100)}"
            );
        }

        [Theory]
        [InlineData(5000, 0)]
        [InlineData(7500, 0)]
        [InlineData(10000, 0)]
        [InlineData(12500, 0)]
        [InlineData(15000, 0)]
        [InlineData(17500, 0)]
        [InlineData(20000, 0)]
        [InlineData(22500, 0)]
        [InlineData(25000, 0)]
        [InlineData(27500, 0)]
        [InlineData(30000, 164)]
        [InlineData(32500, 506)]
        [InlineData(35000, 874)]
        [InlineData(37500, 1282)]
        [InlineData(40000, 1730)]
        [InlineData(42500, 2214)]
        [InlineData(45000, 2708)]
        [InlineData(47500, 3210)]
        [InlineData(50000, 3720)]
        [InlineData(52500, 4238)]
        [InlineData(55000, 4764)]
        [InlineData(57500, 5296)]
        [InlineData(60000, 5842)]
        [InlineData(62500, 6458)]
        [InlineData(65000, 7084)]
        [InlineData(67500, 7718)]
        [InlineData(70000, 8364)]
        [InlineData(72500, 9020)]
        [InlineData(75000, 9684)]
        [InlineData(77500, 10360)]
        [InlineData(80000, 11044)]
        [InlineData(82500, 11738)]
        [InlineData(85000, 12444)]
        [InlineData(87500, 13158)]
        [InlineData(90000, 13954)]
        public void Compare_TargetTaxesWithActualTaxesWithWageTaxClassIII_ReturnTrue(int salary, int targetWageTax)
        {
            var lsto = new WageTaxWorkflow2023(new InputParameter
            {
                KVZ = 1.60,
                PVZ = 1,
                LZZ = 1,
                VJAHR = CurrentYear,
                STKL = 3,
                JRE4 = salary * 100,
                RE4 = salary * 100,
            });
            lsto.Init();

            Assert.True(
                lsto.OutputPara.LSTLZZ == (targetWageTax * 100),
                $"Actual: {lsto.OutputPara.LSTLZZ}, Target: {(targetWageTax * 100)}"
            );
        }

        [Theory]
        [InlineData(5000, 0)]
        [InlineData(7500, 0)]
        [InlineData(10000, 0)]
        [InlineData(12500, 0)]
        [InlineData(15000, 0)]
        [InlineData(17500, 283)]
        [InlineData(20000, 723)]
        [InlineData(22500, 1199)]
        [InlineData(25000, 1700)]
        [InlineData(27500, 2217)]
        [InlineData(30000, 2750)]
        [InlineData(32500, 3298)]
        [InlineData(35000, 3862)]
        [InlineData(37500, 4442)]
        [InlineData(40000, 5038)]
        [InlineData(42500, 5649)]
        [InlineData(45000, 6277)]
        [InlineData(47500, 6920)]
        [InlineData(50000, 7579)]
        [InlineData(52500, 8254)]
        [InlineData(55000, 8945)]
        [InlineData(57500, 9651)]
        [InlineData(60000, 10378)]
        [InlineData(62500, 11206)]
        [InlineData(65000, 12053)]
        [InlineData(67500, 12920)]
        [InlineData(70000, 13807)]
        [InlineData(72500, 14714)]
        [InlineData(75000, 15640)]
        [InlineData(77500, 16586)]
        [InlineData(80000, 17538)]
        [InlineData(82500, 18490)]
        [InlineData(85000, 19442)]
        [InlineData(87500, 20395)]
        [InlineData(90000, 21441)]
        public void Compare_TargetTaxesWithActualTaxesWithWageTaxClassIV_ReturnTrue(int salary, int targetWageTax)
        {
            var lsto = new WageTaxWorkflow2023(new InputParameter
            {
                KVZ = 1.60,
                PVZ = 1,
                LZZ = 1,
                LZZ = 1,
                VJAHR = CurrentYear,
                STKL = 4,
                JRE4 = salary * 100,
                RE4 = salary * 100,
            });
            lsto.Init();

            Assert.True(
                lsto.OutputPara.LSTLZZ == (targetWageTax * 100),
                $"Actual: {lsto.OutputPara.LSTLZZ}, Target: {(targetWageTax * 100)}"
            );
        }

        [Theory]
        [InlineData(5000, 373)]
        [InlineData(7500, 649)]
        [InlineData(10000, 924)]
        [InlineData(12500, 1199)]
        [InlineData(15000, 1475)]
        [InlineData(17500, 1839)]
        [InlineData(20000, 2777)]
        [InlineData(22500, 3628)]
        [InlineData(25000, 4479)]
        [InlineData(27500, 5329)]
        [InlineData(30000, 6148)]
        [InlineData(32500, 6884)]
        [InlineData(35000, 7652)]
        [InlineData(37500, 8452)]
        [InlineData(40000, 9282)]
        [InlineData(42500, 10131)]
        [InlineData(45000, 10982)]
        [InlineData(47500, 11832)]
        [InlineData(50000, 12683)]
        [InlineData(52500, 13534)]
        [InlineData(55000, 14385)]
        [InlineData(57500, 15235)]
        [InlineData(60000, 16092)]
        [InlineData(62500, 17045)]
        [InlineData(65000, 17997)]
        [InlineData(67500, 18950)]
        [InlineData(70000, 19902)]
        [InlineData(72500, 20854)]
        [InlineData(75000, 21806)]
        [InlineData(77500, 22759)]
        [InlineData(80000, 23711)]
        [InlineData(82500, 24664)]
        [InlineData(85000, 25616)]
        [InlineData(87500, 26568)]
        [InlineData(90000, 27614)]
        public void Compare_TargetTaxesWithActualTaxesWithWageTaxClassV_ReturnTrue(int salary, int targetWageTax)
        {
            var lsto = new WageTaxWorkflow2023(new InputParameter
            {
                KVZ = 1.60,
                PVZ = 1,
                LZZ = 1,
                LZZ = 1,
                VJAHR = CurrentYear,
                STKL = 5,
                JRE4 = salary * 100,
                RE4 = salary * 100,
            });
            lsto.Init();

            Assert.True(
                lsto.OutputPara.LSTLZZ == (targetWageTax * 100),
                $"Actual: {lsto.OutputPara.LSTLZZ}, Target: {(targetWageTax * 100)}"
            );
        }

        [Theory]
        [InlineData(5000, 550)]
        [InlineData(7500, 826)]
        [InlineData(10000, 1101)]
        [InlineData(12500, 1377)]
        [InlineData(15000, 1652)]
        [InlineData(17500, 2371)]
        [InlineData(20000, 3309)]
        [InlineData(22500, 4159)]
        [InlineData(25000, 5010)]
        [InlineData(27500, 5861)]
        [InlineData(30000, 6606)]
        [InlineData(32500, 7360)]
        [InlineData(35000, 8146)]
        [InlineData(37500, 8966)]
        [InlineData(40000, 9812)]
        [InlineData(42500, 10663)]
        [InlineData(45000, 11513)]
        [InlineData(47500, 12364)]
        [InlineData(50000, 13215)]
        [InlineData(52500, 14066)]
        [InlineData(55000, 14916)]
        [InlineData(57500, 15767)]
        [InlineData(60000, 16624)]
        [InlineData(62500, 17577)]
        [InlineData(65000, 18529)]
        [InlineData(67500, 19481)]
        [InlineData(70000, 20433)]
        [InlineData(72500, 21386)]
        [InlineData(75000, 22338)]
        [InlineData(77500, 23291)]
        [InlineData(80000, 24243)]
        [InlineData(82500, 25195)]
        [InlineData(85000, 26148)]
        [InlineData(87500, 27100)]
        [InlineData(90000, 28146)]
        public void Compare_TargetTaxesWithActualTaxesWithWageTaxClassVI_ReturnTrue(int salary, int targetWageTax)
        {
            var lsto = new WageTaxWorkflow2023(new InputParameter
            {
                KVZ = 1.60,
                PVZ = 1,
                LZZ = 1,
                LZZ = 1,
                VJAHR = CurrentYear,
                STKL = 6,
                JRE4 = salary * 100,
                RE4 = salary * 100,
            });
            lsto.Init();

            Assert.True(
                lsto.OutputPara.LSTLZZ == (targetWageTax * 100),
                $"Actual: {lsto.OutputPara.LSTLZZ}, Target: {(targetWageTax * 100)}"
            );
        }
    }
}