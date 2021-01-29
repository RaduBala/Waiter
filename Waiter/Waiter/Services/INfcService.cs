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

        void SetState(bool state);

        void WriteTag(string content);
    }
}
