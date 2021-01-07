using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Waiter.Models
{
    public class TableOrder : INotifyPropertyChanged
    {
        private int count = 0;

        public MenuOrder Order { get; set; }

        public int Count 
        {
            get { return count; }
            set 
            {
                count = value;

                OnPropertyChanged();
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
