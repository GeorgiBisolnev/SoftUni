using Gym.Models.Athletes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;
        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }
        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Athlete name cannot be null or empty.");
                }

                fullName = value;
            }
        }

        public string Motivation
        {
            get => motivation;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The motivation cannot be null or empty.");
                }

                motivation = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get => numberOfMedals;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Athlete's number of medals cannot be below 0.");
                }

                numberOfMedals = value;
            }
        }

        public abstract void Exercise();

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
