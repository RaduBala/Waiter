using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Waiter.Models
{
    public class OrderListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool commitStatus = false;

        private bool orderStatus = false; 

        public TableOrder Order { get; set; }

        public bool CommitStatus
        {
            get 
            {
                return commitStatus;
            }

            set 
            {
                commitStatus = value;

                OnPropertyChanged();
            }
        }

        public bool OrderStatus
        {
            get
            {
                return orderStatus;
            }

            set
            {
                orderStatus = value;

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
