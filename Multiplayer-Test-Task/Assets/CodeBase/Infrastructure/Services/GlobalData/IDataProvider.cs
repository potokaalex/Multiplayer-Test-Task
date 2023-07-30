namespace CodeBase.Infrastructure.Services.GlobalData
{
    public interface IDataProvider
    {
        public void Initialize(IData data);

        public DataType Get<DataType>() where DataType : IData;
    }
}