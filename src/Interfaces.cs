using System;

namespace DesignPatternChallenge
{
    public interface IPaymentValidator
    {
        bool ValidateCard(string cardNumber);
    }

    public interface IPaymentProcessor
    {
        string ProcessTransaction(decimal amount, string cardNumber);
    }

    public interface IPaymentLogger
    {
        void Log(string message);
    }

    public interface IPaymentGatewayFactory
    {
        IPaymentValidator CreateValidator();
        IPaymentProcessor CreateProcessor();
        IPaymentLogger CreateLogger();
    }
}