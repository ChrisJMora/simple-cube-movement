using Scripts.Game;
using Scripts.World.Entities.Mobs.Behaviours.Movement.Types.DepthMotion;
using Scripts.World.Entities.Mobs.Behaviours.ReceiveDamage;
using Scripts.World.Entities.Mobs.Utils.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.World.Entities.Mobs.Behaviour.Death {
    public class DeathHandler : MonoBehaviour {
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameObject _entity;
        [SerializeField] private MobProperties _mobProperties;
        [SerializeField] private Animator _deathAnimator;
        
        private void OnEnable() {
            ReceiveDamageController.Die += DieWithLoot;
            NormalJump.Die += DieWithNotLoot;
        }

        private void OnDisable() {
            ReceiveDamageController.Die -= DieWithLoot;
            NormalJump.Die -= DieWithNotLoot;
        }

        private void DieWithLoot(GameObject entity, Animator deathAnimator) 
        {
            _entity = entity;
            _deathAnimator = deathAnimator;
            deathAnimator.SetBool("Died", true);
            Invoke(nameof(FinishDeath), 3f);
            Debug.Log("Died with loot");
        }

        private void DieWithNotLoot(GameObject entity)
        {
            _entity = entity;
            Destroy(_entity);
            // _gameController.CurrentNumberOfEnemies = 3f;
        }

        private void FinishDeath()
        {
            Debug.Log("Finishing death...");
            _deathAnimator.SetBool("Died", false);
            Destroy(_entity);
            Instantiate(_mobProperties.LootProperties.CollectablePrefab, _entity.transform.position, Quaternion.identity);
            // _gameController.CurrentNumberOfEnemies = 3f;
        }

        public void RestartScene() {
            Debug.Log("Restarting scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}