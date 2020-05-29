using Data.Models;
using System.Collections.Generic;

namespace Business
{
    public interface IStudentBll
    {       
        Student GetStudent(User user);
        Student GetStudent(int id);
      
        List<Student> GetAll();        
        List<Student> GetStudentsFromClass(int id);     
        List<Student> GetStudentsFromClass(int classNumber, string classLetter);     
        Person GetPerson(int id);    
        bool IsEmailInUse(string email);       
        void AddStudent(Student student);     
        void UpdateStudent(Student student);    
        void DeleteStudent(int id);       
        bool IsPasswordValid(Student student);
    }
}
