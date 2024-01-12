namespace Ryuk.Model
{
    public interface IWageTaxWorkflow
    {
        IInputParameter InputPara { get; set; }

        void Init();
    }
}
