using Data.Models;
using System.Collections.Generic;

namespace Business
{
    public interface ITeacherBll
    {
        /// <summary>
        /// Finds the first teacher in the table based on the given email and password in User.
        /// </summary>
        /// <param name="user">Stores email and password.</param>
        Teacher GetTeacher(User user);

        /// <summary>
        /// Finds the first teacher in the table based on the given id in User.
        /// </summary>
        /// <param name="id">Stores id.</param>
        Teacher GetTeacher(int id);

        /// <summary>
        /// Returns every teacher from the database
        /// </summary>
        List<Teacher> GetAll();

        /// <summary>
        /// Turns a instance of Teacher to a Person, which holds all the matching parameters from students and teachers
        /// </summary>
        /// <param name="id">Stores id.</param>
        Person GetPerson(int id);

        /// <summary>
        /// Checks if there is a teacher with the same email.
        /// </summary>
        /// <param name="email">Stores email.</param>
        bool IsEmailInUse(string email);

        /// <summary>
        /// Adds a teacher profile.
        /// </summary>
        /// <param name="teacher">Stores teacher information.</param>
        void AddTeacher(Teacher teacher);

        /// <summary>
        /// Updates the teacher profile information.
        /// </summary>
        /// <param name="teacher">Stores teacher information.</param>
        void UpdateTeacher(Teacher teacher);

        /// <summary>
        /// Deletes teacher profile.
        /// </summary>
        /// <param name="id">Stores teacher information.</param>
        void DeleteTeacher(int id);

        /// <summary>
        /// Checks if the user password is a valid password.
        /// </summary>
        /// <param name="teacher">Stores teacher password.</param>
        bool IsPasswordValid(Teacher teacher);
    }
}
