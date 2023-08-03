namespace CodeBase.Gameplay.Player.Coins
{
    public class PlayerCoins
    {
        private int _currentValue;

        public void Change(int value) => _currentValue += value;

        public int Get() => _currentValue;
    }
}