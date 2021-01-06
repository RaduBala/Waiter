using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class OrdersPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int count;

        private MenuOrder order;

        public MenuOrder Order 
        {
            get
            {
                return order;
            }
            
            set
            {
                order = value;

                OnPropertyChanged();
            }
        }

        public int Count
        { 
            get
            {
                return count;
            }

            set
            {
                count = value;

                OnPropertyChanged();
            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
