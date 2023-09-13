using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDKAppDB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем или перезаписываем новый файл базы данных SQLite
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\new_database.db";
            SQLiteConnection.CreateFile(dbFilePath);

            // Создаем подключение к новой базе данных
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Создаем новую таблицу
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS UserTable (user TEXT, password TEXT);", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Вставляем данные (Ivan и 123)
                InsertUserData(connection, "Ivan", "123");

                connection.Close();
            }

            MessageBox.Show("Новая база данных создана и заполнена данными.");
        }

        private void InsertUserData(SQLiteConnection connection, string username, string password)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO UserTable (user, password) VALUES (@user, @password);", connection))
            {
                command.Parameters.AddWithValue("@user", username);
                command.Parameters.AddWithValue("@password", password);

                command.ExecuteNonQuery();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Подключение к базе данных SQLite
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\new_database.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Поиск пользователя в таблице
                string query = "SELECT * FROM UserTable WHERE user = @user AND password = @password";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Закрыть Form2 только если она открыта
                            Form2 form2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
                            if (form2 != null)
                            {
                                form2.Hide();
                            }

                            // Создать и отобразить новый экземпляр Form1
                            Form1 newForm1 = new Form1();
                            newForm1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Неправильное имя пользователя или пароль.");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
