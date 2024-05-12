using Scripts.World.Entities.Mobs.Behaviours.Movement.Types.SurfaceMotion;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using UnityEngine;

namespace Assets.Scripts.World.Entities.Mobs.Behaviour.Movement
{
    public class KeyInputWalk : SurfaceMovement
    {
        public override void Move()
        {
            var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (!movData.IsJumping && !movData.IsFalling)
                MovementIn2D.Move(movData, input);
        }

        public override void Run()
        {
            if (Input.GetKey(KeyCode.LeftShift) && !movData.IsJumping && !movData.IsFalling)
                movData.CurrentSpeed = movData.MovPropertiesData.MaxSpeed;
            else
                movData.CurrentSpeed = movData.MovPropertiesData.Speed;
        }
    }
}
