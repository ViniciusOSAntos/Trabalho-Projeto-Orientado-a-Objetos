using System;
using System.Collections.Generic;

namespace ControleOrcamento.Repositorios.Contratos {
    public interface IRepositorioBase<T, TPrimary> : IDisposable {
        IEnumerable<T> ObterTodos();
        T ObterPorId(TPrimary id);
        void Inserir(T model);
        void Deletar(TPrimary id);
        void Atualizar(T model);
    }
}
