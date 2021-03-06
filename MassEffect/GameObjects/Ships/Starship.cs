﻿using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private List<Enhancement> enhancements;

        protected Starship(string name ,int health,int shields,int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Shields { get; set; }
        public int Damage { get; set; }
        public double Fuel { get; set; }
        public StarSystem Location { get; set; }



        public abstract IProjectile ProduceAttack();


        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }



        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        public  void AddEnhancement(Enhancement enhancement)
        {
            if(enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }

            ApplyEnhancementEffects(enhancement);

        }
        private void ApplyEnhancementEffects(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);
            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if(this.Health <= 0 )
            {
                output.Append("Destroyed");
            }
            else
            {
                output.AppendLine(string.Format("--Name: {0}", this.Name));
                output.AppendLine(string.Format("--Health: {0}", this.Health));
                output.AppendLine(string.Format("--Shields: {0}", this.Shields));
                output.AppendLine(string.Format("--Damage: {0}", this.Damage));
                output.AppendLine(string.Format("--Fuel: {0}", this.Fuel));
                output.AppendLine(string.Format("--Location: {0}", this.Location.Name));
            }

            return output.ToString();
        }

    }
}
