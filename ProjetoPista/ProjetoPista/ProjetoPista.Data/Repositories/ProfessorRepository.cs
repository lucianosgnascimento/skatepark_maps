using System;
using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ProjetoPista.Model.Dtos;

namespace ProjetoPista.Data.Repositories
{
    public class ProfessoresRepository : GenericRepository<Professores>, IProfessoresRepository
    {
        public ProfessoresRepository(ApplicationContext context)
            : base(context)
        {
        }

    }
    public class PistaProfessorRepository : GenericRepository<Pistas_Professores>, IPistaProfessorRepository
    {
        public PistaProfessorRepository(ApplicationContext context)
            : base(context)
        {
        }


    }


}
