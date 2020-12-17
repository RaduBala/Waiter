using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;

namespace Waiter.Droid
{
    class AppDataHelper
    {
        public static FirebaseDatabase GetDatabase()
        {  
            FirebaseApp      firebaseApp      = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase firebaseDatabase ;

            if (null == firebaseApp)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("waiterdatabase")
                    .SetApiKey("AIzaSyBbqafb5sfTDTP42LEfCJjbo2wJ8jzRU1k")
                    .SetDatabaseUrl("https://waiterdatabase.firebaseio.com")
                    .SetStorageBucket("waiterdatabase.appspot.com")
                    .Build();

                firebaseApp = FirebaseApp.InitializeApp(Application.Context, options);

                firebaseDatabase = FirebaseDatabase.GetInstance(firebaseApp);
            }
            else
            {
                firebaseDatabase = FirebaseDatabase.GetInstance(firebaseApp);
            }

            return firebaseDatabase;
        }
    }
}