using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProject03.multi
{
    public class Cellphone : Item
    {
        private ICollection<int> _workingFrequencies;

        public ICollection<int> WorkingFrequencies
        {
            get => _workingFrequencies.ToHashSet();
            set => _workingFrequencies = value ?? throw new ArgumentNullException();
        }

        public Cellphone(int idItem, string make, string model, decimal price, ICollection<int> workingFrequencies) :
            base(idItem, make, model, price)
        {
            WorkingFrequencies = workingFrequencies;
        }
    }
}