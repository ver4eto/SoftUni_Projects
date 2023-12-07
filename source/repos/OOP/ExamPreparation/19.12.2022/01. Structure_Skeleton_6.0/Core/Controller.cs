using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private StudentRepository studentRepository;
        private UniversityRepository universityRepository;
        private SubjectRepository subjectRepository;

        public Controller()
        {
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
            subjectRepository = new SubjectRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = studentRepository.FindByName(firstName + " " + lastName);
            if (student != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            int id = studentRepository.Models.Count() + 1;
            student = new Student(id, firstName, lastName);
            studentRepository.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, "StudentRepository");

        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            ISubject subject = subjectRepository.FindByName(subjectName);
            if (subject != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            int countOfCurrentaddedSubjects = subjectRepository.Models.Count();

            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(countOfCurrentaddedSubjects + 1, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(countOfCurrentaddedSubjects + 1, subjectName);
            }
            else
            { subject = new HumanitySubject(countOfCurrentaddedSubjects + 1, subjectName); }
            subjectRepository.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, "SubjectRepository");
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universityRepository.FindByName(universityName);
            if (university != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> subjectsIds = new List<int>();
            foreach (var subject in requiredSubjects)
            {
                subjectsIds.Add(subjectRepository.FindByName(subject).Id);
            }
            int id = universityRepository.Models.Count + 1;
            university = new University(id, universityName, category, capacity, subjectsIds);
            universityRepository.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, "UniversityRepository");
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
            string secondName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

            IStudent student = studentRepository.FindByName(studentName);
            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, secondName);
            }
            IUniversity university = universityRepository.FindByName(universityName);
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            bool hasCoveredALl = university.RequiredSubjects.All(x => student.CoveredExams.Any(y => x == y));
            if (hasCoveredALl == false)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            IUniversity currentUniversity = student.University;
            if (currentUniversity!=null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, secondName, universityName);
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, secondName, universityName);

        }

        public string TakeExam(int studentId, int subjectId)
        {

            IStudent student = studentRepository.FindById(studentId);
            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
            ISubject subject = subjectRepository.FindById(subjectId);
            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universityRepository.FindById(universityId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            int addmitedStudents = studentRepository.Models
                .Count(s=>s.University!=null && s.University.Name == university.Name);
            sb.AppendLine($"Students admitted: {addmitedStudents}");
            sb.AppendLine($"University vacancy: {university.Capacity-addmitedStudents}");
            return sb.ToString().TrimEnd();
        }
    }

   

    
}

