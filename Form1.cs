using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace elecdnevnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\redmi\source\Repos\elecdnevnik\elecdnevnik\Database2.mdf;Integrated Security=True");


        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Вы хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { this.Show(); }
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = usernameTextBox.Text;
            user_password = passwordTextBox.Text;
            try
            {
                String querry = "SELECT * FROM Admin WHERE Login = '" + usernameTextBox.Text + "' AND Pass = '" + passwordTextBox.Text + "'";
                String querry1 = "SELECT * FROM Teacher WHERE Login = '" + usernameTextBox.Text + "' AND Pass = '" + passwordTextBox.Text + "'";
                String querry2 = "SELECT * FROM Students WHERE Login = '" + usernameTextBox.Text + "' AND Pass = '" + passwordTextBox.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                SqlDataAdapter sda1 = new SqlDataAdapter(querry1, conn);
                SqlDataAdapter sda2 = new SqlDataAdapter(querry2, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);

                if (dt.Rows.Count > 0)
                {
                    username = usernameTextBox.Text;
                    user_password = passwordTextBox.Text;
                    MessageBox.Show("Вы вошли как Админ", "Админ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menuform form2 = new Menuform();
                    
                    form2.Show();
                    this.Hide();

                    
                }
                

                else if (dt1.Rows.Count > 0)
                {
                    username = usernameTextBox.Text;
                    user_password = passwordTextBox.Text;
                    MessageBox.Show("Вы вошли как Учитель", "Учитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menuform form2 = new Menuform();
                    form2.Show();

                    this.Hide();
                }
                

                else if (dt2.Rows.Count > 0)
                {
                    username = usernameTextBox.Text;
                    user_password = passwordTextBox.Text;
                    MessageBox.Show("Вы вошли как Студент", "Студент", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menuform form2 = new Menuform();
                    form2.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    usernameTextBox.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

