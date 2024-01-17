namespace WageTaxWorkflowTest;

[TestClass]
public class WageTaxWorkflowTest
{
    [DataTestMethod]
    [TestCSV("WageTax2023aData.csv", 2023)]
    [TestCategory("Workflow2023a")]
    public void GivenSalaryAndTargetTaxes_WhenCalculateTax2023_ThenGetTargetTaxesFromWorkflow(IInputParameter Input, IOutputParameter Output)
    {
        var taxWorkflow = new WageTaxWorkflow2023(Input);
        taxWorkflow.Init();

        Assert.AreEqual(
            Output.LSTLZZ, taxWorkflow.OutputPara.LSTLZZ / 100,
            $"WageTaxClass: {Input.STKL}; {Input.JRE4 / 100} - {taxWorkflow.OutputPara.LSTLZZ / 100}"
        );
    }
}