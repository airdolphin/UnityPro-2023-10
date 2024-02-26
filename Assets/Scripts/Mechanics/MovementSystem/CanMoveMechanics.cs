using Atomic;

namespace Mechanics.MovementSystem
{
    public sealed class CanMoveMechanics
    {
        private readonly AtomicVariable<bool> _canMove;
        private readonly AtomicVariable<bool> _isDead;


        public CanMoveMechanics(AtomicVariable<bool> isDead, AtomicVariable<bool> canMove)
        {
            _isDead = isDead;
            _canMove = canMove;
        }

        public void OnEnable()
        {
            _isDead.Subscribe(CanMove);
        }

        public void OnDisable()
        {
            _isDead.UnSubscribe(CanMove);
        }

        private void CanMove(bool value)
        {
            _canMove.Value = !value;
        }
    }
}