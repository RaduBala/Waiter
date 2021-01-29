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
using static Waiter.Services.INfcService;

[assembly: Dependency(typeof(NfcService))]
namespace Waiter.Droid
{
    public class NfcService : INfcService
    {
        public event ScanResultDelegate OnScanResult;

        public void Init()
        {
            MessagingCenter.Subscribe<NfcManager, string>(this, Constants.NfcReadTagEventName, OnTagRead);
        }

        public bool GetState()
        {
            throw new NotImplementedException();
        }

        public void SetState(bool state)
        {
            throw new NotImplementedException();
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