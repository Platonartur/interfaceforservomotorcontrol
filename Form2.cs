using System;
using System.Windows.Forms;
using System.IO.Ports; 
using System.Data;
using System.Data.SqlClient;

namespace loginformcombobox
{
    public partial class Form2 : Form
    {
        SerialPort port;
        public Form2()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            try
            {
                port.Open();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine(Val_trackBar.Value.ToString());
                Degree_label.Text = "Degree =" + Val_trackBar.Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=desktop-tnhqm7j\sqlexpress;Initial Catalog=cmblogin;Integrated Security=True";
            string portname = textBox1.Text.ToString();
            int baudrate = Int32.Parse(textBox2.Text);
            string sqlExpression = String.Format("INSERT INTO SettingsServoMotorTable (portname, baudrate) VALUES ('{0}', {1})", portname, baudrate);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                sqlExpression = String.Format("UPDATE SettingsServoMotorTable SET portname='{0}' WHERE baudrate={1}", portname, baudrate);
            }
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
