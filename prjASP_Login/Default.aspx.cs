using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjASP_Login
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Message_click(object sender, EventArgs e)
        {
            string username = edtEmail.Text.ToString();
            String password = edtPassword.Text;
            //Get the encrypt the password by using the class  
            string pass = encryption(password);
            Label1.Text = pass;
            //Check whether the UseName and password are Empty  
            if (username.Length > 0 && password.Length > 0)
            {
                //creating the connection string              
                string connection = "Data Source=PAUWLAPTOP;Initial Catalog=ICETask;Integrated Security=True;Pooling=False";
                SqlConnection con = new SqlConnection(connection);
                String passwords = encryption(password);
                con.Open();
                // Check whether the Username Found in the Existing DB  
                String search = "SELECT * FROM Users WHERE (UserName = '" + username + "');";
                SqlCommand cmds = new SqlCommand(search, con);
                SqlDataReader sqldrs = cmds.ExecuteReader();
                if (sqldrs.Read())
                {
                    String passed = (string)sqldrs["Password"];
                    Label1.Text = "Username Already Taken";
                }
                else
                {
                    try
                    {
                        // if the Username not found create the new user accound  
                        string sql = "INSERT INTO Users (UserName, Password) VALUES ('" + username + "','" + passwords + "');";
                        con.Close();
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        String Message = "saved Successfully";
                        Label1.Text = Message.ToString();
                        edtEmail.Text = "";
                        edtPassword.Text = "";
                        Response.Redirect("About.aspx");
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = ex.ToString();
                    }
                    con.Close();
                }
            }

            else
            {
                String Message = "Username or Password is empty";
                Label1.Text = Message.ToString();
            }
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public void login_click(object sender, EventArgs e)
        {
            String username = edtEmail.Text.ToString();
            String password = edtPassword.Text;
            string con = "Data Source=PAUWLAPTOP;Initial Catalog=ICETask;Integrated Security=True;Pooling=False";
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            //encrypt the given password
            string passwords = encryption(password);
            String query = "SELECT UserName, Password FROM Users WHERE (UserName = '" + username + "') AND (Password = '" + passwords + "');";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader sqldr = cmd.ExecuteReader();
            if (sqldr.Read())
            {
                Response.Redirect("Contact.aspx");
            }
            else
            {
                Label1.Text = "User or password is in correct not found";

            }

            connection.Close();
        }
    }
}