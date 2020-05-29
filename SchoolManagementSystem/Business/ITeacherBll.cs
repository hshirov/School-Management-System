﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ITeacherBll
    {
        Teacher GetTeacher(User user);
        Teacher GetTeacher(int id);
        List<Teacher> GetAll();
        Person GetPerson(int id);
        bool IsEmailInUse(string email);
        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(int id);
        bool IsPasswordValid(Teacher teacher);
    }
}
