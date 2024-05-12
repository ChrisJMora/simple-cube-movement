using UnityEngine;

namespace Scripts.World.Entities.Mobs.Utils.Data
{
    public class MobData : MonoBehaviour
    {
        [SerializeField] private MobProperties _mobProperties;
        [SerializeField] private float _currentHealth;

        private void Awake()
        {
            _currentHealth = _mobProperties.Health;
        }

        public MobProperties MobProperties { get => _mobProperties; set => _mobProperties = value; }
        public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    }
}
