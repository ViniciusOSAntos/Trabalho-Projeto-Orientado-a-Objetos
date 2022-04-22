using ControleOrcamento.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;

namespace ControleOrcamento.Controllers.Usuarios {
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : CrudBaseController<Usuario, int> {

        // private readonly IRepositorioBase<Usuario, int> _repositorio;
        public UsuarioController(IRepositorioBase<Usuario, int> repositorio) : base(repositorio) {
            //  _repositorio = repositorio;
        }
    }

}