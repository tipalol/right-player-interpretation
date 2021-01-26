namespace Creatures.States.Player
{
    internal class Standing : Grounded
    {
        internal Standing(Creature creature) : base(creature) { }

        protected override void HandleInput()
            => base.HandleInput();

        protected override void DoLogic()
        {
            base.DoLogic();

            if (_moveDirection != 0)
                _creature.ChangeState(nameof(Running));
        }
    }
}