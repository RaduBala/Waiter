using Android.App;
using Android.Content;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Waiter.Constans;
using Android.Nfc.Tech;

namespace Waiter.Droid
{
    public class NfcManager
    {
        private enum NfcManagerState
        {
            IDLE,
            WRITE_REQUEST
        };

        private NfcAdapter nfcAdapter;

        private PendingIntent pendingIntent;

        private NfcManagerState nfcManagerState = NfcManagerState.IDLE;

        private string DataToWrite = null;

        public void Init(Activity activity)
        {
            nfcAdapter = NfcAdapter.GetDefaultAdapter(activity);

            if (null != nfcAdapter)
            {
                var intent = new Intent(activity, activity.GetType()).AddFlags(ActivityFlags.SingleTop);

                pendingIntent = PendingIntent.GetActivity(activity, 0, intent, 0);
            }

            MessagingCenter.Subscribe<NfcService, string>(this, Constants.NfcWriteTagEventName, Write);
        }

        public void Listening(Activity activity)
        {
            if (null != nfcAdapter)
            {
                nfcAdapter.EnableForegroundDispatch(activity, pendingIntent, null, null);
            }
        }

        private void Write(NfcService nfcService, string data)
        {
            DataToWrite = data;

            nfcManagerState = NfcManagerState.WRITE_REQUEST;
        }

        public void OnReadTag(Intent intent)
        {
            string TagData = GetTagStringFromIntent(intent);

            if (null != TagData)
            {
                MessagingCenter.Send(this, Constants.NfcReadTagEventName, TagData);
            }
        }

        public void OnWriteTagFinish(string data)
        {
            if (null != data)
            {
                MessagingCenter.Send(this, Constants.NfcWriteTagFinishEventName, data);
            }
        }

        private string GetTagStringFromIntent(Intent intent)
        {
            string retVal = null;

            var rawMessages = intent.GetParcelableArrayExtra(NfcAdapter.ExtraNdefMessages);

            if (rawMessages != null)
            {
                var msg = (NdefMessage)rawMessages[0];

                var record = msg.GetRecords()[0];

                if (record != null)
                {
                    if (record.Tnf == NdefRecord.TnfWellKnown)
                    {
                        retVal = Encoding.ASCII.GetString(record.GetPayload());
                    }
                }
            }

            return retVal;
        }

        private void OnWriteTag(Intent intent, string content)
        {
            if(null != content)
            {
                var tag = intent.GetParcelableExtra(NfcAdapter.ExtraTag) as Tag;

                if (tag != null)
                {
                    Ndef ndef = Ndef.Get(tag);

                    if (ndef != null && ndef.IsWritable)
                    {
                        var payload     = Encoding.ASCII.GetBytes(content);
                        var mimeBytes   = Encoding.ASCII.GetBytes("text/plain");
                        var record      = new NdefRecord(NdefRecord.TnfWellKnown, mimeBytes, new byte[0], payload);
                        var ndefMessage = new NdefMessage(new[] { record });

                        ndef.Connect();
                        ndef.WriteNdefMessage(ndefMessage);
                        ndef.Close();
                    }
                    else
                    {
                        NdefFormatable ndefFormatable = NdefFormatable.Get(tag);

                        if (ndefFormatable != null)
                        {
                            try
                            {
                                var payload     = Encoding.ASCII.GetBytes(content);
                                var mimeBytes   = Encoding.ASCII.GetBytes("text/plain");
                                var record      = new NdefRecord(NdefRecord.TnfWellKnown, mimeBytes, new byte[0], payload);
                                var ndefMessage = new NdefMessage(new[] { record });

                                ndefFormatable.Connect();
                                ndefFormatable.Format(ndefMessage);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            finally
                            {
                                try
                                {
                                    ndefFormatable.Close();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ScheduleTagDiscovered(Intent intent)
        {
            switch(nfcManagerState)
            {
                case NfcManagerState.IDLE:
                {
                    OnReadTag(intent);
                }
                break;

                case NfcManagerState.WRITE_REQUEST:
                {
                    nfcManagerState = NfcManagerState.IDLE;

                    OnWriteTag(intent, DataToWrite); 
                }
                break;
            }
        }

        public void OnTagDiscovered(Intent intent)
        {
            if ((intent.Action == NfcAdapter.ActionTagDiscovered ) ||
                (intent.Action == NfcAdapter.ActionTechDiscovered) ||
                (intent.Action == NfcAdapter.ActionNdefDiscovered)   )
            {
                var tag = intent.GetParcelableExtra(NfcAdapter.ExtraTag) as Tag;

                if (tag != null)
                {
                    ScheduleTagDiscovered(intent);
                }
            }
        }
    }
}