﻿namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;
    using GameObjects.Enhancements;
    
using System;
    using MassEffect.GameObjects.Ships;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if(shipAlreadyExists)
            {
                throw new ArgumentException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            IStarship starship1 =  GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            GameEngine.Starships.Add(starship1);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);
                
                Enhancement enhancement = GameEngine.EnhancementFactory.Create(enhancementType);
                starship1.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
