using Scripts.World.Entities.Mobs.Behaviours.Attack.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviour.Death;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using Scripts.World.Entities.Mobs.Utils.Data;
using UnityEngine;
using Unity.VisualScripting;

namespace Scripts.World.Entities.Mobs.Behaviours.ReceiveDamage
{
    public class ReceiveDamageController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private MobData _mobData;
        [SerializeField] private MovementData _movData;

        private readonly DeathHandler _deathHandler;

        public delegate void _Die(GameObject entity);
        public static event _Die Die;

        private void Start()
        {
            gameObject.AddComponent<DeathHandler>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("EntityAttack"))
            {
                MovementIn2D.Stop(_movData);
                Vector3 attackDirection = collision.transform.forward;

                _movData.TrayectoryData.Direction = attackDirection;
                _movData.PositionData.TargetPosition = collision.transform.position;
                _movData.PositionData.DestinyPosition = collision.transform.position;
                _movData.PositionData.DestinyPosition += _movData.TrayectoryData.Direction;
                Invoke(nameof(FinishReceivingDamage), 2f);

                float damage = collision.gameObject.GetComponent<AttackData>().Damage;
                _mobData.CurrentHealth -= damage;

                if (_mobData.CurrentHealth <= 0) Die?.Invoke(gameObject);
            }
        }

        private void FinishReceivingDamage()
        {
            _movData.IsMoving = true;
        }
    }
}
