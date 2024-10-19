using ComandGameApp.Bussiness.Abstract;
using ComandGameApp.Bussiness.Concrete;
using ComandGameApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ComandGameApp
{
    public partial class Comand : Form
    {
        DataTable dataTable;
        DataTable teamData1;
        DataTable teamData2;
        ITeamService teamService;
        public Comand()
        {
            teamService = new TeamService(dataTable);
            dataTable = new DataTable();
            dataTable.Columns.Add("Team-1 name");
            dataTable.Columns.Add("Team-1 Score");
            dataTable.Columns.Add("Team-2 Score");
            dataTable.Columns.Add("Team-2 name");
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Optional
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridView1.Dock = DockStyle.Fill;
        }

        private void Comand_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable;
            try
            {
                DataTable readData = teamService.GetTable();

                teamData1 = readData.Copy();
                teamData2 = readData.Copy();

                comboBox1.DataSource = teamData1;
                comboBox1.DisplayMember = "teamName";
                comboBox1.ValueMember = "teamId";

                comboBox2.DataSource = teamData2;
                comboBox2.DisplayMember = "teamName";
                comboBox2.ValueMember = "teamId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teams: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string scoreTeam1 = textBox1.Text;
            string scoreTeam2 = textBox2.Text;
            string team1 = comboBox1.Text;
            string team2 = comboBox2.Text;

            dataTable.Rows.Add(team1, scoreTeam1, scoreTeam2, team2);
            teamService.Add(
                    dataTable
                );
            MessageBox.Show("Yeni komanda əlavə edildi.");
        }
    }
}
