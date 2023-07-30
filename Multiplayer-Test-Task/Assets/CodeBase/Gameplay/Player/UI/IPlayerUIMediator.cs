using CodeBase.Gameplay.Player.Object;

namespace CodeBase.Gameplay.Player.UI
{
    public interface IPlayerUIMediator
    {
        public void InitializeUI(PlayerObject playerObject);

        public void DisposeUI();
        
        public void SetHealth(int value);
        
        public void SetCoinsCount(int get);
    }
}