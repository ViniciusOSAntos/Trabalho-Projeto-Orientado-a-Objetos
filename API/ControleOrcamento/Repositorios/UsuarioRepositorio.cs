using ControleOrcamento.Banco;
using ControleOrcamento.Models;
using ControleOrcamento.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleOrcamento.Repositorios {
    public class UsuarioRepositorio : IRepositorioBase<Usuario, int> {
        private readonly DataContext _context;

        public UsuarioRepositorio(DataContext context) {
            _context = context;
        }
        public void Deletar(int id) {
            var Usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(Usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> ObterTodos() {
            return _context.Usuarios.ToList();
        }

        public Usuario ObterPorId(int id) {
            return _context.Usuarios.Find(id);
        }

        public void Inserir(Usuario model) {
            _context.Usuarios.Add(model);
            _context.SaveChanges();
        }
        public void Atualizar(Usuario model) {

            var Usuario = _context.Usuarios.Find(model.Id);
            //if (Usuario != null)
            //    Usuario.Valor = model.Valor;
            //    Usuario.Data = model.Data;
            //    Usuario.Valor = model.Valor;

            _context.Entry(Usuario).State = EntityState.Modified;
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

