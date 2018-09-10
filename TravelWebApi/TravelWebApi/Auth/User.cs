using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static TravelWebApi.Auth.AuthProvider;

namespace TravelWebApi.Auth
{
    public class User
    {
        public Guid Id { get; set; }
        public UserType? UserType { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}