using MassEffect.GameObjects.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    class Cruiser : Starship
    {
         public Cruiser(string name ,StarSystem location)
            : base(name,100,100,50,300,location)
        {

        }

         public override IProjectile ProduceAttack()
         {
             return new PenetrationShell(this.Damage);
         }
        
    }
}
