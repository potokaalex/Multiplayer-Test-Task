using CodeBase.Gameplay.Player.Interact;
using CodeBase.Gameplay.Player.Object;
using Photon.Pun;
using UnityEngine;

namespace CodeBase.Gameplay.Coin
{
    public class CoinObject : MonoBehaviour, IInteractWithPlayer
    {
        private CoinNetwork _network;
        private int _id;

        public int Id => _id;

        public void Constructor(CoinNetwork network, int id)
        {
            _network = network;
            _id = id;
        }

        public void Interact(PlayerObject playerObject)
        {
            if (!PhotonNetwork.IsMasterClient)
                return;
            
            playerObject.RpcAddCoin();
            _network.DestroyCoin(this);
        }
    }
}