using System;

namespace CodeBase.Infrastructure.Project.Services.SceneLoader
{
    public interface ISceneLoader
    {
        public void LoadScene(string sceneName, Action afterLoading = null);
    }
}