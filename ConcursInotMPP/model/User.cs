﻿namespace ConcursInotMPP.model
{

    public class User : IHasId<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        
    }
}
