using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TravelWebApi.Models;

namespace TravelWebApi.DataAccessLayer
{
public class ActivityDAL
    {
        public static bool Add(Activity Activity)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "INSERT INTO Activity(Id,Name,Price,Location,Date,Duration,IsBooked,IsSaved) VALUES(@Id,@Name,@Price,@Location,@Date,@Duration,@IsBooked,@IsSaved)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@Name", Activity.Name);
                    cmd.Parameters.AddWithValue("@Price", Activity.Price);
                    cmd.Parameters.AddWithValue("@Location", Activity.Location);
                    cmd.Parameters.AddWithValue("@Date", Activity.Date);
                    cmd.Parameters.AddWithValue("@Duration", Activity.Duration);
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
        public static bool Booking(Guid ActivityId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "UPDATE Activity SET IsBooked=@Booked WHERE Id = @ActivityId";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Booked", true);
                    cmd.Parameters.AddWithValue("@ActivityId", ActivityId);
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

        public static bool Saving(Guid ActivityId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "UPDATE Activity SET IsSaved=@Saved WHERE Id = @ActivityId";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@Saved", true);
                    cmd.Parameters.AddWithValue("@ActivityId", ActivityId);
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

        public static List<Activity> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=Travel;User ID=sa;Password=test123!@#"))
                {
                    List<Activity> Activities = new List<Activity>();
                    connection.Open();
                    string sql = "SELECT Id,Name,Price,Location,Date,Duration FROM Activity";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Activity Activity = new Activity()
                            {
                                Id = new Guid(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToInt32(reader["Price"]),
                                Location = reader["Location"].ToString(),
                                Date = reader["Date"].ToString(),
                                Duration = reader["Duration"].ToString(),
                            };
                            Activities.Add(Activity);
                        };
                    }
                    return Activities;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}