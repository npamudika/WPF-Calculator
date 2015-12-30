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
using System.ComponentModel;
using Calculator.ViewModels;
using Calculator.Model;
using System.Collections.ObjectModel;

namespace Calculator.ViewModel
{
    class CalculatorViewModel : ObservableObject
    {
        #region Members
        IMongoCollection<Cal> operations;
        CalculatorModel model;
        ICommand addButton;
        ICommand subButton;
        ICommand mulButton;
        ICommand divButton;
        ICommand viewButton;
        ICommand loadButton;
        string viewBtnContent;
        string numberOne;
        string numberTwo;
        string result;
        public ObservableCollection<Data> calCollection;
        #endregion

        public CalculatorViewModel()
        {
            model = new CalculatorModel();
            addButton = new RelayCommand(Add);
            subButton = new RelayCommand(Sub);
            mulButton = new RelayCommand(Mul);
            divButton = new RelayCommand(Div);
            viewButton = new RelayCommand(View);
            loadButton = new RelayCommand(LoadValues);
            DBConnection dbc = DBConnection.GetInstance();
            operations = dbc.GetAccess("CalculatorDB", "Operations");
            calCollection = new ObservableCollection<Data>();
        }

        #region Properties
        /// <summary>
        /// Display View button content
        /// </summary>
        public string ViewBtnContent
        {
            get { return "VIEW"; }
        }

        public string NumberOne
        {
            get { return numberOne; }
            set
            {
                if (!String.Equals(this.numberOne, value))
                {
                    this.numberOne = value;
                    NotifyPropertyChanged("NumberOne");
                }
            }
        }

        public string NumberTwo
        {
            get { return numberTwo; }
            set
            {
                if (!String.Equals(this.numberTwo, value))
                {
                    this.numberTwo = value;
                    NotifyPropertyChanged("NumberTwo");
                }
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                this.result = value;
                NotifyPropertyChanged("Result");
            }
        }

        public ObservableCollection<Data> CalCollection
        {
            get { return calCollection; }
            set
            {
                calCollection = value;
                NotifyPropertyChanged("calCollection");
            }
        }

        public ICommand AddButton
        {
            get { return addButton; }
            set { addButton = value; }
        }

        public ICommand SubButton
        {
            get { return subButton; }
            set { subButton = value; }
        }

        public ICommand MulButton
        {
            get { return mulButton; }
            set { mulButton = value; }
        }

        public ICommand DivButton
        {
            get { return divButton; }
            set { divButton = value; }
        }

        public ICommand ViewButton
        {
            get { return viewButton; }
            set { viewButton = value; }
        }

        public ICommand LoadButton
        {
            get { return loadButton; }
            set { loadButton = value; }
        }
        #endregion

        /// <summary>
        /// Add two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add(object obj)
        {
            int firstNumber = Int32.Parse(NumberOne);
            int secondNumber = Int32.Parse(NumberTwo);
            int result = model.Add(firstNumber, secondNumber);
            Result = result.ToString();
            Cal data = new Cal();
            data.num1 = firstNumber;
            data.num2 = secondNumber;
            data.result = result;
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// Substract two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Sub(object obj)
        {
            int firstNumber = Int32.Parse(NumberOne);
            int secondNumber = Int32.Parse(NumberTwo);
            int result = model.Sub(firstNumber, secondNumber);
            Result = result.ToString();
            Cal data = new Cal();
            data.num1 = firstNumber;
            data.num2 = secondNumber;
            data.result = result;
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// Multiply two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Mul(object obj)
        {
            int firstNumber = Int32.Parse(NumberOne);
            int secondNumber = Int32.Parse(NumberTwo);
            int result = model.Mul(firstNumber, secondNumber);
            Result = result.ToString();
            Cal data = new Cal();
            data.num1 = firstNumber;
            data.num2 = secondNumber;
            data.result = result;
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// Divide two numbers and save them in "Operations" collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Div(object obj)
        {
            int firstNumber = Int32.Parse(NumberOne);
            int secondNumber = Int32.Parse(NumberTwo);
            int result = model.Div(firstNumber, secondNumber);
            Result = result.ToString();
            Cal data = new Cal();
            data.num1 = firstNumber;
            data.num2 = secondNumber;
            data.result = result;
            operations.InsertOne(data); //Add data to the "Operations" collection
        }

        /// <summary>
        /// View numbers from the "Operations" collection which give the output equals to the given "Result"
        /// </summary>
        /// <param name="obj"></param>
        public void View(object obj)
        {
            int value = Int32.Parse(Result);
            var query =
            operations.AsQueryable<Cal>()
            .Where(e => e.result == value)
            .Select(e => e);

            foreach (var operation in query)
            {
                NumberOne = operation.num1.ToString();
                NumberTwo = operation.num2.ToString();
            }
        }

        /// <summary>
        /// Load the values in the "Operations" Collection
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void LoadValues(object obj)
        {
            var queryData =
            from e in operations.AsQueryable<Cal>()
            select e;

            foreach (var operation in queryData)
            {
                Data data = new Data();
                data.NumberOne = operation.num1;
                data.NumberTwo = operation.num2;
                data.Result = operation.result;
                calCollection.Add(data);
            }
        }
    }
}
