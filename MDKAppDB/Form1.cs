using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MDKAppDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем или перезаписываем файл базы данных SQLite
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\your_database.db";
            SQLiteConnection.CreateFile(dbFilePath);

            // Создаем подключение к базе данных
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Создаем таблицу
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS ImagesTable (Image1 BLOB, Image2 BLOB, TextColumn TEXT);", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Вставляем данные
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\1.PNG", @"C:\Users\Sterben\Desktop\dir\2.PNG", "1");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\3.PNG", @"C:\Users\Sterben\Desktop\dir\4.PNG", "2");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\5.PNG", @"C:\Users\Sterben\Desktop\dir\6.PNG", "3");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\7.PNG", @"C:\Users\Sterben\Desktop\dir\8.PNG", "4");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\9.PNG", @"C:\Users\Sterben\Desktop\dir\10.PNG", "5");

                connection.Close();
            }

            MessageBox.Show("База данных создана и заполнена данными.");
        }

        private void InsertData(SQLiteConnection connection, string imagePath1, string imagePath2, string textValue)
        {
            using (SQLiteCommand command = new SQLiteCommand("INSERT INTO ImagesTable (Image1, Image2, TextColumn) VALUES (@Image1, @Image2, @TextColumn);", connection))
            {
                command.Parameters.AddWithValue("@Image1", File.ReadAllBytes(imagePath1));
                command.Parameters.AddWithValue("@Image2", File.ReadAllBytes(imagePath2));
                command.Parameters.AddWithValue("@TextColumn", textValue);

                command.ExecuteNonQuery();
            }
        }
    }
}
