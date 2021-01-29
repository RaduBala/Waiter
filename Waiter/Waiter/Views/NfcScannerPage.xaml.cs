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

        private INfcService nfcService;

        public NfcScannerPage()
        {
            InitializeComponent();

            nfcService = DependencyService.Get<INfcService>();

            nfcService.OnScanResult += OnTagReadDataResult;

            nfcService.Init();
        }

        private void OnTagReadDataResult(string data)
        {
            OnScanResult.Invoke(data);
        }
    }
}