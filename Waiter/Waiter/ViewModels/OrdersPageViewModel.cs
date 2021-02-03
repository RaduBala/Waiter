using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class OrdersPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OrderListItem> OrderListItems {get; set;}

        private bool isButtonVisible = false;

        private string multifunctionButtonName = "COMMIT";

        private bool committedFlag = false;

        public bool CommittedFlag
        {
            get { return committedFlag; }

            set 
            {
                committedFlag = value;

                OnPropertyChanged();
            }
        }

        public string MultifunctionButtonName
        {
            get { return multifunctionButtonName; }

            set
            {
                multifunctionButtonName = value;

                OnPropertyChanged();
            }
        }

        public bool IsButtonVisible 
        {
            get { return isButtonVisible; }

            set 
            {
                isButtonVisible = value; 

                OnPropertyChanged(); 
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;

        public OrdersPageViewModel()
        {
            OrderListItems = new ObservableCollection<OrderListItem>();

            OrderListItems.CollectionChanged += OrderListItems_CollectionChanged;
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OrderListItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IsButtonVisible = OrderListItems.Count == 0 ? false : true;
        }
    }
}
