using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TravelWebApi.Interfaces;
using TravelWebApi.Models;

namespace TravelWebApi.DataAccessLayer
{
    public static class HotelDAL //: ITravelEntity
    {
        public static bool Add(Hotel hotel)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "INSERT INTO Hotel(Id,Name,Price,Address,StarRating,IsBooked,IsSaved) VALUES(@Id,@Name,@Price,@Address,@StarRating,@IsBooked,@IsSaved)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@Name", hotel.Name);
                    cmd.Parameters.AddWithValue("@Price", hotel.Price);
                    cmd.Parameters.AddWithValue("@Address", hotel.Address);
                    cmd.Parameters.AddWithValue("@StarRating", hotel.StarRating);
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

        //public bool Book(Guid hotelId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(Guid hotelId)
        //{
        //    throw new NotImplementedException();
        //}

        public static bool Booking(Guid hotelId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "UPDATE Hotel SET IsBooked=@Booked WHERE Id = @HotelId";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Booked", true);
                    cmd.Parameters.AddWithValue("@HotelId", hotelId);
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

        public static bool Saving(Guid hotelId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "UPDATE Hotel SET IsSaved=@Saved WHERE Id = @HotelId";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Saved", true);
                    cmd.Parameters.AddWithValue("@HotelId", hotelId);
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

        public static List<Hotel> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {
                    List<Hotel> hotels = new List<Hotel>();
                    connection.Open();
                    string sql = "SELECT Id,Name,Price,Address,StarRating FROM Hotel";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hotel hotel = new Hotel()
                            {
                                Id = new Guid(reader["Id"].ToString()),
                                Address = reader["Address"].ToString(),
                                Name = reader["Name"].ToString(),
                                StarRating = Convert.ToInt32(reader["StarRating"]),
                                Price = Convert.ToInt32(reader["Price"])
                            };
                            hotels.Add(hotel);
                        };
                    }
                    return hotels;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public bool Save(Hotel hotel)
        //{
        //    throw new NotImplementedException();
        //}

        //public Product Update(Hotel hotel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}