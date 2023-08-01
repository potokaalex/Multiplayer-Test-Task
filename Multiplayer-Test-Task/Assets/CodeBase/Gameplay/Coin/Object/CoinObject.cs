using CodeBase.Gameplay.Player.Interact;
using CodeBase.Gameplay.Player.Network;
using CodeBase.Gameplay.Player.Object;
using Photon.Pun;

namespace CodeBase.Gameplay.Coin.Object
{
    public class CoinObject : MonoBehaviourPun, IInteractWithPlayer
    {
        private CoinObjectFactory _factory;
        private PlayerNetwork _playerNetwork;

        public void Constructor(CoinObjectFactory factory, PlayerNetwork playerNetwork)
        {
            _factory = factory;
            _playerNetwork = playerNetwork;
        }

        public void Interact(PlayerObject playerObject)
        {
            if (!photonView.IsMine)
                return;

            _playerNetwork.AddCoin(playerObject.PhotonView.Controller);
            _factory.DestroyCoin(this);
        }
    }
}