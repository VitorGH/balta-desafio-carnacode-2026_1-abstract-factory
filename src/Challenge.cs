using System;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            var pagSeguroService = new PaymentService(new PagSeguroFactory());
            pagSeguroService.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();

            var mercadoPagoService = new PaymentService(new MercadoPagoFactory());
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

            Console.WriteLine();

            var stripeService = new PaymentService(new StripeFactory());
            stripeService.ProcessPayment(300.00m, "4234567890123456");

            Console.ReadLine();
        }
    }
}
