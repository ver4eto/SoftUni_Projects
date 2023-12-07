using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        List<ISubject> subjects = new List<ISubject>();
        public IReadOnlyCollection<ISubject> Models =>subjects.AsReadOnly();

        public void AddModel(ISubject model)
        {
           subjects.Add(model);
        }

        public ISubject FindById(int id)
        {
            ISubject subject = subjects.FirstOrDefault(s=>s.Id==id);
            return subject;
        }

        public ISubject FindByName(string name)
        {
            ISubject subject = subjects.FirstOrDefault(s => s.Name == name);
            return subject;
        }
    }
}
