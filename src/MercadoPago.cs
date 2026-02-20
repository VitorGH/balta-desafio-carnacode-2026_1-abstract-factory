using System;

namespace DesignPatternChallenge
{
    // Componentes do MercadoPago
    public class MercadoPagoValidator : IPaymentValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("MercadoPago: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("5");
        }
    }

    public class MercadoPagoProcessor : IPaymentProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"MercadoPago: Processando R$ {amount}...");
            return $"MP-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    public class MercadoPagoLogger : IPaymentLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[MercadoPago Log] {DateTime.Now}: {message}");
        }
    }

    public class MercadoPagoFactory : IPaymentGatewayFactory
    {
        public IPaymentValidator CreateValidator() => new MercadoPagoValidator();
        public IPaymentProcessor CreateProcessor() => new MercadoPagoProcessor();
        public IPaymentLogger CreateLogger() => new MercadoPagoLogger();
    }
}
