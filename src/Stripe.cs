using System;

namespace DesignPatternChallenge
{
    // Componentes do Stripe
    public class StripeValidator : IPaymentValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("Stripe: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("4");
        }
    }

    public class StripeProcessor : IPaymentProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"Stripe: Processando ${amount}...");
            return $"STRIPE-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    public class StripeLogger : IPaymentLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Stripe Log] {DateTime.Now}: {message}");
        }
    }

    public class StripeFactory : IPaymentGatewayFactory
    {
        public IPaymentValidator CreateValidator() => new StripeValidator();
        public IPaymentProcessor CreateProcessor() => new StripeProcessor();
        public IPaymentLogger CreateLogger() => new StripeLogger();
    }
}