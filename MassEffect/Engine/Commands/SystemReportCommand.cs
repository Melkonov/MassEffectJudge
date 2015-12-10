using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine.Commands
{
    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {

        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            IEnumerable<IStarship> intactShips = GameEngine.Starships.Where(s => s.Health > 0).OrderBy(s => s.Health).ThenBy(s => s.Shields);

            StringBuilder output = new StringBuilder();
            output.Append("Intact ships:");
            output.Append(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            IEnumerable<IStarship> destroyedShips = GameEngine.Starships.Where(s => s.Health < 0).OrderBy(s => s.Name);
            output.Append("Destroyed ships:");
            output.Append(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString());


            


        }
    }
}
