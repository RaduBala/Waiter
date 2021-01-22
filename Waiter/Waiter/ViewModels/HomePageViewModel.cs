using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<MenuOrder> menu;

        private bool isConnected = false;

        public List<MenuOrder> Menu
        {
            get
            {
                return menu;
            }

            set
            {
                menu = value;

                OnPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get 
            { 
                return isConnected; 
            }

            set
            {
                isConnected = value;

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
