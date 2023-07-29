using UnityEngine;

namespace CodeBase.Gameplay.Player.Health
{
    public class PlayerHealth
    {
        private readonly int _maxValue;
        private int _currentValue;

        public PlayerHealth(int maxValue, int currentValue)
        {
            _maxValue = maxValue;
            _currentValue = currentValue;
        }

        public void Change(int value) => _currentValue = Mathf.Clamp(_currentValue + value, 0, _maxValue);

        public int Get() => _currentValue;
    }
}