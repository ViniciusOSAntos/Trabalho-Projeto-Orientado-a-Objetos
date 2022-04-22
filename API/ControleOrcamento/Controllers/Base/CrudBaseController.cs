using ControleOrcamento.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace ControleOrcamento.Controllers.Base {
    public abstract class CrudBaseController<TEntidade, TPrimary> : ControllerBase {

        private readonly IRepositorioBase<TEntidade, TPrimary> _repositorio;

        public CrudBaseController(IRepositorioBase<TEntidade, TPrimary> repositorio) {
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult<TEntidade> obterTodos() {
            var users = _repositorio.ObterTodos();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<TEntidade> ObterPorId(TPrimary id) {
            var objeto = _repositorio.ObterPorId(id);

            if (objeto == null)
                return NotFound();
            else {
                return Ok(objeto);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] TEntidade model) {
            if (!ModelState.IsValid)
                return BadRequest();

            _repositorio.Inserir(model);
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(TPrimary id, [FromBody] TEntidade model) {
            if (!ModelState.IsValid)
                return BadRequest();
            var objeto = _repositorio.ObterPorId(id);

            if (objeto == null)
                return NotFound();

            _repositorio.Atualizar(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(TPrimary id) {
            var objeto = _repositorio.ObterPorId(id);

            if (objeto == null)
                return NotFound();

            _repositorio.Deletar(id);

            return NoContent();
        }
    }
}

