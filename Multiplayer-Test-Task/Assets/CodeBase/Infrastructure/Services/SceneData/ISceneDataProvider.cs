namespace CodeBase.Infrastructure.Services.SceneData
{
    public interface ISceneDataProvider
    {
        public void Initialize(ISceneData data);

        public T Get<T>() where T : ISceneData;
    }
}