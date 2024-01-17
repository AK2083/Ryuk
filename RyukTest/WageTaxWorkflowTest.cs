using Microsoft.Extensions.Logging;
using Moq;

namespace WageTaxWorkflowTest;

[TestClass]
public class WageTaxWorkflowTest
{
    [DataTestMethod]
    [TestCSV("WageTax2023aData.csv", 2023)]
    [TestCategory("Workflow2023 Jan-Jun")]
    public void GivenSalaryAndTargetTaxes_WhenCalculateTax2023a_ThenGetTargetTaxesFromWorkflow(IInputParameter Input, IOutputParameter Output)
    {
        var taxWorkflow = new WageTaxWorkflow2023a(Input, Mock.Of<ILogger<WageTaxWorkflow2023a>>());
        taxWorkflow.Init();

        Assert.AreEqual(
            Output.LSTLZZ, taxWorkflow.OutputPara.LSTLZZ / 100,
            $"WageTaxClass: {Input.STKL}; {Input.JRE4 / 100} - {taxWorkflow.OutputPara.LSTLZZ / 100}"
        );
    }

    [DataTestMethod]
    [TestCSV("WageTax2023bData.csv", 2023)]
    [TestCategory("Workflow2023 Jul-Dec")]
    public void GivenSalaryAndTargetTaxes_WhenCalculateTax2023b_ThenGetTargetTaxesFromWorkflow(IInputParameter Input, IOutputParameter Output)
    {
        var taxWorkflow = new WageTaxWorkflow2023b(Input, Mock.Of<ILogger<WageTaxWorkflow2023b>>());
        taxWorkflow.Init();

        Assert.AreEqual(
            Output.LSTLZZ, taxWorkflow.OutputPara.LSTLZZ / 100,
            $"WageTaxClass: {Input.STKL}; {Input.JRE4 / 100} - {taxWorkflow.OutputPara.LSTLZZ / 100}"
        );
    }
}