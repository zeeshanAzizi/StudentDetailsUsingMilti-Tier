using System;
using System.Collections.Generic;
using CommonLayer.Models;
using DataAccessLayer;
namespace BussinessLayer
{
    public class StudentBussiness
    {
        private StudentDataAccessDb studentData;
        public StudentBussiness()
        {
            studentData = new StudentDataAccessDb();
        }
        public List<Student> GetStudents()
        {
            return studentData.GetStudents();
        }
        public bool CreateStudent(Student student)
        {
            return studentData.CreateStudent(student);
        }
        public bool DeleteStudent(int id)
        {
            return studentData.DeleteStudent(id);
        }
        public bool UpdateStudent(Student student)
        {
            return studentData.UpdateStudent(student);
        }
        public Student GetStudentsById(int id)
        {
            return studentData.GetStudentsById(id);
        }
    }
}
