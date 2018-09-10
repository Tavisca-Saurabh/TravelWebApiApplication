using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWebApi.Models;

namespace TravelWebApi.Interfaces
{
    public interface ITravelEntity
    {
         bool IsBooked  { get; set; }
         bool IsSaved { get; set; }

    }
}
