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
        public Form1()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("username");
            dataTable.Columns.Add("password");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string readJson = File.ReadAllText(path);
            DataTable readData = JsonConvert.DeserializeObject<DataTable>(readJson);

            string username = textBox1.Text;
            string password = textBox2.Text;

            foreach (DataRow row in readData.Rows)
            {
                if (row["username"].ToString() == username && row["password"].ToString() == password)
                {
                    MessageBox.Show("User successfully loggedIn");
                    Comand comand = new Comand();
                    comand.Show();
                    this.Hide();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
