using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using Stripe;
using Xamarin.Forms;

namespace Waiter.Services
{
    [DesignTimeVisible(false)]
    class PaymentManager
    {
        public void NewEventHandler(Object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_51H04XcAt05jl1QmCRBfTzfl2CtvzSjvh2JNPlkrVMnmqZSPbDRqBhIRfYygOX0Z63Tx4woq7zLxLwxNXyjC02Hyu003MVdJbH8";

            //This are the sample test data use MVVM bindings to send data to the ViewModel

            var stripcard = new Stripe.TokenCardOptions();

            stripcard.Number = "4000000000003055";
            stripcard.ExpYear = 2020;
            stripcard.ExpMonth = 08;
            stripcard.Cvc = "199";


            //Step 1 : Assign Card to Token Object and create Token

            Stripe.TokenCreateOptions token = new Stripe.TokenCreateOptions();
            token.Card = stripcard;
            Stripe.TokenService serviceToken = new Stripe.TokenService();
            Stripe.Token newToken = serviceToken.Create(token);

            // Step 2 : Assign Token to the Source

            var options = new SourceCreateOptions
            {
                Type = SourceType.Card,
                Currency = "usd",
                Token = newToken.Id
            };

            var service = new SourceService();
            Source source = service.Create(options);

            //Step 3 : Now generate the customer who is doing the payment

            Stripe.CustomerCreateOptions myCustomer = new Stripe.CustomerCreateOptions()
            {
                Name = "Samir",
                Email = "SamirGc@gmail.com",
                Description = "Customer for jenny.rosen@example.com",
            };

            var customerService = new Stripe.CustomerService();
            Stripe.Customer stripeCustomer = customerService.Create(myCustomer);

            //Step 4 : Now Create Charge Options for the customer. 

            var chargeoptions = new Stripe.ChargeCreateOptions
            {
                Amount = 124,
                Currency = "USD",
                ReceiptEmail = "samirgc112@gmail.com",
                Customer = stripeCustomer.Id,
                Source = source.Id

            };

            //Step 5 : Perform the payment by  Charging the customer with the payment. 
            var service1 = new Stripe.ChargeService();
            Stripe.Charge charge = service1.Create(chargeoptions); // This will do the Payment
        }
    }
}
