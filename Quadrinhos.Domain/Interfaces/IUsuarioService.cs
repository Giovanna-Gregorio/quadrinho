using Quadrinhos.Domain.Contracts;
using Quadrinhos.Domain.Models;

namespace Quadrinhos.Domain.Interfaces
{
    public interface IUsuarioService : IServiceBase<Usuario, int>
    {
        Usuario Login(LoginContract login);
    }
}
