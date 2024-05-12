using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Attack.Utils.Data
{
    public class AttackData : MonoBehaviour
    {
        [SerializeField] private float _damage;

        public float Damage { get => _damage; set => _damage = value; }
    }
}
