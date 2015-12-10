namespace MassEffect.Engine.Commands
{
    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;
    using System.Linq;
    using System;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {

        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship ship = GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            this.ValidateAlive(ship);

            var previousLocation = ship.Location;

            StarSystem destination = GameEngine.Galaxy.StarSystems.FirstOrDefault(d => d.Name == destinationName);

            if(previousLocation.Name == destinationName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            GameEngine.Galaxy.TravelTo(ship, destination);
            Console.WriteLine(Messages.ShipTraveled,shipName,previousLocation.Name, destinationName);
 
        }
    }
}
