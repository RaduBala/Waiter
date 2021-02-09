using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waiter.Services;
using Xamarin.Forms;
using Waiter.Constans;
using Waiter.Droid;
using static Waiter.Services.INfcInterface;
using Android.Nfc;

[assembly: Dependency(typeof(NfcService))]
namespace Waiter.Droid
{
    public class NfcService : INfcInterface
    {
        public event ScanResultDelegate OnScanResult;

        public void Init()
        {
            MessagingCenter.Subscribe<NfcManager, string>(this, Constants.NfcReadTagEventName, OnTagRead);
        }

        public bool GetState()
        {
            NfcAdapter nfcAdapter = NfcAdapter.GetDefaultAdapter(Android.App.Application.Context);

            return nfcAdapter.IsEnabled;
        }

        public void OpenSettings()
        {
            Intent intent = new Intent("android.settings.NFC_SETTINGS");

            intent.AddFlags(ActivityFlags.NewTask);

            Android.App.Application.Context.StartActivity(intent);
        }

        public void OnTagRead(NfcManager nfcManager,string content)
        {
            OnScanResult.Invoke(content);
        } 

        public void WriteTag(string content)
        {
            MessagingCenter.Send(this, Constants.NfcWriteTagEventName, content);
        }
    }
}