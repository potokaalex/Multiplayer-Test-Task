using CodeBase.Infrastructure.Lobby.UI;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Infrastructure.Lobby
{
    public class LobbyStartup : MonoBehaviourPunCallbacks
    {
        [SerializeField] private LobbyUIMediator _uiMediator;
        
        //TODO: create services & states
        
        private void Start()
        {
            InitNetwork();
            _uiMediator.InitializeUI();
        }

        private void OnDestroy()
        {
            _uiMediator.DisposeUI();
        }

        private void InitNetwork()
        {
            PhotonNetwork.NickName = Random.Range(0, 1000).ToString();

            //PhotonNetwork.AutomaticallySyncScene = true; //?
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }
        
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            UnityEngine.Debug.Log("Connected to master!");
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            
            PhotonNetwork.LoadLevel("Game");
        }
    }
}