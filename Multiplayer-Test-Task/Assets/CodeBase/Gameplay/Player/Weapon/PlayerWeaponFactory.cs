using CodeBase.Gameplay.Bullet;
using CodeBase.Gameplay.Player.Data;
using CodeBase.Infrastructure.Services.Data;

namespace CodeBase.Gameplay.Player.Weapon
{
    public class PlayerWeaponFactory
    {
        private readonly BulletFactory _bulletFactory;
        private readonly IDataProvider _dataProvider;

        private PlayerStaticData _playerStaticData;

        public PlayerWeaponFactory(BulletFactory bulletFactory, IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _bulletFactory = bulletFactory;
        }

        public void Initialize() => _playerStaticData = _dataProvider.Get<PlayerStaticData>();

        public PlayerWeapon CreateWeapon() =>
            new(_bulletFactory, _playerStaticData.BulletForceValue, _playerStaticData.BulletDamageValue);
    }
}