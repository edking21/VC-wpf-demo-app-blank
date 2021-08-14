using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface IPole
    {
        int Id { get; set; }
        string Address { get; set; }
        string Latitude { get; set; }

    }
}
