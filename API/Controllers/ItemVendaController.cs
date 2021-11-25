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
    [Route("api/item")]
    public class ItemVendaController : ControllerBase
    {
        private readonly DataContext _context;
        public ItemVendaController(DataContext context)
        {
            _context = context;
        }

        //POST: api/item/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] ItemVenda item)
        {
            if (String.IsNullOrEmpty(item.CarrinhoId))
            {
                item.CarrinhoId = Guid.NewGuid().ToString();
            }
            item.Produto = _context.Produtos.Find(item.ProdutoId);
            _context.ItensVenda.Add(item);
            _context.SaveChanges();
            return Created("", item);
        }

        // GET: api/item/getbycartid/XXXXX-XXXX-XXXXXXXXXXX
        [HttpGet]
        [Route("getbycartid/{cartid}")]
        public IActionResult GetByCartId([FromRoute] string cartId)
        {
            List<ItemVenda>Itenscarrinho = _context.ItensVenda.Include(item => item.Produto.Categoria).Where(item => item.CarrinhoId == cartId).ToList();

            return Ok(Itenscarrinho);
            // (_context.ItensVenda
            //     .Include(item => item.Produto.Categoria)
            //     .Where(item => item.CarrinhoId == cartId)
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.ItensVenda
            .ToList());
    }
}
