using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCal
{
    class Dough
    {
        private string flourType;
        private double weight;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public Dough()
        {

        }
        public string FlourType
        {
            get { return flourType.ToLower(); }
            private set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                   flourType = value; 
                }
                else

                throw new ArgumentException("Invalid type of dough.");
            }
        }
        

        public string BakingTechnique
        {
            get { return bakingTechnique.ToLower(); }
            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else throw new ArgumentException("Invalid type of dough.");
            }
        }
        

        public double Weight
        {
            get { return weight; }
            private set
            {

                if (value<=200 && value>=0)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double CalculCallories()
        {
            double fType = (FlourType == "white" ? 1.5 : 1.0);
            double bTechnique = (BakingTechnique == "crispy" ? 0.9 : (BakingTechnique == "chewy" ? 1.1 : 1.0));

            return (2.0*Weight)*fType*bTechnique;
        }

    }
}
