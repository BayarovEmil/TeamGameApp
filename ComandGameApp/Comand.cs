using ComandGameApp.Bussiness.Abstract;
using ComandGameApp.Bussiness.Concrete;
using ComandGameApp.DataAccess.Util;
using ComandGameApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ComandGameApp
{
    public partial class Comand : Form
    {
        DataTable dataTable;
        DataTable teamData1;
        DataTable teamData2;
        ITeamService teamService;
        DbHelper dbHelper;
        public Comand()
        {
            InitializeComponent();

            dbHelper = new DbHelper();
            teamService = new TeamService(dataTable);

            DataTable teams1 = dbHelper.ExecuteReader("SELECT Id, Name FROM Command");
            DataTable teams2 = dbHelper.ExecuteReader("SELECT Id, Name FROM Command");

            comboBox1.DataSource = teams1;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = teams2;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            MessageBox.Show("Completed");
            GrdLoad();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void GrdLoad()
        {
            dataGridView1.DataSource = dbHelper.ExecuteReader(@"SELECT t1.Name AS Team1Name, g.TeamScore1, t2.Name AS Team2Name, g.TeamScore2
                         FROM TeamScore g
                         INNER JOIN Command t1 ON t1.Id = g.TeamId1
                         INNER JOIN Command t2 ON t2.Id = g.TeamId2");
        }

        private void Comand_Load(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string scoreTeam1 = textBox1.Text;
            string scoreTeam2 = textBox2.Text;
            string team1 = comboBox1.SelectedValue.ToString(); 
            string team2 = comboBox2.SelectedValue.ToString(); 

            string query = @"INSERT INTO TeamScore (TeamId1, TeamScore1, TeamId2, TeamScore2) " +
                       "VALUES (@TeamId1, @TeamScore1, @TeamId2, @TeamScore2)";

            var parameters = new Dictionary<string, object>
            {
                { "@TeamId1", team1 },
                { "@TeamScore1", scoreTeam1 },
                { "@TeamId2", team2 },
                { "@TeamScore2", scoreTeam2 }
            };

            dbHelper.ExecuteNonQuery(query, parameters);
            GrdLoad();
            MessageBox.Show("Yeni komanda əlavə edildi.");
        }

    }
}
