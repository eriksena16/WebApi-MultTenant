﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_MultTenant.Context;
using WebApi_MultTenant.Model;


namespace WebApi_MultTenant.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutosController : ApiControllerBase
    {
        private readonly Contexto _contexto;
        public ProdutosController(Contexto contexto) : base()
        {
            _contexto = contexto;
        }
        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<List<Produto>> Get()
        {
            return await _contexto.Produtos.ToListAsync();
        }

        // GET api/<ProdutosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ProdutosController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Cadastro")]
        public Produto Post([FromBody] Produto produto)
        {
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();

            return produto;
        }


    }
}
