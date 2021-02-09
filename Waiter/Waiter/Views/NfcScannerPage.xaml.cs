using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Constans;
using Waiter.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NfcScannerPage : ContentPage
    {
        public event ScanResultDelegate OnScanResult;

        public delegate void ScanResultDelegate(string result);

        public NfcScannerPage()
        {
            InitializeComponent();

            NfcCom.Init();

            NfcCom.Subscribe(OnTagReadDataResult);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            NfcCom.Unsubscribe(OnTagReadDataResult);
        }

        private void OnTagReadDataResult(string data)
        {
            OnScanResult.Invoke(data);
        }
    }
}