using CodeBase.Infrastructure.Project.Services.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Project
{
    [CreateAssetMenu(menuName = "Configuration/Project", fileName = "ProjectConfiguration")]
    public class ProjectStaticData : ScriptableObject, IDataToProvide
    {
        [SerializeField] private string _loadingSceneName;
        [SerializeField] private string _lobbySceneName;
        [SerializeField] private string _gameSceneName;

        public string LoadingSceneName => _loadingSceneName;

        public string LobbySceneName => _lobbySceneName;

        public string GameSceneName => _gameSceneName;
    }
}