using System;
using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Interfaces;

namespace ProjetoPista.Data.Repositories
{
	public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
		public UsuarioRepository(ApplicationContext context) 
			: base (context)
        {
        }
    }
}
