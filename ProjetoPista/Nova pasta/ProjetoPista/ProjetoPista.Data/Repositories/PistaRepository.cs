using System;
using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ProjetoPista.Model.Dtos;

namespace ProjetoPista.Data.Repositories
{
    public class PistaRepository : GenericRepository<Pistas>, IPistaRepository
    {
        public PistaRepository(ApplicationContext context)
            : base(context)
        {
        }
        


    }

}
