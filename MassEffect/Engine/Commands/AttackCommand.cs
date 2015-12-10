namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System;
    using System.Linq;
    
    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            var attacker = GameEngine.Starships.FirstOrDefault(i => i.Name == attackerName);
            var target = GameEngine.Starships.FirstOrDefault(i => i.Name == targetName);

            this.ProccesStarshipBattle(attacker, target);
            
        }
        private void ProccesStarshipBattle(IStarship attacker, IStarship target)
        {
            base.ValidateAlive(attacker);
            base.ValidateAlive(target);

            bool isInStarSystem = (attacker.Location.Name == target.Location.Name);


            if (!isInStarSystem)
            {
                throw new ArgumentOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attacker.ProduceAttack();
            target.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked,attacker.Name, target.Name);

            if(target.Shields < 0)
            {
              target.Shields = 0;
            }
            if(target.Health <0)
            {
                target.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, target.Name);
            }
        }
       
    }
}
