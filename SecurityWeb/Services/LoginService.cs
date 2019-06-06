using SecurityWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SecurityWeb.DataContext;
using System.Threading.Tasks;

namespace SecurityWeb.Services
{
    public interface ILoginService
    {
        Usuario Login(Usuario model);
        List<Usuario> Get();
    }
    public class LoginService : ILoginService
    {
        private readonly SecurityContext _context;

        public LoginService(SecurityContext context) => _context = context;

        public Usuario Login(Usuario model)
        {
            var isValid = new Usuario();
            try
            {
                if(model != null)
                {
                    isValid = _context.Usuarios.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                }                                
            }
            catch (Exception)
            {
                throw;
            }

            return isValid;
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }
    }
}
