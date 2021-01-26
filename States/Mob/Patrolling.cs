using System;

namespace Creatures.States.Mob
{
    internal class Patrolling : Waiting
    {
        public Patrolling(Creature creature) : base(creature)
        {
        }

        protected override void DoLogic()
        {
            base.DoLogic();

        }
    }
}