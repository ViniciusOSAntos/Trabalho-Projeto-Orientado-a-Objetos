using ControleOrcamento.Banco;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleOrcamento.Repositorios {
    public class InvestimentoRepositorio : IRepositorioBase<Investimento, int> {
        private readonly DataContext _context;

        public InvestimentoRepositorio(DataContext context) {
            _context = context;
        }
        public void Deletar(int id) {
            var Investimento = _context.Investimentos.Find(id);
            _context.Investimentos.Remove(Investimento);
            _context.SaveChanges();
        }

        public IEnumerable<Investimento> ObterTodos() {
            return _context.Investimentos.ToList();
        }

        public Investimento ObterPorId(int id) {
            return _context.Investimentos.Find(id);
        }

        public void Inserir(Investimento model) {
            _context.Investimentos.Add(model);
            _context.SaveChanges();
        }
        public void Atualizar(Investimento model) {

            var Investimento = _context.Investimentos.Find(model.Id);
            if (Investimento != null)
                Investimento.Valor = model.Valor;
            Investimento.Data = model.Data;
            Investimento.Valor = model.Valor;

            _context.Entry(Investimento).State = EntityState.Modified;
            _context.SaveChanges();

        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

