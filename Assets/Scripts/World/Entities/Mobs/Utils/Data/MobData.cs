using UnityEngine;

namespace Assets.Scripts.World.Entities.Mobs.Utils.Data
{
    [CreateAssetMenu(fileName = "MobData", menuName = "new MobData", order = 1)]
    public class MobData : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _armor;
        [SerializeField] private float _damage;
    }
}
