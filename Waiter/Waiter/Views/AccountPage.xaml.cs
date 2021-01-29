﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private INfcService nfcService;

        public AccountPage()
        {
            InitializeComponent();

            nfcService = DependencyService.Get<INfcService>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            nfcService.WriteTag(Entry_NfcData.Text);
        }
    }
}