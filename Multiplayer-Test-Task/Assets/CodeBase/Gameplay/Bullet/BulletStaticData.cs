using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    [CreateAssetMenu(menuName = "Configuration/Bullet", fileName = "BulletConfiguration")]
    public class BulletStaticData : ScriptableObject
    {
        public BulletObject BulletObjectPrefab;
        public int CreationLayerID;
    }
}