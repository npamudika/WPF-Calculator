using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Calculator
{
    /// <summary>
    /// Model class for the "Operations" collection in CalculatorDB
    /// </summary>
    public class Cal
    {
        [BsonId]
        public MongoDB.Bson.BsonObjectId Id { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int result { get; set; }
    }
}
