using System;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            var venda = _context.Vendas.ToList();


            return Ok(venda);
        }

        // [HttpPost]
        // [Route("create")]
        // public IActionResult create([FromBody] string cliente)
        // {
        //     // var carinho = _context.ItensVenda.Where(x => x.CarrinhoId == idCarrinho).ToList();
        //     // var pagamento = _context.Pagamentos.FirstOrDefault(x => x.NomePagamento == metodoPagamento);

        //     Venda venda = new Venda();
        //     // venda.Cliente = cliente;
        //     // venda.Pagamento = pagamento;
        //     // venda.Itens = carinho;
        //     _context.Vendas.Add(venda);
        //     _context.SaveChanges();
        //     return Created("", _context.Vendas.ToList());

        // }



        [HttpPost]
        [Route("bolinho/{cliente}/{idCarrinho}/{NomePagamento}")]
        public IActionResult bolinho([FromRoute] string cliente, string idCarrinho, string metodoPagamento)
        {
            var carinho = _context.ItensVenda.Where(x => x.CarrinhoId == idCarrinho).ToList();
            var pagamento = _context.Pagamentos.FirstOrDefault(x => x.NomePagamento == metodoPagamento);

            Venda venda = new Venda();
            venda.Cliente = cliente;
            venda.Pagamento = pagamento;
            venda.Itens = carinho;
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Ok(_context.Vendas.ToList());

        }

        [HttpGet]
        [Route("listItens")]
        public IActionResult listItens()
        {
            var venda = _context.ItensVenda.Include(x => x.Produto).ThenInclude(y => y.Categoria).ToList();
            return Ok(venda);
        }
    }

}