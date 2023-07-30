namespace CodeBase.Infrastructure.Services.GlobalData
{
    public class DataProvider : IDataProvider
    {
        private IData _data;

        public void Initialize(IData data) => _data = data;

        public DataType Get<DataType>() where DataType : IData => (DataType)_data;
    }
}