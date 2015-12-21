using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    /// <summary>
    /// Standard ViewModel class base; Simply allows property change notifications to be sent
    /// </summary>
    class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// The PropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            //Take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
