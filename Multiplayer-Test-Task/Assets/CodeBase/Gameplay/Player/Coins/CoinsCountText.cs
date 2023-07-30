using TMPro;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Coins
{
    public class CoinsCountText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetCoinsCount(int value) => _text.text = value.ToString();
    }
}