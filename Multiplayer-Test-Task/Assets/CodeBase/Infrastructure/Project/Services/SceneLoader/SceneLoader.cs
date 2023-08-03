using System;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Project.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName, Action afterLoading = null)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).completed +=
                _ => afterLoading?.Invoke();
        }
    }
}