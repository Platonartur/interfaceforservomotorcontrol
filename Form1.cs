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
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=desktop-tnhqm7j\sqlexpress;Initial Catalog=cmblogin;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("select * from login where username='"+txtuser.Text+"' and password='"+txtpass.Text+"'", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if (dataTable.Rows.Count > 0) 
            { 
                for(int i=0; i< dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["usertype"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("you are login as" + dataTable.Rows[i][2]);
                        if(comboBox1.SelectedIndex==0)
                        {
                            Form2 f = new Form2();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form3 ff = new Form3();
                            ff.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
