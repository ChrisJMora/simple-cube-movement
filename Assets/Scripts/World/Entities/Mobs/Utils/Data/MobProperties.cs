using Scripts.World.Entities.Collectables.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Utils.Data
{
    [CreateAssetMenu(fileName = "MobProperties", menuName = "new Mob Properties", order = 1)]
    public class MobProperties : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackSpeed;
        [SerializeField] CollectableProperties _lootProperties;

        public float Health { get => _health; set => _health = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
        public CollectableProperties LootProperties { get => _lootProperties; set => _lootProperties = value; }
    }
}
