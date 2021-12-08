using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository : IRepository<IDecoration>
    {

        private List<IDecoration> models = new List<IDecoration>();
        public DecorationRepository()
        {

        }
        public IReadOnlyCollection<IDecoration> Models => models;

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return models.FirstOrDefault();
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
