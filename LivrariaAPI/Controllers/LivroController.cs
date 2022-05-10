using AutoMapper;
using FluentResults;
using LivrariaAPI.Controllers.Services;
using LivrariaAPI.Data;
using LivrariaAPI.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LivrariaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {

        private LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] CreateLivroDTO createLivroDTO)
        {
            ReadLivroDTO readLivroDTO = _livroService.Cadastro(createLivroDTO);
            return CreatedAtAction(nameof(LivrosPorId), new { ID = readLivroDTO.ID }, readLivroDTO);
        }

        [HttpGet]
        public IActionResult Livros()
        {
            List<ReadLivroDTO> readLivroDTO = _livroService.Livros();
            if (readLivroDTO == null)
            {
                return NotFound();
            }
            return Ok(readLivroDTO);
        }

        [HttpGet("{id}")]
        public IActionResult LivrosPorId(int id)
        {
            ReadLivroDTO readLivroDTO = _livroService.LivrosPorId(id);
            if(readLivroDTO == null)
            {
                return NotFound();
            }
            return Ok(readLivroDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] UpdateLivroDTO updateLivroDTO)
        {
            Result resultado = _livroService.Atualiza(id, updateLivroDTO);
            if(resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deleta(int id)
        {
            Result resultado = _livroService.Deleta(id);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    
    }
}
