﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMongoCollection<Cal> operations;
        public MainWindow()
        {
            InitializeComponent();
            DBConnection dbc = DBConnection.GetInstance();
            operations = dbc.GetAccess("CalculatorDB", "Operations");
            //InsertData();
        }

        private void InsertData()
        {
            var cal = new Cal();
            cal.num1 = 2;
            cal.num2 = 3;
            cal.result = 5;
            operations.InsertOne(cal);

            BsonDocument data = new BsonDocument {
            { "address" , new BsonDocument
                {
                    { "street", "2 Avenue" },
                    { "zipcode", "10075" },
                    { "building", "1480" },
                    { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                }
            },
            { "borough", "Manhattan" },
            { "cuisine", "Italian" },
            { "grades", new BsonArray
                {
                    new BsonDocument
                    {
                        { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                        { "grade", "A" },
                        { "score", 11 }
                    },
                    new BsonDocument
                    {
                        { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                        { "grade", "B" },
                        { "score", 17 }
                    }
                }
            },
            { "name", "Vella" },
            { "restaurant_id", "41704620" } };
            //var collection = database.GetCollection<BsonDocument>("restaurants");
            //collection.InsertOneAsync(data);
        }

        /// <summary>
        /// Add two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int output = Int32.Parse(Number1.Text) + Int32.Parse(Number2.Text);
            Result.Text = output.ToString();
            Cal data = new Cal();
            data.num1 = Int32.Parse(Number1.Text);
            data.num2 = Int32.Parse(Number2.Text);
            data.result = Int32.Parse(Result.Text);
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// Substract two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            int output = Int32.Parse(Number1.Text) - Int32.Parse(Number2.Text);
            Result.Text = output.ToString();
            Cal data = new Cal();
            data.num1 = Int32.Parse(Number1.Text);
            data.num2 = Int32.Parse(Number2.Text);
            data.result = Int32.Parse(Result.Text);
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// Multiply two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mul_Click(object sender, RoutedEventArgs e)
        {
            int output = Int32.Parse(Number1.Text) * Int32.Parse(Number2.Text);
            Result.Text = output.ToString();
            Cal data = new Cal();
            data.num1 = Int32.Parse(Number1.Text);
            data.num2 = Int32.Parse(Number2.Text);
            data.result = Int32.Parse(Result.Text);
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// Divide two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Div_Click(object sender, RoutedEventArgs e)
        {
            int output = Int32.Parse(Number1.Text) / Int32.Parse(Number2.Text);
            Result.Text = output.ToString();
            Cal data = new Cal();
            data.num1 = Int32.Parse(Number1.Text);
            data.num2 = Int32.Parse(Number2.Text);
            data.result = Int32.Parse(Result.Text);
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// View numbers from the "Operations" collection which give the output equals to the given "Result"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="d"></param>
        private void View_Click(object sender, RoutedEventArgs d)
        {
            ////Query syntax
            //var query =
            //from e in operations.AsQueryable<Cal>()
            //where e.result == Int32.Parse(Result.Text)
            //select e;

            //Lambda syntax
            var query =
            operations.AsQueryable<Cal>()
            .Where(e => e.result == Int32.Parse(Result.Text))
            .Select(e => e);

            foreach (var operation in query)
            {
                Number1.Text = operation.num1.ToString();
                Number2.Text = operation.num2.ToString();
            }
        }

    }
}
