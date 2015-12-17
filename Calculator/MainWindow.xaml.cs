using System;
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
