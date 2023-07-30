namespace CodeBase.Infrastructure.Services.SceneData
{
    public class SceneDataProvider : ISceneDataProvider
    {
        private ISceneData _data;

        public void Initialize(ISceneData data) => _data = data;

        public T Get<T>() where T : ISceneData => (T)_data;
    }
}