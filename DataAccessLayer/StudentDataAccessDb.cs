using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using CommonLayer.Models;

namespace DataAccessLayer
{
   public class StudentDataAccessDb
    {
        private DbConnection db = new DbConnection();

        public List<Student> GetStudents()
        {
            string query = "select * from student";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();
            while (reader.Read())
            {
                Student std = new Student();
                std.Id = (int)reader["Id"];
                std.Name = reader["Name"].ToString();
                std.Gender = reader["Gender"].ToString();
                std.Email = reader["Email"].ToString();
                std.Mobile = reader["Mobile"].ToString();
                std.CourseName = reader["CourseName"].ToString();
                std.Address = reader["Address"].ToString();
                std.fees = (int)reader["fees"];
                students.Add(std);
            }
            db.Cnn.Close();
            return students;
        }
        public bool CreateStudent(Student student)
        {
            string query = "insert into student values('" + student.Name + "','" + student.Gender + "','" + student.Email + "','" + student.Mobile +
                "','" + student.CourseName + "','" + student.Address + "','" + student.fees + "')";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool DeleteStudent(int id)
        {
            string query = "delete from student where id="+id+"";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool UpdateStudent(Student student)
        {
            string query = "update student set Name='"+student.Name+ "',Gender='" + student.Gender + "',Email='" + student.Email +
                "',Mobile='" + student.Mobile + "',CourseName='" + student.CourseName + "',Address='" + student.Address + "',fees='" + student.fees + "'where Id="+student.Id+"";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }
        public Student GetStudentsById(int id)
        {
            string query = "select * from student where id='"+id+"'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            
                Student std = new Student();
                std.Id = (int)reader["Id"];
                std.Name = reader["Name"].ToString();
                std.Gender = reader["Gender"].ToString();
                std.Email = reader["Email"].ToString();
                std.Mobile = reader["Mobile"].ToString();
                std.CourseName = reader["CourseName"].ToString();
                std.Address = reader["Address"].ToString();
                std.fees = (int)reader["fees"];


                db.Cnn.Close();
                return std;
            
        }
    }
}
