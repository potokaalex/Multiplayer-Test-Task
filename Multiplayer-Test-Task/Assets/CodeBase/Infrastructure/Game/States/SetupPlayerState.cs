using CodeBase.Gameplay.Player.Network;
using CodeBase.Gameplay.Player.Object;
using CodeBase.Gameplay.Player.UI;
using CodeBase.Gameplay.Player.Weapon;
using CodeBase.Infrastructure.Services.StateMachine;

namespace CodeBase.Infrastructure.Game.States
{
    public class SetupPlayerState : IState
    {
        private readonly PlayerObjectFactory _playerObjectFactory;
        private readonly PlayerUIFactory _playerUIFactory;
        private readonly PlayerWeaponFactory _weaponFactory;
        private readonly PlayerNetwork _playerNetwork;
        private readonly IStateMachine _stateMachine;

        public SetupPlayerState(PlayerObjectFactory playerObjectFactory, PlayerUIFactory playerUIFactory,
            PlayerWeaponFactory weaponFactory, PlayerNetwork playerNetwork, IStateMachine stateMachine)
        {
            _playerObjectFactory = playerObjectFactory;
            _playerUIFactory = playerUIFactory;
            _weaponFactory = weaponFactory;
            _playerNetwork = playerNetwork;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _playerObjectFactory.Initialize();
            _playerUIFactory.Initialize();
            _weaponFactory.Initialize();
            _playerNetwork.Initialize(CreatePlayer());

            _stateMachine.SwitchTo<WaitingState>();
        }

        private PlayerObject CreatePlayer()
        {
            _playerUIFactory.CreateUI();
            var ui = _playerUIFactory.GetUI();
            var weapon = _weaponFactory.CreateWeapon();
            var playerObject = _playerObjectFactory.CreatePlayer(ui, weapon);

            weapon.Initialize(playerObject.BulletSpawnPoint, playerObject.Rigidbody);
            ui.Initialize(playerObject);

            return playerObject;
        }
    }
}