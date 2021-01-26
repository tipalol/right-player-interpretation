namespace Creatures.States.Mob
{
    internal class Waiting : AIState
    {
        internal Waiting(Creature creature) : base(creature) { }

        protected override void DoLogic()
        {
            if (IsPlayerNear)
                _creature.ChangeState(nameof(Fighting));
        }
    }
}