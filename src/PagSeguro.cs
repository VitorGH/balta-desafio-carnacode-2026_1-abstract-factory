using System;

namespace DesignPatternChallenge
{
    // Componentes do PagSeguro
    public class PagSeguroValidator : IPaymentValidator
    {
        public bool ValidateCard(string cardNumber)
        {
            Console.WriteLine("PagSeguro: Validando cartão...");
            return cardNumber.Length == 16;
        }
    }

    public class PagSeguroProcessor : IPaymentProcessor
    {
        public string ProcessTransaction(decimal amount, string cardNumber)
        {
            Console.WriteLine($"PagSeguro: Processando R$ {amount}...");
            return $"PAGSEG-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    public class PagSeguroLogger : IPaymentLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[PagSeguro Log] {DateTime.Now}: {message}");
        }
    }

    public class PagSeguroFactory : IPaymentGatewayFactory
    {
        public IPaymentValidator CreateValidator() => new PagSeguroValidator();
        public IPaymentProcessor CreateProcessor() => new PagSeguroProcessor();
        public IPaymentLogger CreateLogger() => new PagSeguroLogger();
    }
}