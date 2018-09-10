using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TravelWebApi.Models;

namespace TravelWebApi.DataAccessLayer
{
    public class CarDAL
    {
        public static bool Add(Car Car)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "INSERT INTO Car(Id,Name,Price,FromLocation,ToLocation,DepartureDate,ArrivalDate,IsBooked,IsSaved) VALUES(@Id,@Name,@Price,@FromLocation,@ToLocation,@DepartureDate,@ArrivalDate,@IsBooked,@IsSaved)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@Name", Car.Name);
                    cmd.Parameters.AddWithValue("@Price", Car.Price);
                    cmd.Parameters.AddWithValue("@FromLocation", Car.From);
                    cmd.Parameters.AddWithValue("@ToLocation", Car.To);
                    cmd.Parameters.AddWithValue("@DepartureDate", Car.DepartureDate);
                    cmd.Parameters.AddWithValue("@ArrivalDate", Car.ArrivalDate);
                    cmd.Parameters.AddWithValue("@IsBooked", false);
                    cmd.Parameters.AddWithValue("@IsSaved", false);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Booking(Guid carId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "UPDATE Car SET IsBooked=@Saved WHERE Id = @CarId";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Saved", true);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Saving(Guid carId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "UPDATE Car SET IsSaved=@Saved WHERE Id = @CarId";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Saved", true);
                    cmd.Parameters.AddWithValue("@CarId", carId);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<Car> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {
                    List<Car> Cars = new List<Car>();
                    connection.Open();
                    string sql = "SELECT Id,Name,Price,FromLocation,ToLocation,DepartureDate,ArrivalDate FROM Car";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Car Car = new Car()
                            {
                                Id = new Guid(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToInt32(reader["Price"]),
                                From = reader["FromLocation"].ToString(),
                                To = reader["ToLocation"].ToString(),
                                DepartureDate = reader["DepartureDate"].ToString(),
                                ArrivalDate = reader["ArrivalDate"].ToString(),
                            };
                            Cars.Add(Car);
                        };
                    }
                    return Cars;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}