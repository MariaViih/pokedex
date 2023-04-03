using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokedexDto
    {
        public List<Tipo> Tipos {get; set;}
        public List<Pokemon> Pokemons {get; set;}
    }
}