using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface IPowerPole : IPole
    {
        string PowerWire { get; set; }
        string StreetLight { get; set; }

    }
}
