using Scripts.CustomAttributes;
using Scripts.World.Entities.Mobs.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviours.Attack.Utils.Data;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Assets.Scripts.World.Entities.Mobs.Behaviours.Attack
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private MobProperties _mobProperties;
        [SerializeField] private MovementData _movData;
        [SerializeField] private GameObject _objectReference;
        [SerializeField] private Animator _attackAnimator;
        [SerializeField] [ReadOnly] private GameObject _instantiateObject;
        [SerializeField] [ReadOnly] private Vector3 _targetPosition;

        private float _coolDownAttackTimer;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }

        private void Attack()
        {
            MovementIn2D.Stop(_movData);
            _targetPosition = _movData.PositionData.TargetPosition + transform.forward;
            _attackAnimator.SetBool("Attack", true);
            StartAttack();
            Invoke(nameof(FinishAttack), _mobProperties.AttackSpeed);
        }

        private void StartAttack()
        {
            AttackData attackData = _objectReference.GetComponent<AttackData>();
            attackData.Damage = _mobProperties.Damage;
            _instantiateObject = Instantiate(_objectReference, _targetPosition, transform.rotation);
        }

        private void FinishAttack()
        {
            _attackAnimator.SetBool("Attack", false);
            Destroy(_instantiateObject);
            _movData.IsStunned = false;
        }
    }
}
