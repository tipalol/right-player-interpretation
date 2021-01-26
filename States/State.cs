namespace Creatures.States
{
    internal abstract class State
    {
        protected Creature _creature;

        internal State(Creature creature)
            => _creature = creature;

        internal virtual void Tick()
        {
            HandleInput();
            DoLogic();
        }

        internal virtual void OnEnter() { }
        internal virtual void OnExit() { }

        protected virtual void HandleInput() { }
        protected abstract void DoLogic();
    }
}