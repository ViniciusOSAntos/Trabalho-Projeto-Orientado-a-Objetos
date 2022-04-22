using ControleOrcamento.Banco;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleOrcamento.Repositorios {
    public class PassivoRepositorio : IRepositorioBase<Passivo, int> {
        private readonly DataContext _context;

        public PassivoRepositorio(DataContext context) {
            _context = context;
        }
        public void Deletar(int id) {
            var Passivo = _context.Passivos.Find(id);
            if(Passivo != null) {
                _context.Passivos.Remove(Passivo);
                _context.SaveChanges();
            }
            return;
         
        }

        public IEnumerable<Passivo> ObterTodos() {
            return _context.Passivos.ToList();
        }

        public Passivo ObterPorId(int id) {
            var passivo = _context.Passivos.Find(id);
            if (passivo != null)
                return passivo;
            return new Passivo();
        }

        public void Inserir(Passivo model) {
            _context.Passivos.Add(model);
            _context.SaveChanges();
        }
        public void Atualizar(Passivo model) {

            var Passivo = _context.Passivos.Find(model.Id);
            if (Passivo != null)
                Passivo.Valor = model.Valor;
            Passivo.Data = model.Data;
            Passivo.Valor = model.Valor;

            _context.Entry(Passivo).State = EntityState.Modified;
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

