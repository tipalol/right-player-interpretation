using UnityEngine;

namespace Creatures.States.Mob
{
    internal abstract class AIState : State
    {
        protected GameObject _player;
        protected float _activeDistance;

        internal AIState(Creature creature) : base(creature)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _activeDistance = (_creature as Creatures.Mob).GetMobModel.ActivationDistance;
        }

        protected bool IsPlayerNear
        {
            get
            {
                var distance = Vector2.Distance(
                    _creature.transform.position,
                    _player.transform.position);

                return distance <= _activeDistance;
            }
        }
    }
}