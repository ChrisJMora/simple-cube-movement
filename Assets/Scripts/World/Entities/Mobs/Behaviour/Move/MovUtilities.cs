using UnityEngine;
using Scripts.CustomAttributes;

namespace Scripts.World.Entities.Mobs.Behaviour.Move
{
    [System.Serializable]
    public class MovUtilities
    {
        [Header("Movement Properties")]
        [ReadOnly][SerializeField] float speed;
        [ReadOnly][SerializeField] float distance;
        [ReadOnly] public Vector3 direction;

        [Header("Referencial Points")]
        [ReadOnly] public Vector3 currentPosition;
        [ReadOnly] public Vector3 targetPosition;
        [ReadOnly] public Vector3 destinyPosition;
        [ReadOnly] public float currentHeight;

        [Header("States")]
        [ReadOnly] public bool ReachDestination;
        [ReadOnly] public bool isJumping;
        [ReadOnly] public bool isFalling;

        public Vector3 CurrentPosition => targetPosition - direction;

        public MovUtilities(Vector3 origin, float speed, float distance)
        {
            this.speed = speed;
            this.distance = distance;
            currentPosition = destinyPosition = origin;
            currentHeight = 0;
        }

        public void Move(Transform entity, float xInput, float zInput)
        {
            UpdateEntityPosition(entity, targetPosition); // Update the entity position
            if (Vector3.Distance(currentPosition, targetPosition) <= .05f && !ReachDestination)
                targetPosition += direction;
            if (Vector3.Distance(targetPosition, destinyPosition) <= .05f)
                ReachDestination = true;
            if (xInput == 0 && zInput == 0) return; // Dont move if there is no input
            direction = SetUpDirection(entity, xInput, zInput);
            if (ReachDestination) {
                destinyPosition += direction * distance;
                ReachDestination = false;
            }
        }
        public void Jump(Transform entity)
        {
            isJumping = true;
            UpdateEntityPosition(entity, currentPosition + Vector3.up);
            if (entity.position.y >= currentHeight + 1f)
            {
                currentHeight += 1;
                targetPosition += Vector3.up;
                destinyPosition += Vector3.up;
                isJumping = false;
            }
        }
        public void Fall(Transform entity)
        {
            isFalling = true;
            UpdateEntityPosition(entity, targetPosition);
            if (Vector3.Distance(entity.position, targetPosition) <= .05f)
            {
                currentHeight -= 1;
                targetPosition += Vector3.down;
                destinyPosition += Vector3.down;
                isFalling = false;
            }
        }
        public bool CheckWall(Vector3 target)
        {
            return Physics.CheckSphere(target, .05f, LayerMask.GetMask("Wall"));
        }
        private void UpdateEntityPosition(Transform entity, Vector3 targetPosition)
        {
            currentPosition = entity.position;
            entity.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }
        private Vector3 SetUpDirection(Transform entity, float x, float z)
        {
            if (Mathf.Abs(x) == 1f) return MoveSideWays(entity, x);
            else
            if (Mathf.Abs(z) == 1f) return MoveForward(entity, z);
            return Vector3.zero;
        }
        private Vector3 MoveSideWays(Transform entity, float orientation)
        {
            if (orientation == 1f)
                entity.rotation = Quaternion.Euler(0f, 90f, 0f);
            else
                entity.rotation = Quaternion.Euler(0f, -90f, 0f);
            return new Vector3(0f, 0f, orientation);
        }
        private Vector3 MoveForward(Transform entity, float orientation)
        {
            if (orientation == 1f)
                entity.rotation = Quaternion.Euler(0f, 0f, 0f);
            else
                entity.rotation = Quaternion.Euler(0f, 180f, 0f);
            return new Vector3(orientation, 0f, 0f);
        }
    }
}