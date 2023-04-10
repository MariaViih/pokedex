using System.Text.Json;
using Pokedex.Models;

namespace Pokedex.Services;
public class PokeService : IPokeService
{
    private readonly IHttpContextAccessor _session;
    private readonly string pokemonFile = @"Data\Pokemons.json";
    private readonly string TiposFile = @"Data\tipo.json";
    public PokeService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }

    public List<Pokemon> GetPokemons()
    {
        PopularSessao();
        var Pokemons = JsonSerializer.Deserialize<List<Pokemon>>
             (_session.HttpContext.Session.GetString("Pokemons"));
        return Pokemons;
    }
    public List<Tipo> GetTipos()
    {
        PopularSessao();
        var tipos = JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }
    public Pokemon GetPokemon(int Numero)
    {
        var Pokemons = GetPokemons();
        return Pokemons.Where(p => p.Numero == Numero).FirstOrDefault();
    }
    public PokedexDto GetPokedexDto()
    {
        var pokes = new PokedexDto()
        {
            Pokemons = GetPokemons(),
            Tipos = GetTipos()
        };
        return pokes;
    }
    public DetailsDto GetDetailedPokemon(int Numero)
    {
        var Pokemons = GetPokemons();
        var poke = new DetailsDto()
        {
            Current = Pokemons.Where(p => p.Numero == Numero)
                .FirstOrDefault(),
            Prior = Pokemons.OrderByDescending(p => p.Numero)
                .FirstOrDefault(p => p.Numero < Numero),
            Next = Pokemons.OrderBy(p => p.Numero)
                .FirstOrDefault(p => p.Numero > Numero)
        };
        return poke;
    }
    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }
    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("tipos")))
        {
            _session.HttpContext.Session
                .SetString("Pokemons", LerArquivo(pokemonFile));
            _session.HttpContext.Session
                .SetString("Tipos", LerArquivo(TiposFile));
        }
    }
    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }

}
