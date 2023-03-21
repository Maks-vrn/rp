using System.Data.SqlClient;
using System.Data;

namespace rp
{
    public partial class Form1 : Form
    {
        private object dataBase;

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            string querystrng = $"insert into Users (login_user, password_user) values('{login}' , '{password}')";

            SqlCommand command = new SqlCommand(querystrng, dataBase.Connection());
            dataBase.openConnection();
            if (checkUser1())
            {
                return;
            }
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан");

                this.Hide();
;
                Close();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
            dataBase.closeConnection();
        }
        private Boolean checkUser1()
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from Users where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
