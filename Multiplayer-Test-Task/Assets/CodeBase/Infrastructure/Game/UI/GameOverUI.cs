using CodeBase.Gameplay.Player.Coins;
using CodeBase.Infrastructure.Game.Network;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Game.UI
{
    public class GameOverUI : MonoBehaviour, IGameUI
    {
        [SerializeField] private LeaveRoomButton _leaveRoomButton;
        [SerializeField] private CoinsCountText _coinCountText;
        [SerializeField] private Image _winnerColorImage;
        private GameNetwork _gameNetwork;

        public void Constructor(GameNetwork gameNetwork) => _gameNetwork = gameNetwork;

        public void InitializeUI(Color winnerColor, int winnerCoinCount)
        {
            _leaveRoomButton.Initialize(this);
            _winnerColorImage.color = winnerColor;
            _coinCountText.SetCoinsCount(winnerCoinCount);
        }

        public void DisposeUI() => _leaveRoomButton.Dispose();

        public void LeaveRoom() => _gameNetwork.LeaveRoom();
    }
}