using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Application.Models;
using System.Data.SqlClient;

namespace Login_Application.Controllers
{
    public class UserController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-JDK7QHC\SQLEXPRESS; database=login; integrated security = SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(User user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM login where'" + user.Name + "'and password='" + user.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                ViewBag.Message = "Successfully Login";
                return View("Success");
            }
            else
            {
                con.Close();
                ViewBag.Message = "Wrong Login";
                return View("Error");
            }

        }
    }
}