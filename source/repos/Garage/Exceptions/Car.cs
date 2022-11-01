using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Car
    {
        public string? Brand { get; set; }
        public bool TotalLost { get; set; }
        public bool NeedsRepair { get; set; }

        public Car(string Brand,bool TotalLost,bool NeedsRepair)
        {
            
            
                this.Brand = Brand;
                this.TotalLost = TotalLost;
                this.NeedsRepair = NeedsRepair;
            if (TotalLost == true && NeedsRepair == false)
                throw new RepairMismatchException();
        }
    }
}
