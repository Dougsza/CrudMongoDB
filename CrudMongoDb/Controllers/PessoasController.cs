using Microsoft.AspNetCore.Mvc;
using CrudMongoDb.Models;
using CrudMongoDb.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudMongoDb.Controllers {
    public class PessoasController : Controller {
        //Variáveis
        private readonly Contexto _pessoaContexto;

        //Construtor
        public PessoasController(IOptions<ConfigDB> opcoes) {
            _pessoaContexto = new Contexto(opcoes);
        }

        //Método assincrono
        public async Task <IActionResult> Index() {
            return View(await _pessoaContexto.Pessoas.Find(a => true).ToListAsync());
        }
        [HttpGet]
        public IActionResult NovaPessoa() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NovaPessoa(Pessoa pessoa) {
            pessoa.PessoaId = Guid.NewGuid();
            await _pessoaContexto.Pessoas.InsertOneAsync(pessoa);

            return RedirectToAction(nameof(Index));
        }
        //Atualizar
        [HttpGet]
        public async Task<IActionResult> AtualizarPessoa(Guid pessoaId) {
            Pessoa pessoa = await _pessoaContexto.Pessoas.Find(a => a.PessoaId == pessoaId).FirstOrDefaultAsync();
            return View(pessoa);
        }
        [HttpPost]
        public async Task<IActionResult>AtualizarPessoa(Pessoa pessoa) {
            await _pessoaContexto.Pessoas.ReplaceOneAsync(a => a.PessoaId == pessoa.PessoaId,pessoa);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
         public async Task<IActionResult>ExcluirPessoa(Guid pessoaId) {
            await _pessoaContexto.Pessoas.DeleteOneAsync(a => a.PessoaId == pessoaId);
            return RedirectToAction(nameof(Index));
        }
    }
}
