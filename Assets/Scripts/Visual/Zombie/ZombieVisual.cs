using UnityEngine;
using Zombie;

namespace Visual.Zombie
{
    public class ZombieVisual : MonoBehaviour
    {
        // data
        [SerializeField] private ZombieModel _zombie;
        [SerializeField] private Animator _animator;

        // logic
        private ZombieAnimatorController _zombieAnimatorController;

        private void Awake()
        {
            _zombieAnimatorController = new ZombieAnimatorController(
                _zombie,
                _animator,
                _zombie.attackEvent
            );
        }

        private void OnEnable()
        {
            _zombieAnimatorController.OnEnable();
        }

        private void OnDisable()
        {
            _zombieAnimatorController.OnDisable();
        }

        public void Update()
        {
            _zombieAnimatorController.Update();
        }
    }
}