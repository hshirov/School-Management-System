using Data.Models;
using System.Collections.Generic;

namespace Business
{
    public interface IStudentBll
    {
        /// <summary>
        /// Finds the first student in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        Student GetStudent(User user);

        /// <summary>
        /// Finds the first student in the table based on the given id in User.
        /// </summary>
        /// <param name="id">Stores id.</param>
        Student GetStudent(int id);

        /// <summary>
        /// Returns every student from the database
        /// </summary>
        List<Student> GetAll();

        /// <summary>
        /// Finds a student with the given ID and returns every student from his class.
        /// </summary>
        /// <param name="id">Stores id.</param>
        List<Student> GetStudentsFromClass(int id);

        /// <summary>
        /// Finds a student with the given classNumber and classLetter and returns every student from his class.
        /// </summary>
        /// <param name="classNumber">Stores student grade.</param> <param name="classLetter">Stores student grade class.</param>
        List<Student> GetStudentsFromClass(int classNumber, string classLetter);

        /// <summary>
        /// Turns a instance of Student to a Person, which holds all the matching parameters from students and teachers
        /// </summary>
        /// <param name="id">Stores id.</param>
        Person GetPerson(int id);

        /// <summary>
        /// Checks if there is a student with the same email.
        /// </summary>
        /// <param name="email">Stores email.</param>
        bool IsEmailInUse(string email);

        /// <summary>
        /// Adds a student profile.
        /// </summary>
        /// <param name="student">Stores student information.</param>
        void AddStudent(Student student);

        /// <summary>
        /// Updates the student profile information.
        /// </summary>
        /// <param name="student">Stores student information.</param>
        void UpdateStudent(Student student);

        /// <summary>
        /// Deletes student profile.
        /// </summary>
        /// <param name="id">Stores id.</param>
        void DeleteStudent(int id);

        /// <summary>
        /// Checks if the user password is a valid password.
        /// </summary>
        /// <param name="student">Stores student information.</param>
        bool IsPasswordValid(Student student);
    }
}
