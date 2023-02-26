﻿using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AdcionaFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);

        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.duracao);
    }
}
