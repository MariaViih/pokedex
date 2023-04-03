using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers.Services
{
    public interface IPokeService
    {
        List<Pokemon> GetPokemons();
        List<Tipo> GetTipos();
        Pokemon GetPokemon(int Numero);
        PokedexDto GetPokedexDto();
        DetailsDto GetDetailedPokemon(int Numero);
        Tipo GetTipo(string Nome);
    }
}