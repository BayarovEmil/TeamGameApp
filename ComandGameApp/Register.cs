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

namespace ComandGameApp
{
    public partial class Register : Form
    {
        DataTable dataTable;
        string path = "C:\\Users\\LENOVO\\source\\repos\\ComandGameApp\\register.json";
        public Register()
        {
            dataTable = new DataTable();
            dataTable.Rows.Add("Username");
            dataTable.Rows.Add("Password");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Add(textBox1.Text, textBox2.Text);
            string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

            File.WriteAllText(path, json);


            string readjson = File.ReadAllText(path);
            DataTable readdata = JsonConvert.DeserializeObject<DataTable>(readjson);

            

        }
    }
}
