using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers.Services
{
    public class PokeService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string pokemonFile = @"Data\Pokemons.json";
        private readonly string TiposFile = @"Data\tipo.json";

       
    }
}