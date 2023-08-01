namespace CodeBase.Infrastructure.Services.Data
{
    public interface IDataProvider
    {
        public void Set<T>(T data) where T : IDataToProvide;

        public DataType Get<DataType>() where DataType : IDataToProvide;
    }
}