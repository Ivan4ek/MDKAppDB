using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\1.png", @"C:\Users\Sterben\Desktop\dir\2.png", "фото 1");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\3.png", @"C:\Users\Sterben\Desktop\dir\4.png", "фото 2");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\5.png", @"C:\Users\Sterben\Desktop\dir\6.png", "фото 3");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\7.png", @"C:\Users\Sterben\Desktop\dir\8.png", "фото 4");
                InsertData(connection, @"C:\Users\Sterben\Desktop\dir\9.png", @"C:\Users\Sterben\Desktop\dir\10.png", "фото 5");

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

        private void button2_Click(object sender, EventArgs e)
        {
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\your_database.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] image1Bytes = (byte[])reader["Image1"];
                            byte[] image2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();

                            // загрузка изображений
                            using (MemoryStream stream1 = new MemoryStream(image1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(image2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);
                            }

                            // текст в label1
                            label1.Text = textValue;
                        }
                    }
                }

                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\your_database.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1 OFFSET 1;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] image1Bytes = (byte[])reader["Image1"];
                            byte[] image2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();

                            // Загрузка изображений в pictureBox1 и pictureBox2
                            using (MemoryStream stream1 = new MemoryStream(image1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(image2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);
                            }

                            // Установка текста в label1
                            label1.Text = textValue;
                        }
                    }
                }

                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\your_database.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1 OFFSET 2;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] image1Bytes = (byte[])reader["Image1"];
                            byte[] image2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();

                            // Загрузка изображений в pictureBox1 и pictureBox2
                            using (MemoryStream stream1 = new MemoryStream(image1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(image2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);
                            }

                            // Установка текста в label1
                            label1.Text = textValue;
                        }
                    }
                }

                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\your_database.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1 OFFSET 3;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] image1Bytes = (byte[])reader["Image1"];
                            byte[] image2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();

                            // Загрузка изображений в pictureBox1 и pictureBox2
                            using (MemoryStream stream1 = new MemoryStream(image1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(image2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);
                            }

                            // Установка текста в label1
                            label1.Text = textValue;
                        }
                    }
                }

                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dbFilePath = @"C:\\Users\\Sterben\\Desktop\\dir\\your_database.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1 OFFSET 4;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] image1Bytes = (byte[])reader["Image1"];
                            byte[] image2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();

                            // Загрузка изображений в pictureBox1 и pictureBox2
                            using (MemoryStream stream1 = new MemoryStream(image1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(image2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);
                            }

                            // Установка текста в label1
                            label1.Text = textValue;
                        }
                    }
                }

                connection.Close();
            }
        }


    }
}
