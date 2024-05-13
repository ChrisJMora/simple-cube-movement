using Scripts.World.Entities.Mobs.Behaviours.Attack.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviour.Death;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using Scripts.World.Entities.Mobs.Utils.Data;
using UnityEngine;
using Scripts.World.Entities.Collectables.Utils.Data;

namespace Scripts.World.Entities.Mobs.Behaviours.ReceiveDamage
{
    public class ReceiveDamageController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private MobData _mobData;
        [SerializeField] private MobProperties _mobProperties;
        [SerializeField] private MovementData _movData;
        [SerializeField] private Animator _entityAnimator;

        [SerializeField] private DeathHandler _deathHandler;

        public delegate void _Die(GameObject entity, Animator animator);
        public static event _Die Die;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("EntityAttack") && !_movData.IsStunned)
            {
                _entityAnimator.SetBool("ReceiveDamage", true);
                MovementIn2D.Stop(_movData);
                Vector3 attackDirection = collision.transform.forward;
                MovementIn2D.Bounce(_movData, attackDirection);

                Invoke(nameof(FinishReceivingDamage), 1f);

                float damage = collision.gameObject.GetComponent<AttackData>().Damage;
                _mobData.CurrentHealth -= damage;

                if (_mobData.CurrentHealth <= 0) Die?.Invoke(gameObject, _entityAnimator);
            }
        }

        private void FinishReceivingDamage()
        {
            _entityAnimator.SetBool("ReceiveDamage", false);
            _movData.IsStunned = false;
        }
    }
}
