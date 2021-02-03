using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Services
{
    public interface INfcService
    {
        event ScanResultDelegate OnScanResult;

        void Init();

        bool GetState();

        void OpenSettings();

        void WriteTag(string content);
    }
}
