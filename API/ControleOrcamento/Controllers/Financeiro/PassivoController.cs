using ControleOrcamento.Controllers.Base;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace ControleOrcamento.Controllers.Financeiro {
    [Route("api/passivo")]
    [ApiController]
    public class PassivoController : CrudBaseController<Passivo, int> {

        // private readonly IRepositorioBase<Ativo, int> _repositorio;
        public PassivoController(IRepositorioBase<Passivo, int> repositorio) : base(repositorio) {
            //  _repositorio = repositorio;
        }
    }

}