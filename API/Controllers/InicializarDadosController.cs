using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { Id = 1, Nome = "Salgadinho" },
                    new Categoria { Id = 2, Nome = "Água" },
                    new Categoria { Id = 3, Nome = "Fruta" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {

                    new Produto { Id = 1, Nome = "Cheetos Chips", Preco = 2.99, Quantidade = 30, CategoriaId = 1 },
                    new Produto { Id = 2, Nome = "Cebolitos", Preco = 2.99, Quantidade = 23, CategoriaId = 1 },
                    new Produto { Id = 3, Nome = "Lays", Preco = 2.99, Quantidade = 25, CategoriaId = 1 },

                    new Produto { Id = 4, Nome = "Agua com Gás", Preco = 3.00, Quantidade = 100, CategoriaId = 2 },
                    new Produto { Id = 5, Nome = "Agua sem Gás", Preco = 2.00, Quantidade = 50, CategoriaId = 2 },
                    new Produto { Id = 6, Nome = "Agua de Bateria ", Preco = 5, Quantidade = 333, CategoriaId = 2 },


                    new Produto { Id = 7, Nome = "Maça", Preco = 0.53, Quantidade = 10, CategoriaId = 3 },
                    new Produto { Id = 8, Nome = "Abacaxi", Preco = 4.54, Quantidade = 13, CategoriaId = 3 },
                    new Produto { Id = 9, Nome = "Melão", Preco = 3.50, Quantidade = 33, CategoriaId = 3 },

                }
            );

            _context.Pagamentos.AddRange(new Pagamento[]
                {
                    new Pagamento { Id = 1, NomePagamento= "Boleto", Parcelamento = "N/T" },
                    new Pagamento { Id = 2, NomePagamento = "Cartão de Crédito", Parcelamento = "12x" },
                    new Pagamento { Id = 3, NomePagamento = "Pix", Parcelamento = "N/T" },
                }
            );


            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}


// Exercício 1 – Esse exercício não vale nota, mas deve ser realizado.

// 	No controller “InicializarDadosController.cs” alterar todos os seguintes dados (todas as informações devem ser diferentes):
// 	- Nome da categoria;
// 	- Nome dos produtos;
// 	- Preço dos produtos;
// 	- Quantidade dos produtos.
// 	Como o projeto foi desenvolvido com o banco de dados em memória, na pasta “Tests”, existe um arquivo para inicializar os dados sempre que for necessário.
