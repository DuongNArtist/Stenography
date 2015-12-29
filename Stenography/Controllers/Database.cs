using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Stenography
{
    class Database
    {
        private const string CONNECTION_STRING = @"Data Source=ASUS-K55VD\SQLEXPRESS; Initial Catalog = Stenography; Integrated Security = True";
        private static Database instance;
        private SqlConnection connection;

        private Database()
        {
            connection = new SqlConnection(CONNECTION_STRING);
        }

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        public int InsertImageToDatabase(string name, Image image)
        {
            int result = 0;
            SqlCommand command = new SqlCommand("INSERT INTO Images(Name, Image) VALUES(@name, @image)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@image", Processor.ImageToDatabase(image));
            OpenConnection();
            try
            {
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public Dictionary<int, string> GetImageNames()
        {
            string query = @"SELECT * FROM Images";
            Dictionary<int, string> names = new Dictionary<int, string>();
            SqlCommand command = new SqlCommand(query, connection);
            OpenConnection();
            try
            {
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int key = int.Parse(sqlDataReader["ID"].ToString());
                    string value = sqlDataReader["Name"].ToString();
                    names.Add(key, value);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return names;
        }

        public Image GetImageById(int id)
        {
            Image image = null;
            SqlDataReader reader = null;
            string query = @"SELECT * FROM Images WHERE ID = " + id;
            SqlCommand command = new SqlCommand(query, connection);
            OpenConnection();
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    byte[] buffer = (byte[])reader["Image"];
                    image = Processor.DatabaseToBitmap(buffer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return image;
        }

        public int DeleteImageById(int id)
        {
            int result = 0;
            string query = @"DELETE FROM Images Where ID = " + id;
            SqlCommand command = new SqlCommand(query, connection);
            OpenConnection();
            try
            {
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public int GetCountOfId(int id)
        {
            int result = 0;
            string query = @"SELECT COUNT(ID) FROM Images Where ID = " + id;
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            OpenConnection();
            try
            {
                result = (int) sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public int UpdateImageById(int id, string name, Image image)
        {
            int result = 0;
            SqlCommand command = new SqlCommand("UPDATE Images SET Name = @name, Image = @image WHERE ID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@image", Processor.ImageToDatabase(image));
            OpenConnection();
            try
            {
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        private void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
