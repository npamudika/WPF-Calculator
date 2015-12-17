using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Shared;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;

namespace Calculator
{
    /// <summary>
    /// Connect to a given Collection of a given Mongo Database
    /// </summary>
    class DBConnection
    {
        IMongoClient mongo = new MongoClient("mongodb://localhost:27017");
        IMongoDatabase database;
        IMongoCollection<Cal> operations;
        private static DBConnection instance;

        private DBConnection() { } //Private parameterless Constructor

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }

        public IMongoCollection<Cal> GetAccess(String databaseName, String collectionName)
        {
            database = mongo.GetDatabase(databaseName);   //Get the Database "CalculatorDB" from MongoDB server
            operations = database.GetCollection<Cal>(collectionName); //Get the Collection "Operations" from "CalculatorDB"
            return operations;
        }
    }
}
