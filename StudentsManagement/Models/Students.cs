using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsManagement.Models
{
    public class Students
    {
        [Display(Name = "STT")]
        public int ID { set; get; } 
        [ Required(ErrorMessage =" mời nhập họ tên sinh viên")]
        [Display(Name =" ho va ten")]
        public string FullName { set; get; }
        [Required(ErrorMessage = " moi nhap dia chi")]
        [Display(Name = " dia chi")]
        public string Address { set; get; }


    }
   public class StudentList
    {
        DBConection db;
        public StudentList()
        {
                db = new DBConection();
        }
        public List<Students> GetStudents (String ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
                sql = "SELECT * FROM Students";
            else
                sql = "SELECT * FROM Students WHERE ID = " + ID;

            List<Students> stuList = new List<Students>();
            DataTable dt = new DataTable();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            Students tmpStu;
            for ( int i=0; i< dt.Rows.Count; i++ )
            {
                tmpStu = new Students();
             
                tmpStu.ID = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                tmpStu.FullName = dt.Rows[i]["FullName"].ToString();
                tmpStu.Address = dt.Rows[i]["Address"].ToString();
                stuList.Add(tmpStu);
            }
            return stuList;
            

        }

        internal void UpdateStudents(StudentList stu)
        {
            throw new NotImplementedException();
        }

        public void AddStudent( Students stu)
        {
            string sql = "INSERT INTO Students(fullname,address) VALUES(N'" + stu.FullName +
                "',N'" + stu.Address + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();  
            con.Close();

        }
        public void AddData(string name, string date, string address, string sex, string number,string uname,string pwd)
        {
            string sql = "INSERT INTO Account(HoTen,NgaySinh,DiaChi,GioiTinh,SoDT,TaiKhoan,MatKhau) VALUES(N'" + name +
                "','" + date + "',N'" + address + "',N'" + sex + "', N'" + number + "',N'" + uname + "',N'" + pwd + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void AddData1( string uname, string pwd)
        {
            string sql = "INSERT INTO Account(TaiKhoan,MatKhau) VALUES(N'" + uname + "',N'" + pwd + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();

        }
        public void UpdateStudents ( Students Stu )
        {
            string sql = " UPDATE Students Fullname = N'" + Stu.FullName + "', Address = 'N" +
                Stu.Address + "' WHERE ID = " + Stu.ID;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
