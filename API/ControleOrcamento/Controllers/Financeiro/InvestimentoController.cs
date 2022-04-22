using ControleOrcamento.Controllers.Base;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;


namespace ControleOrcamento.Controllers.Financeiro {
    [Route("api/investimento")]
    [ApiController]
    public class InvestimentoController : CrudBaseController<Investimento, int> {

        // private readonly IRepositorioBase<Ativo, int> _repositorio;
        public InvestimentoController(IRepositorioBase<Investimento, int> repositorio) : base(repositorio) {
            //  _repositorio = repositorio;
        }

    }
}