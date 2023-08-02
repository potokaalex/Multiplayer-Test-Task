using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services.Data
{
    public class DataProvider : IDataProvider
    {
        private readonly Dictionary<Type, IDataToProvide> _data = new();

        public void Set<T>(T data) where T : IDataToProvide => _data[typeof(T)] = data;

        public DataType Get<DataType>() where DataType : IDataToProvide => (DataType)_data[typeof(DataType)];
    }
}