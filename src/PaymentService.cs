using System;

namespace DesignPatternChallenge
{
    public class PaymentService
    {
        private readonly IPaymentGatewayFactory _factory;

        public PaymentService(IPaymentGatewayFactory factory)
        {
            _factory = factory;
        }

        public void ProcessPayment(decimal amount, string cardNumber)
        {
            var validator = _factory.CreateValidator();
            var processor = _factory.CreateProcessor();
            var logger = _factory.CreateLogger();

            if (!validator.ValidateCard(cardNumber))
            {
                Console.WriteLine("Cartão Inválido");
                return;
            }

            var result = processor.ProcessTransaction(amount, cardNumber);
            logger.Log($"Transação processada: {result}");
        }
    }
}