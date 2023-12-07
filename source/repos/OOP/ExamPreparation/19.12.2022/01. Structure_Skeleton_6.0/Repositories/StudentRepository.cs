using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students = new List<IStudent>();
        public IReadOnlyCollection<IStudent> Models => students.AsReadOnly();

        public void AddModel(IStudent model)
        {
            students.Add(model);
        }

        public IStudent FindById(int id)
        {
            IStudent student = students.FirstOrDefault(s => s.Id == id);
            return
                student;
        }

        public IStudent FindByName(string name)
        {
            string firstName = name.Split(" ",StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];
            IStudent student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName==lastName);
            return
                student;
        }
    }
}
