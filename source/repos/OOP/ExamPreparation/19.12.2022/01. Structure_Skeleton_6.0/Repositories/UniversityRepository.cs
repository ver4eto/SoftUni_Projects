using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> universities=new List<IUniversity>();
        public IReadOnlyCollection<IUniversity> Models => universities.AsReadOnly() ;

        public void AddModel(IUniversity model)
        {
            universities.Add(model) ;
        }

        public IUniversity FindById(int id)
        {
            IUniversity university = universities.FirstOrDefault(u => u.Id == id);
            return university;
        }

        public IUniversity FindByName(string name)
        {
            IUniversity university = universities.FirstOrDefault(u => u.Name == name);
            return university;
        }
    }
}
