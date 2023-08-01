using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using AngularBackEnd.Models;

namespace AngularBackEnd.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController:ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        //private readonly object Request;

        public EmployeesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Id , FirstName, LastName ,Phone, Email from Employees";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppcon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            string query = @"Insert into Employees
            (FirstName, LastName,Phone,Email)
            values (@FirstName, @LastName,@Phone,@Email)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppcon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    mycmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    mycmd.Parameters.AddWithValue("@Phone", emp.Phone);
                    mycmd.Parameters.AddWithValue("@Email", emp.Email);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");

        }

        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            string query = @"update Employees
                             set FirstName= @FirstName,
                             LastName = @LastName,
                             Phone = @Phone,
                             Email = @Email
                             Where Id = @Id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppcon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@Id", emp.Id);
                    mycmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                    mycmd.Parameters.AddWithValue("@LastName", emp.LastName);
                    mycmd.Parameters.AddWithValue("@Phone", emp.Phone);
                    mycmd.Parameters.AddWithValue("@Email", emp.Email);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{Id}")]
        public JsonResult Delete(int Id)
        {
            string query = @"Delete from Employees
                             where Id = @Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeesAppcon");
            SqlDataReader myReader;
            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand mycmd = new SqlCommand(query, mycon))
                {
                    mycmd.Parameters.AddWithValue("@ID", Id);
                    myReader = mycmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Delete Successfully");

        }

    }
}
