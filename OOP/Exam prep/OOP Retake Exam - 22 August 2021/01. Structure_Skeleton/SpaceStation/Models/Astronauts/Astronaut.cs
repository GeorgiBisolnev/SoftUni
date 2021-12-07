using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        IBag bag;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            bag = new Backpack();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen>0;

        public IBag Bag => bag;

        public virtual void Breath()
        {
            if (Oxygen>=10)
            {
                this.Oxygen -= 10;
            } else
            {
                this.Oxygen = 0;
            }
        }
    }
}
