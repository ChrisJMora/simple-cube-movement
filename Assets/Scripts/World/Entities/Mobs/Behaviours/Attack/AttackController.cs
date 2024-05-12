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
        [SerializeField] [ReadOnly] private GameObject _instantiateObject;

        private float _coolDownAttackTimer;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= _coolDownAttackTimer)
            {
                Attack();
                _coolDownAttackTimer = Time.time + _mobProperties.AttackSpeed;
            }
        }

        private void Attack()
        {
            MovementIn2D.Stop(_movData);
            Vector3 targetPosition = _movData.PositionData.TargetPosition + transform.forward;
            StartAttack(targetPosition);
            Invoke(nameof(FinishAttack), _mobProperties.AttackSpeed);
        }

        private void StartAttack(Vector3 targetPosition)
        {
            AttackData attackData = _objectReference.GetComponent<AttackData>();
            attackData.Damage = _mobProperties.Damage;
            _instantiateObject = Instantiate(_objectReference, targetPosition, transform.rotation);
        }

        private void FinishAttack()
        {
            Destroy(_instantiateObject);
            _movData.IsMoving = true;
        }
    }
}
