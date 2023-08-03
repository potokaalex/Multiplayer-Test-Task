using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Infrastructure.Project.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States
{
    public class DeathState : IState
    {
        private readonly PlayerObjectFactory _playerObjectFactory;
        private readonly PlayerUIFactory _playerUIFactory;

        public DeathState(PlayerUIFactory playerUIFactory, PlayerObjectFactory playerObjectFactory)
        {
            _playerObjectFactory = playerObjectFactory;
            _playerUIFactory = playerUIFactory;
        }

        public void Enter()
        {
            _playerUIFactory.GetUI().Dispose();
            _playerUIFactory.DestroyUI();
            _playerObjectFactory.DestroyPlayer();
        }
    }
}