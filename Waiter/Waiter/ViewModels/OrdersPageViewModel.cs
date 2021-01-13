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

        public event PropertyChangedEventHandler PropertyChanged;

        public OrdersPageViewModel()
        {
            OrderListItems = new ObservableCollection<OrderListItem>();

            OrderListItems.CollectionChanged += OrderListItems_CollectionChanged;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void OrderListItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("OrderListItems");
        }
    }
}
