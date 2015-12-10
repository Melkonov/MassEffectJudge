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
    class Frigate : Starship
    {
        private int projectilesFired;

        public Frigate(string name , StarSystem location)
            : base(name,60,50,30,220,location)
        {

        }

        public override string ToString()
        {
            string output = base.ToString();
            if (Health > 0)
            {
                output += string.Format("Projectiles fired: {0}", this.projectilesFired);
            }
            return output;
            
        }

        public override IProjectile ProduceAttack()
        {
            projectilesFired++;
            return new ShieldReaver(this.Damage);
        }
        
    }
}
