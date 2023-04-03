using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class DetailsDto
    {
        public Pokemon Prior {get; set;}
        public Pokemon current {get; set;}
        public Pokemon Next {get; set;}
    }
}