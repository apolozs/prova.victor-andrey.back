using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/pagamento")]
    public class PagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public PagamentoController(DataContext context)
        {
            _context = context;
        }

        //POST: api pagamento/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Pagamento pagamento)
        {
            _context.Pagamentos.Add (pagamento);
            _context.SaveChanges();
            return Created("", pagamento);
        }

        //GET: api pagamento/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.Pagamentos
            .ToList());

        //GET: api pagamento/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Pagamento pagamento = _context.Pagamentos.Find(id);
            if  (pagamento == null)
            {
                return NotFound();
            }
            return Ok (pagamento);
        }

        //DELETE: /api pagamento/delete/bolacha
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            //Expressão lambda
            //Buscar um objeto na tabela de Pagamentos com base no nome
            Pagamento pagamento = _context.Pagamentos.FirstOrDefault (pagamento => pagamento.NomePagamento == name);

            if  (pagamento == null)
            {
                return NotFound();
            }
            _context.Pagamentos.Remove(pagamento);
            _context.SaveChanges();
            return Ok(_context.Pagamentos.ToList());
        }

        //PUT: api pagamento/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Pagamento pagamento)
        {
            _context.Pagamentos.Update (pagamento);
            _context.SaveChanges();
            return Ok (pagamento);
        }
    }
}