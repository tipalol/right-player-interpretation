using System.Collections;
using UnityEngine;

namespace Creatures.States.Player
{
    internal class Jumping : State
    {
        private Collider2D _collider;
        private bool _jumped;

        internal Jumping(Creature creature) : base(creature)
        {
            _collider = _creature.GetComponent<Collider2D>();
        }

        protected override void HandleInput()
        {
            //Just chill
        }

        protected override void DoLogic()
        {
            if (IsGrounded && _jumped)
            {
                _creature.ChangeState(nameof(Standing));
                return;
            }

            //TODO Stopping in air
        }

        private bool IsGrounded
        {
            get
            {
                float extraHeight = 0.01f;
                var groundLayer = _creature.GetModel.GroundLayer;

                RaycastHit2D hit = Physics2D.BoxCast(
                    _collider.bounds.center,
                    _collider.bounds.size,
                    0f,
                    Vector2.down,
                    extraHeight,
                    groundLayer);

                return hit.collider != null;
            }
        }

        internal override void OnEnter()
        {
            _jumped = false;
            _creature.StartCoroutine(WaitForJump(0.1f));
        }

        internal override void OnExit()
        {
            _jumped = false;
        }

        private IEnumerator WaitForJump(float delay)
        {
            yield return new WaitForSeconds(delay);
            _jumped = true;
            yield return null;
        }

    }
}