using System;
using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Interfaces;

namespace ProjetoPista.Data.Repositories
{
	public class TamanhosRepository : GenericRepository<Tamanhos>, ITamanhosRepository
    {
        public TamanhosRepository(ApplicationContext context) 
			: base (context)
        {
        }


    }
    public class OtherRepository : GenericRepository<Tamanhos>, IOtherRepository
    {
        public OtherRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}
