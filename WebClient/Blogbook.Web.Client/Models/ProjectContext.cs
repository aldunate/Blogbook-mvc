using MongoDB.Driver;
using System;

namespace BlogbookMVC.Models
{
    public class MongoDB
    {
        //For Best practice, Please put this in the web.config. This is only for demo purpose.
        //====================================================
        public String connectionString = "mongodb://localhost";
        public String DataBaseName = "BlogbookDB";
        //====================================================

        public MongoDatabase Database;

        public MongoDB()
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            Database = server.GetDatabase(DataBaseName);
        }

        public MongoCollection<User> Users
        {
            get
            {
                var Users = Database.GetCollection<User>("User");

                return Users;
            }
        }
    }
}