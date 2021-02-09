using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Waiter.Services
{
    public static class NfcCom
    {
        private static INfcInterface nfcService;

        private static bool initFlag = false;

        public static void Init()
        {
            if(true == initFlag)
            {

            }
            else
            {
                initFlag = true;

                nfcService = DependencyService.Get<INfcInterface>();

                nfcService.Init();
            }
        }

        public static bool GetState()
        {
            return nfcService.GetState();
        }

        public static void OpenSettings()
        {
            nfcService.OpenSettings();
        }

        public static void Subscribe(ScanResultDelegate OnScanResult)
        {
            nfcService.OnScanResult += OnScanResult;
        }

        public static void Unsubscribe(ScanResultDelegate OnScanResult)
        {
            nfcService.OnScanResult -= OnScanResult;
        }
    }
}
