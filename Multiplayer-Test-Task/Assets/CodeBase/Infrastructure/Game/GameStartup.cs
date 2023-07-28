using System;
using CodeBase.Infrastructure.Game.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Game
{
    public class GameStartup : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameUIMediator _gameUIMediator;
        
        private void Start()
        {
            _gameUIMediator.InitializeUI();
        }

        private void OnDestroy()
        {
            _gameUIMediator.DisposeUI();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            UnityEngine.Debug.Log($"Player {newPlayer.NickName} entered room!");
        }
        
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            UnityEngine.Debug.Log($"Player {otherPlayer.NickName} left room!");
        }
        
        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            SceneManager.LoadScene("Lobby");
        }
    }
}