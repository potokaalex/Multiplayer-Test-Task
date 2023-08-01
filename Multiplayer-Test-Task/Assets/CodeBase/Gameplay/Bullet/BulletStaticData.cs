using CodeBase.Infrastructure.Services.Data;
using UnityEngine;

namespace CodeBase.Gameplay.Bullet
{
    [CreateAssetMenu(menuName = "Configuration/Bullet", fileName = "BulletConfiguration")]
    public class BulletStaticData : ScriptableObject, IDataToProvide
    {
        public BulletObject BulletObjectPrefab;
        public int CreationLayerID;
    }
}