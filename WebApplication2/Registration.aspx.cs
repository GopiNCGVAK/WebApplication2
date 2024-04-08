using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=CGVAK-LT191\\SQLEXPRESS2019;Initial Catalog=Registration;Integrated Security=True"; // Replace YourDatabaseName with your actual database name
            string tableName = "RegistrationInfo";

            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;

            // Construct SQL query
            string query = $"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}') " +
                           $"CREATE TABLE {tableName} (ID INT IDENTITY(1,1) PRIMARY KEY, FirstName NVARCHAR(100), LastName NVARCHAR(100), PhoneNumber NVARCHAR(20), Email NVARCHAR(100)); " +
                           $"INSERT INTO {tableName} (FirstName, LastName, PhoneNumber, Email) VALUES (@FirstName, @LastName, @PhoneNumber, @Email)";

            // Establish connection and execute query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Response.Write("Data stored successfully!");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        protected void btnViewList_Click(object sender, EventArgs e)
        {
            Server.Transfer("List.aspx");
        }
    }
}