using Scripts.Game;
using UnityEngine;

namespace Scripts.World.Entities.Collectables.Behaviours.PickUp
{
    public class PickUpController : MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                _gameController.CurrentScore += 0.25f;
            }
        }
    }
}
