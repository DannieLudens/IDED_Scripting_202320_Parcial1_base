using System;
using System.Collections.Generic;

namespace TestProject1
{
    internal class Sandbox
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Here you can write console prints to test your implementation outside the testing environment \n");

            // Ejemplo de un arreglo a ver si clasifica bien
            int[] testArray = { 10, 9, 5, 7, 13, 1 };
            Console.WriteLine("Test Array: " + string.Join(", ", testArray));

            var dict = TestMethods.FillDictionaryFromSource(testArray); // lleno el diccionario
            Console.WriteLine("\nResultado Dictionary:");
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }

            Console.WriteLine("/nPrueba de clasificación y adición de tickets\n");

            // Crear lista de tickets de ejemplo
            var tickets = new List<Ticket>
            {
                new Ticket(Ticket.ERequestType.Payment, 30),
                new Ticket(Ticket.ERequestType.Cancellation, 24),
                new Ticket(Ticket.ERequestType.Cancellation, 50),
                new Ticket(Ticket.ERequestType.Subscription, 99),
                new Ticket(Ticket.ERequestType.Payment, 31),
                new Ticket(Ticket.ERequestType.Subscription, 80),
                new Ticket(Ticket.ERequestType.Payment, 80),
                new Ticket(Ticket.ERequestType.Cancellation, 1),

            };

            // Clasificar tickets
            var queues = TestMethods.ClassifyTickets(tickets);

            // Mostrar colas clasificadas
            string[] queueNames = { "Payment", "Subscription", "Cancellation" };
            for (int i = 0; i < queues.Length; i++)
            {
                Console.WriteLine($"Cola de {queueNames[i]}:");
                foreach (var t in queues[i])
                {
                    Console.WriteLine($"  Turno: {t.Turn}");
                }
                Console.WriteLine();
            }

            // Probar AddNewTicket
            Console.WriteLine("Probando AddNewTicket en la cola de Payment:");
            var newTicket = new Ticket(Ticket.ERequestType.Payment, 8);
            bool added = TestMethods.AddNewTicket(queues[0], newTicket);
            Console.WriteLine($"¿Se agregó el ticket de turno 8? {added}");

            Console.WriteLine("Cola de Payment después de agregar:");
            foreach (var t in queues[0])
            {
                Console.WriteLine($"  Turno: {t.Turn}");
            }
        }
    }
}