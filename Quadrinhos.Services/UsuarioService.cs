using Microsoft.AspNetCore.Identity;
using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Repository.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Quadrinhos.Services
{
    public class UsuarioService : ServiceBase<Usuario, int>, IUsuarioService
    {
        public UsuarioService(ApplicationDbContext db) : base(db)
        {
        }

        public override async Task<int> Insert(Usuario model)
        {
            GerarHash(model, model.Senha);

            _db.Add<Usuario>(model);

            return await _db.SaveChangesAsync();
        }

        public override async Task<int> Update(Usuario model)
        {
            GerarHash(model, model.Senha);

            _db.Update<Usuario>(model);

            return await _db.SaveChangesAsync();
        }

        private void GerarHash(Usuario usuario, string senha)
        {
            usuario.Senha = new PasswordHasher<Usuario>().HashPassword(usuario, senha);
        }

        private bool VerificarSenha(Usuario usuario, string senhaInformada)
        {
            return new PasswordHasher<Usuario>().VerifyHashedPassword(usuario, usuario.Senha, senhaInformada) != PasswordVerificationResult.Failed;
        }

        public Usuario Login(LoginContract login)
        {
            var usuario = base.Get()
                .Where(x => x.Email == login.Email)
                .FirstOrDefault();

            if(usuario == null || !VerificarSenha(usuario, login.Senha))
                return null;

            return usuario;
        }
    }
}
