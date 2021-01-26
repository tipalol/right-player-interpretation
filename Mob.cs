using UnityEngine;
using Creatures.States.Mob;

namespace Creatures
{
    internal class Mob : Creature
    {
        [SerializeField] internal MobModel GetMobModel;

        protected override void Start()
        {
            base.Start();

            States.Add(nameof(Waiting), new Waiting(this));
            States.Add(nameof(Patrolling), new Patrolling(this));
            States.Add(nameof(Fighting), new Fighting(this));

            ChangeState(nameof(Waiting));
        }

        [System.Serializable]
        internal class MobModel
        {
            [SerializeField] internal float ActivationDistance;
        }
    }
}