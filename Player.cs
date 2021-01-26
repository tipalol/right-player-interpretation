using Creatures.States.Player;

namespace Creatures
{
    internal class Player : Creature
    {
        protected override void Start()
        {
            base.Start();

            States.Add(nameof(Standing), new Standing(this));
            States.Add(nameof(Jumping), new Jumping(this));
            States.Add(nameof(Running), new Running(this));

            ChangeState(nameof(Standing));
        }
    }
}