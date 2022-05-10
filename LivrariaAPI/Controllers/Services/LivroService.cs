using AutoMapper;
using FluentResults;
using LivrariaAPI.Data;
using LivrariaAPI.Data.DTOs;
using LivrariaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaAPI.Controllers.Services
{
    public class LivroService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public LivroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadLivroDTO Cadastro(CreateLivroDTO createLivroDTO)
        {
            var livro = _mapper.Map<Livro>(createLivroDTO);
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return _mapper.Map<ReadLivroDTO>(livro);
        }

        public List<ReadLivroDTO> Livros()
        {
            List<Livro> livros;
            livros = _context.Livros.ToList();
            if(livros == null)
            {
                return null;
            }
            List<ReadLivroDTO> readLivroDTO = _mapper.Map <List<ReadLivroDTO>>(livros);
            return readLivroDTO;

        }

        public ReadLivroDTO LivrosPorId(int id)
        {
            var livro = _context.Livros.FirstOrDefault(livro =>
            livro.ID == id);
            ReadLivroDTO readLivroDTO = _mapper.Map<ReadLivroDTO>(livro);
            if(livro == null)
            {
                return null;
            }
            return _mapper.Map<ReadLivroDTO>(readLivroDTO);
        }

        public Result Atualiza(int id, UpdateLivroDTO updateLivroDTO)
        {
            var livro = _context.Livros.FirstOrDefault(livro =>
            livro.ID == id);
            if (livro == null)
            {
                return Result.Fail("Livro não encontrado");
            }
            _mapper.Map(updateLivroDTO, livro);
            _context.SaveChanges();
            return Result.Ok();
        }

        internal Result Deleta(int id)
        {
            var livro = _context.Livros.FirstOrDefault(livro =>
             livro.ID == id);
            if(livro == null)
            {
                return Result.Fail("Livro não encontrado.");
            }
            _context.Remove(livro);
            _context.SaveChanges();
            return Result.Ok();
        }

        
    }
}
