using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TravelWebApi.Auth
{
    public class AuthProvider
    {
        private string _username;
        private string _password;
        public enum UserType
        {
            admin,
            client
        }
        public AuthProvider(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public UserType? Authenticate()
        {
            if (_username != string.Empty || _password != null)
            {
                var password = ConfigurationManager.AppSettings[_username.ToLower()];
                if (string.Equals(_password, password))
                {
                    return string.Equals(_username, UserType.admin.ToString(),
                        StringComparison.InvariantCultureIgnoreCase) ? UserType.admin : UserType.client;
                }
            }
            return null;
        }


    }
}