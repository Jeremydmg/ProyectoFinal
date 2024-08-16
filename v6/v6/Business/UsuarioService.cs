using System.Collections.Generic;
using v6.DataAccess.Repositories;

namespace v6.Business
{
    public class UsuarioService
    {
        private UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        // Otros métodos de lógica de negocio
    }
}
