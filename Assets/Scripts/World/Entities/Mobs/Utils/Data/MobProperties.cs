using UnityEngine;

namespace Scripts.World.Entities.Mobs.Utils.Data
{
    [CreateAssetMenu(fileName = "MovProperties", menuName = "new MovProperties", order = 1)]
    public class MobProperties : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackSpeed;

        public float Health { get => _health; set => _health = value; }
        public float Damage { get => _damage; set => _damage = value; }
        public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    }
}
