using System;
using System.Windows.Forms;
using System.IO.Ports; 
using System.Data;
using System.Data.SqlClient;

namespace loginformcombobox
{
    public partial class Form2 : Form
    {
        private SerialPort _serial;
        public Form2()
        {
            InitializeComponent();
        }

        public void Init()
        {
            _serial = new SerialPort();
            _serial.PortName = "COM6";
            _serial.BaudRate = 9600;
            try
            {
                _serial.Open();
                this.Show();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
                this.Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_serial.IsOpen)
            {
                _serial.WriteLine(Val_trackBar.Value.ToString());
                Degree_label.Text = "Degree =" + Val_trackBar.Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=desktop-tnhqm7j\sqlexpress;Initial Catalog=cmblogin;Integrated Security=True";
            string portname = textBox1.Text.ToString();
            int baudrate = int.Parse(textBox2.Text);
            string sqlExpression = string.Format("INSERT INTO SettingsServoMotorTable (portname, baudrate) VALUES ('{0}', {1})", portname, baudrate);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                sqlExpression = string.Format("UPDATE SettingsServoMotorTable SET portname='{0}' WHERE baudrate={1}", portname, baudrate);
            }
        }

        private void button2_Click(object sender, EventArgs e) => this.Close();
    }
}
