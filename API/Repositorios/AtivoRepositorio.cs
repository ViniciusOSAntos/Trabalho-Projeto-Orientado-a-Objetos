using ControleOrcamento.Banco;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleOrcamento.Repositorios {
    public class AtivoRepositorio : IRepositorioBase<Ativo, int> {
        private readonly DataContext _context;

        public AtivoRepositorio(DataContext context) {
            _context = context;
        }
        public void Deletar(int id) {
            var Ativo = _context.Ativos.Find(id);
            _context.Ativos.Remove(Ativo);
            _context.SaveChanges();
        }

        public IEnumerable<Ativo> ObterTodos() {
            return _context.Ativos.ToList();
        }

        public Ativo ObterPorId(int id) {
            var ativo = _context.Ativos.Find(id);
            if (ativo != null)
                return ativo;
            return new Ativo();
        }

        public void Inserir(Ativo model) {
            _context.Ativos.Add(model);
            _context.SaveChanges();
        }
        public void Atualizar(Ativo model) {

            var ativo = _context.Ativos.Find(model.Id);
            if(ativo != null)
            ativo.Valor = model.Valor;
            ativo.Data = model.Data;
            ativo.Valor = model.Valor;

            _context.Entry(ativo).State = EntityState.Modified;
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

