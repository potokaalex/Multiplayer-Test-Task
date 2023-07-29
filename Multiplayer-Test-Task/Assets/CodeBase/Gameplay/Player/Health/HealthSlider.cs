using UnityEngine.UI;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Health
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetHealth(int value)
        {
            if (_slider.maxValue < value)
                _slider.maxValue = value;

            _slider.value = value;
        }
    }
}