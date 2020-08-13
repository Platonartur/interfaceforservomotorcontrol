using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace loginformcombobox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sqlConnection = new SqlConnection(@"Data Source=desktop-tnhqm7j\sqlexpress;Initial Catalog=cmblogin;Integrated Security=True");
            var sqlCommand = new SqlCommand("select * from login where username='" + txtuser.Text + "' and password='" + txtpass.Text + "'", sqlConnection);
            var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            var dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if (dataTable.Rows.Count <= 0)
            {
                MessageBox.Show("error");
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["usertype"].ToString() != cmbItemValue)
                    continue;

                MessageBox.Show("you are logged in as" + dataTable.Rows[i][2]);
                
                if (comboBox1.SelectedIndex != 0)
                    continue;

                using (Form2 form = new Form2())
                    form.Init();

                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
