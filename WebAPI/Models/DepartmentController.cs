using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace WebAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private const string V = "application/json";
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get([FromQuery] Department department)
        {
            //Defined Variables
            string connectionString;
            SqlConnection connection;
            
            //Assign connectionString
            connectionString = _configuration.GetConnectionString("EmployeeAppCon");
            
            //Assigning values and method to variable
            connection = new SqlConnection(connectionString);
            connection.Open();
           
            //Defined variables
            SqlCommand command;
            SqlDataReader dataReader;
            String sqlQuery;
            //All declarations of output that we will receive from API (All data is added in while loop as of 12.05.2022)
            List<object> DepartmentID = new List<object>();
            List<object> DepartmentName = new List<object>();
            List<object> DataWrapper = new List<object>();
            //Assigning values, methods to variables
            sqlQuery = "Select DepartmentID, DepartmentName from department";
            command = new SqlCommand(sqlQuery, connection);
            dataReader =  command.ExecuteReader();
            int i = 0;
            while (dataReader.Read())
            {
                // Output = Output + dataReader.GetValue(0) + dataReader.GetValue(1) + " | ";
                //Output.Add(new string() { dataReader.GetValue(0) }) ;
                DepartmentID.Add(dataReader.GetValue(0));
                DepartmentName.Add(dataReader.GetValue(1));
                //Output.Add(dataReader.GetValue(0) + dataReader.GetValue(1) + "|");
                i++;
            }
            DataWrapper.Add(DepartmentID);
            DataWrapper.Add(DepartmentName);

            //Close every object
            dataReader.Close();
            command.Dispose();
            connection.Close();
            //In the end return everything that is inside output
            return new JsonResult(DataWrapper);
        }
        [HttpPost]

        public JsonResult Post([FromQuery]Department department)
        {
            Response.ContentType = "application/json";
            Request.ContentType = "application/json";
            string query =
                @"insert into dbo.Department values('" + department.DepartmentName + @"')
                ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConnection.Close();
                }
            }
            return new JsonResult("Added successfully");
        }
        [HttpPut]
        public JsonResult Put([FromQuery]Department department)
        {
            string query = $@"update dbo.Department set DepartmentName = '{department.DepartmentName}' where DepartmentID = '{department.DepartmentID}'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            
            using(SqlConnection myConnection = new SqlConnection(sqlDataSource))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                     myConnection.Close();
                }
            }
            return new JsonResult("Changed successfully!");
        }
    }

}
