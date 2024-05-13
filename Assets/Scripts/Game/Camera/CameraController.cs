using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Game.Camera
{
    public class CameraController : MonoBehaviour
    {
        public Transform player;
        public float speed = 2.0f;
        public float distance = 10.0f;

        private void Start()
        {
            transform.position = PerspectiveConversion(player.position);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, PerspectiveConversion(player.position), speed * Time.deltaTime);
        }

        private Vector3 PerspectiveConversion(Vector3 playerPosition)
        {
            float x = (playerPosition.x / 2) * Mathf.Sqrt(2);
            float z = (distance / 2) * Mathf.Sqrt(2);
            float y = (playerPosition.z / 2) * Mathf.Sqrt(2) + z;
            return new Vector3(x, y, -z);
        }
    }
}
