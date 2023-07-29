using CodeBase.Gameplay.Player.Object;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Player
{
    public class PlayerNetworkInstantiateHandler : MonoBehaviour, IPunInstantiateMagicCallback
    {
        [SerializeField] private PlayerObject _playerObject;

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            var color = (PlayerColor)info.photonView.InstantiationData[0];
                
            _playerObject.Initialize(color);
        }
    }
}