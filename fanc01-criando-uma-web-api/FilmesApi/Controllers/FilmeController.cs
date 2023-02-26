﻿using FilmesApi.Models;
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
    public Filme? listaFilmePorId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }

    [HttpPost]
    public void AdcionaFilme([FromBody] Filme filme)
    {
        filme.Id = ++id;
        filmes.Add(filme);

        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.duracao);
    }
}
