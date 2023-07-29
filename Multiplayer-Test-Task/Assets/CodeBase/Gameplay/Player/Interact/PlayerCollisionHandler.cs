using CodeBase.Gameplay.Player.Object;
using UnityEngine;

namespace CodeBase.Gameplay.Player.Interact
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private PlayerObject _playerObject;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.TryGetComponent<IInteractWithPlayer>(out var interactive))
                interactive.Interact(_playerObject);
        }
    }
}