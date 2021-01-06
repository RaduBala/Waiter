using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using Waiter.Models;

namespace Waiter.Services
{
    class PaymentManager
    {
        public void Charge(CreditCard creditCard, int amount)
        {
            StripeConfiguration.ApiKey = "sk_test_51I16Y9E8wOwlqFibK2LgGaeO3Cl2Lm5cuHykaLkxZUvtLcdXnlespd1oisJcx3l5GJaL9NYsUjmp6dOoGwL3EvCi00j5FSSKaN";

            TokenCardOptions stripeCard = new TokenCardOptions
            {
                Number   = creditCard.Number,
                ExpYear  = creditCard.ExpirationYear,
                ExpMonth = creditCard.ExpirationMounth,
                Cvc      = creditCard.Cvc
            };

            TokenCreateOptions token = new TokenCreateOptions
            {
                Card = stripeCard
            };

            TokenService serviceToken = new TokenService();
            Token        newToken     = serviceToken.Create(token);

            var options = new SourceCreateOptions
            {
                Type     = SourceType.Card,
                Currency = "RON",
                Token    = newToken.Id
            };

            var    service = new SourceService();
            Source source  = service.Create(options);

            Stripe.CustomerCreateOptions myCustomer = new Stripe.CustomerCreateOptions()
            {
                Name = "Radu Balauroiu",
                Email = "balauroiu.radu@yahoo.com",
                Description = "Test",
            };

            CustomerService customerService = new CustomerService();
            Customer        stripeCustomer  = customerService.Create(myCustomer);

            ChargeCreateOptions chargeoptions = new ChargeCreateOptions
            {
                Amount       = amount,
                Currency     = "RON",
                ReceiptEmail = "balauroiu.radu@yahoo.com",
                Customer     = stripeCustomer.Id,
                Source       = source.Id,
                Description  = "Test"
            };

            ChargeService service1 = new ChargeService();
            Charge        charge   = service1.Create(chargeoptions);
        }
    }
}
