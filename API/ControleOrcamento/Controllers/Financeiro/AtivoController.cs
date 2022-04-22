using ControleOrcamento.Controllers.Base;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace ControleOrcamento.Controllers.Financeiro {
    [Route("api/ativo")]
    [ApiController]
    public class AtivoController : CrudBaseController<Ativo, int> {

       // private readonly IRepositorioBase<Ativo, int> _repositorio;
        public AtivoController(IRepositorioBase<Ativo, int> repositorio) : base(repositorio) {
          //  _repositorio = repositorio;
        }
      
    }
}