using UnityEngine;

namespace CodeBase.Gameplay.Player.Interact
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            UnityEngine.Debug.Log(other.gameObject.name);
        }
    }
}