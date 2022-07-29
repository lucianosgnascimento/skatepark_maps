using System;
using ProjetoPista.Model.Entities;

namespace ProjetoPista.Model.Interfaces
{
    public interface IProfessoresRepository : IGenericRepository<Professores> { }
    public interface IPistaProfessorRepository : IGenericRepository<Pistas_Professores> { }


}
