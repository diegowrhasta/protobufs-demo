using ProtoDemo;
using Google.Protobuf;

namespace Protobuffs.Tests;

public static class OneOfExample
{
    public static void Run()
    {
        var payment = new Payment
        {
            CreditCard = new CreditCardPayment
            {
                CardNumber = "4111111111111111"
            }
        };
        
        Console.WriteLine(payment.PaymentMethodCase);
        
        payment = new Payment
        {
            PaypalEmail = "someone@example.com"
        };
        
        Console.WriteLine(payment.PaymentMethodCase);
        
        // Common switch case for different one ofs
        
        switch (payment.PaymentMethodCase)
        {
            case Payment.PaymentMethodOneofCase.CreditCard:

                Console.WriteLine(
                    payment.CreditCard.CardNumber);

                break;

            case Payment.PaymentMethodOneofCase.BankTransfer:

                Console.WriteLine(
                    payment.BankTransfer.AccountNumber);

                break;

            case Payment.PaymentMethodOneofCase.PaypalEmail:

                Console.WriteLine(
                    payment.PaypalEmail);

                break;

            case Payment.PaymentMethodOneofCase.None:

                Console.WriteLine(
                    "No payment method supplied");

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        // Setting two values (even though only one of should be in place)
        payment = new Payment
        {
            PaypalEmail = "paypal@example.com"
        };

        payment.CreditCard =
            new CreditCardPayment
            {
                CardNumber = "4111111111111111"
            };
        
        // PaypalEmail is cleared
        // CreditCard becomes active
        Console.WriteLine(payment.PaymentMethodCase);
    }
}