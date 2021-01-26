namespace Creatures.States.Player
{
    internal class Running : Grounded
    {
        internal Running(Creature creature) : base(creature) { }

        protected override void DoLogic()
        {
            base.DoLogic();

            if (IsStanding)
                _creature.ChangeState(nameof(Standing));
        }


    }
}