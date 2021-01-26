namespace Creatures.States.Mob
{
    internal class Fighting : AIState
    {
        internal Fighting(Creature creature) : base(creature) { }

        protected override void DoLogic()
        {
            if (IsPlayerNear == false)
                _creature.ChangeState(nameof(Waiting));
        }
    }
}