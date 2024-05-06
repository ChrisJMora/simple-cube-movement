using Scripts.CustomAttributes;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviour.Move
{
    [System.Serializable]
    public class MovUtilities
    {
        private const float JumpHeight = 1f;
        private const float MinDistance = 0.05f;

        private Vector3 direction;
        [ReadOnly] public Vector3 currentPosition;
        [ReadOnly] public Vector3 targetPosition;
        [ReadOnly] public Vector3 destinyPosition;
        private float currentHeight;

        [ReadOnly] public bool ReachDestination = true;
        private bool isJumping;
        private bool isFalling;

        public MovUtilities(Vector3 origin)
        {
            currentPosition = targetPosition = destinyPosition = origin;
            currentHeight = 0;
        }

        public void Move(Transform entity, float distance, float speed, float xInput, float zInput)
        {
            if (CheckWall(targetPosition))
            {
                Jump(entity, speed);
            }
            else if (!CheckWall(targetPosition + Vector3.down))
            {
                Fall(entity, speed);
            }
            if (!isJumping && !isFalling)
            {
                UpdatePositions(entity, distance, speed, xInput, zInput);
            }
        }

        private void UpdatePositions(Transform entity, float distance, float speed, float xInput, float zInput)
        {
            // Check if the entity has reached the target position
            if (Vector3.Distance(currentPosition, targetPosition) <= MinDistance && !ReachDestination)
            {
                targetPosition += direction;
                Debug.Log("Target position updated to: " + targetPosition);
            }

            // Update the position of the entity
            UpdateEntityPosition(entity, speed, targetPosition);

            // Check if the entity has reached the destiny position
            if (Vector3.Distance(currentPosition, destinyPosition) <= MinDistance)
            {
                ReachDestination = true;
            }

            if (xInput == 0 && zInput == 0)
            {
                return; // No input, no movement
            }

            if (ReachDestination)
            {
                Debug.Log("Moving to the next destination");
                direction = SetUpDirection(entity, xInput, zInput);
                destinyPosition += direction * distance;
                ReachDestination = false;
            }
        }

        private void Jump(Transform entity, float speed)
        {
            isJumping = true;
            UpdateEntityPosition(entity, speed, currentPosition + Vector3.up);

            if (entity.position.y >= currentHeight + JumpHeight)
            {
                FinishJump();
            }
        }

        private void FinishJump()
        {
            currentHeight += JumpHeight;
            targetPosition += Vector3.up;
            destinyPosition += Vector3.up;
            isJumping = false;
        }

        private void Fall(Transform entity, float speed)
        {
            isFalling = true;
            UpdateEntityPosition(entity, speed, targetPosition);

            if (Vector3.Distance(entity.position, targetPosition) <= MinDistance)
            {
                FinishFall();
            }
        }

        private void FinishFall()
        {
            currentHeight -= JumpHeight;
            targetPosition += Vector3.down;
            destinyPosition += Vector3.down;
            isFalling = false;
        }

        public void Stop()
        {
            destinyPosition = targetPosition;
        }

        private bool CheckWall(Vector3 target)
        {
            return Physics.CheckSphere(target, MinDistance, LayerMask.GetMask("Wall"));
        }

        private void UpdateEntityPosition(Transform entity, float speed, Vector3 targetPosition)
        {
            currentPosition = entity.position;
            entity.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }

        private Vector3 SetUpDirection(Transform entity, float x, float z)
        {
            if (Mathf.Abs(x) == 1f)
            {
                return SetUpHorizontalRotation(entity, x);
            }
            else if (Mathf.Abs(z) == 1f)
            {
                return SetUpVerticalRotation(entity, z);
            }
            return Vector3.zero;
        }

        private Vector3 SetUpHorizontalRotation(Transform entity, float orientation)
        {
            entity.rotation = Quaternion.Euler(0f, orientation * 90f, 0f);
            return new Vector3(0f, 0f, orientation);
        }

        private Vector3 SetUpVerticalRotation(Transform entity, float orientation)
        {
            entity.rotation = Quaternion.Euler(0f, orientation == 1f ? 0f : 180f, 0f);
            return new Vector3(orientation, 0f, 0f);
        }
    }
}
