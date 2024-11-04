using ComandGameApp.DataAccess.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComandGameApp
{
    public partial class Form1 : Form
    {
        string path = "C:\\Users\\LENOVO\\Desktop\\users.json.txt";
        DataTable dataTable;
        DbHelper dbHelper;
        public Form1()
        {
            dbHelper = new DbHelper();
            dataTable = new DataTable();
            dataTable.Columns.Add("username");
            dataTable.Columns.Add("password");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            string query = "SELECT COUNT(1) FROM [dbo].[User] WHERE UserName = @username AND Password = @password";

            var parameters = new Dictionary<string, object>
            {
                { "@username", username },
                { "@password", password }
            };

            int userExists = dbHelper.ExecuteScalar(query, parameters);

            if (userExists > 0)
            {
                MessageBox.Show("User successfully logged in");
                Comand comand = new Comand();
                comand.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string readJson = File.ReadAllText(path);
        //    DataTable readData = JsonConvert.DeserializeObject<DataTable>(readJson);

        //    string username = textBox1.Text;
        //    string password = textBox2.Text;

        //    foreach (DataRow row in readData.Rows)
        //    {
        //        if (row["username"].ToString() == username && row["password"].ToString() == password)
        //        {
        //            MessageBox.Show("User successfully loggedIn");
        //            Comand comand = new Comand();
        //            comand.Show();
        //            this.Hide();
        //        }
        //    }
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
