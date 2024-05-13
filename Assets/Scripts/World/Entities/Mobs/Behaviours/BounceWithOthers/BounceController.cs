using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Utils.Data;
using UnityEngine;

namespace Scripts.World.Entities.Mobs.Behaviours.BounceWithOthers
{
    public class BounceController : MonoBehaviour
    {
        [SerializeField] private MovementData _movData;
        [SerializeField] private Animator _bounceAnimator;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Entity"))
            {
                _bounceAnimator.SetBool("Stunned", true);
                MovementIn2D.Stop(_movData);
                MovementIn2D.Bounce(_movData, transform.forward * -1);
                Invoke(nameof(FinishBouncing), 1f);
            }
        }

        private void FinishBouncing()
        {
            _bounceAnimator.SetBool("Stunned", false);
            _movData.IsStunned = false;
        }
    }
}
