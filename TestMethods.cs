using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        // Funcion aux para determinar si es primo
        private static bool IsPrime(int n)
        {
            if (n == 1) return true; // asumir que 1 es primo para este ejercicio
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            var result = new Dictionary<int, EValueType>();
            if (sourceArr == null) return result;

            for (int i = 0; i < sourceArr.Length; i++)
            {
                int n = sourceArr[i];

                if (n % 2 == 0)
                    result.Add(n, EValueType.Two);
                else if (n % 3 == 0)
                    result.Add(n, EValueType.Three);
                else if (n % 5 == 0)
                    result.Add(n, EValueType.Five);
                else if (n % 7 == 0)
                    result.Add(n, EValueType.Seven);
                else if (IsPrime(n))
                    result.Add(n, EValueType.Prime);
            }
            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            if (sourceDict == null) return 0;
            int count = 0;
            foreach (var pair in sourceDict)
            {
                if (pair.Value == type)
                    count++;
            }
            return count;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            var result = new Dictionary<int, EValueType>();
            if (sourceDict == null) return result;

            // Copiar las claves a un arreglo 
            int[] keys = new int[sourceDict.Count];
            int idx = 0;
            foreach (var key in sourceDict.Keys)
            {
                keys[idx++] = key;
            }

            // uso de bubble sort para ordenar las keys en orden descendente
            for (int i = 0; i < keys.Length - 1; i++)
            {
                for (int j = 0; j < keys.Length - i - 1; j++)
                {
                    if (keys[j] < keys[j + 1])
                    {
                        int temp = keys[j];
                        keys[j] = keys[j + 1];
                        keys[j + 1] = temp;
                    }
                }
            }

            // agregar al resultado en orden descendente
            for (int i = 0; i < keys.Length; i++)
            {
                result.Add(keys[i], sourceDict[keys[i]]);
            }
            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {

            // Inicializar las tres colas
            Queue<Ticket> paymentQueue = new Queue<Ticket>();
            Queue<Ticket> subscriptionQueue = new Queue<Ticket>();
            Queue<Ticket> cancellationQueue = new Queue<Ticket>();

            if (sourceList == null)
                return new Queue<Ticket>[] { paymentQueue, subscriptionQueue, cancellationQueue };

            // Insertar los tickets en la cola correspondiente
            for (int i = 0; i < sourceList.Count; i++)
            {
                Ticket t = sourceList[i];
                if (t.RequestType == Ticket.ERequestType.Payment)
                    paymentQueue.Enqueue(t);
                else if (t.RequestType == Ticket.ERequestType.Subscription)
                    subscriptionQueue.Enqueue(t);
                else if (t.RequestType == Ticket.ERequestType.Cancellation)
                    cancellationQueue.Enqueue(t);
            }

            // Ordenar cada cola por turno ascendente (sin LINQ)
            paymentQueue = SortQueueByTurn(paymentQueue);
            subscriptionQueue = SortQueueByTurn(subscriptionQueue);
            cancellationQueue = SortQueueByTurn(cancellationQueue);

            // Retornar en el orden solicitado
            return new Queue<Ticket>[] { paymentQueue, subscriptionQueue, cancellationQueue };
        }

        // Ordena una cola de tickets por turno ascendente
        private static Queue<Ticket> SortQueueByTurn(Queue<Ticket> queue)
        {
            // Copiar a arreglo
            int count = queue.Count;
            Ticket[] arr = new Ticket[count];
            int idx = 0;
            foreach (var t in queue)
            {
                arr[idx++] = t;
            }

            // Bubble sort por Turn ascendente
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].Turn > arr[j + 1].Turn)
                    {
                        Ticket temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            // Crear nueva cola ordenada
            Queue<Ticket> sortedQueue = new Queue<Ticket>();
            for (int i = 0; i < arr.Length; i++)
            {
                sortedQueue.Enqueue(arr[i]);
            }
            return sortedQueue;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            // Validar cola y ticket
            if (targetQueue == null || ticket.Turn < 1 || ticket.Turn > 99)
                return false;

            // Si la cola está vacía, agregar directamente
            if (targetQueue.Count == 0)
            {
                targetQueue.Enqueue(ticket);
                return true;
            }

            // Verificar que el tipo de request coincida con la cola
            Ticket first = default;
            bool hasFirst = false;
            foreach (var t in targetQueue)
            {
                first = t;
                hasFirst = true;
                break;
            }
            if (hasFirst && first.RequestType != ticket.RequestType)
                return false;

            // Insertar el ticket en la posición correcta para mantener el orden por turno ascendente
            List<Ticket> tempList = new List<Ticket>();
            bool inserted = false;
            foreach (var t in targetQueue)
            {
                if (!inserted && ticket.Turn < t.Turn)
                {
                    tempList.Add(ticket);
                    inserted = true;
                }
                tempList.Add(t);
            }
            if (!inserted)
                tempList.Add(ticket);

            // Limpiar y reconstruir la cola
            targetQueue.Clear();
            for (int i = 0; i < tempList.Count; i++)
            {
                targetQueue.Enqueue(tempList[i]);
            }
            return true;
        }        
    }
}