using CodeBase.Infrastructure.Lobby.UI;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Infrastructure.Lobby
{
    public class LobbyStartup : MonoBehaviourPunCallbacks
    {
        [SerializeField] private LobbyUI _ui;

        private void Start() => _ui.InitializeUI();

        private void OnDestroy() => _ui.DisposeUI();
    }
}