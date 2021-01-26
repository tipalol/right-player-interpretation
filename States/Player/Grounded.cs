using UnityEngine;

namespace Creatures.States.Player
{
    internal class Grounded : State
    {
        protected float _moveDirection;
        protected bool IsJumped;
        
        protected Rigidbody2D _self;
        protected Animator _animator;

        internal Grounded(Creature creature) : base(creature)
        {
            _self = creature.GetComponent<Rigidbody2D>();
            _animator = _creature.GetComponent<Animator>();
        }

        protected override void HandleInput()
        {
            _moveDirection = Input.GetAxis("Horizontal");
            IsJumped = Input.GetKeyDown(KeyCode.Space);
        }

        protected override void DoLogic()
        {
            if (IsJumped)
            {
                Jump();
                _creature.ChangeState(nameof(Jumping));
                return;
            }

            _animator.SetBool("isRunning", IsMovingX);

            if (_moveDirection == 0)
                return;

            SetRightRotate();

            var velocity = _self.velocity;
            var move = new Vector2(_moveDirection * _creature.GetModel.Speed, velocity.y);

            _self.velocity = move;
        }

        protected bool IsStanding => Mathf.Abs(_self.velocity.x) == 0;
        protected bool IsMovingRight => _self.velocity.x > 0;
        protected bool IsMovingX => Mathf.Abs(_self.velocity.x) > 0.1f;

        protected void Jump()
        {
            var force = new Vector2(0, 1 * _creature.GetModel.JumpForce);
            _self.AddForce(force, ForceMode2D.Impulse);
        }

        protected void SetRightRotate()
        {
            var scale = _self.transform.localScale;
            
            _self.transform.localScale = new Vector3(
                    Mathf.Abs(scale.x) * (IsMovingRight ? 1 : -1),
                    scale.y,
                    scale.z);
        }
    }
}