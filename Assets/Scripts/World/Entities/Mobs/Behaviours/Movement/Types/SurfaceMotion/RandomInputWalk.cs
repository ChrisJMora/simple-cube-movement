using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.CustomAttributes;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.Movement.Types.SurfaceMotion
{
    public class RandomInputWalk : SurfaceMovement
    {
        private readonly float _coolDownChangeSpeed = 6f;
        private readonly float _coolDownChangeDirection = 2f;

        private float _coolDownSpeedTimer;
        private float _coolDownDirectionTimer;

        [SerializeField] [ReadOnly] private Vector2 _inputDirection;
        [SerializeField] [ReadOnly] private float _inputSpeed;

        public override void Move()
        {
            if (Time.time >= _coolDownDirectionTimer)
            {
                _inputDirection = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                _coolDownDirectionTimer = Time.time + _coolDownChangeDirection;
            }

            if (!movData.IsJumping && !movData.IsFalling)
            {
                MovementIn2D.Move(movData, _inputDirection);
            }
        }

        public override void Run()
        {
            if (Time.time >= _coolDownSpeedTimer)
            {
                _inputSpeed = Random.Range(-1, 2);
                _coolDownSpeedTimer = Time.time + _coolDownChangeSpeed;
            }

            if (!movData.IsJumping && !movData.IsFalling)
            {
                movData.CurrentSpeed = _inputSpeed switch
                {
                    -1 => movData.MovPropertiesData.MinSpeed,
                    0 => movData.MovPropertiesData.Speed,
                    1 => movData.MovPropertiesData.MaxSpeed,
                    _ => 0f,
                };
            }
        }
    }
}
