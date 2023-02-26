using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpGet]
    public IEnumerable<Filme> listaFilmes(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ListaFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null)
        {
            return NotFound();
        }

        return Ok(filme);
    }

    [HttpPost]
    public IActionResult AdcionaFilme([FromBody] Filme filme)
    {
        filme.Id = ++id;
        filmes.Add(filme);

        return CreatedAtAction(
            nameof(ListaFilmePorId),
            new { id = filme.Id },
            value: filme
            );
    }
}
