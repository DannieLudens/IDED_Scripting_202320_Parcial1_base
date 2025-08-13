using NUnit.Framework;
using System.Collections.Generic;
using static TestProject1.TestMethods;
using static TestProject1.Ticket;

namespace TestProject1
{
    public class Tests
    {
        #region Stacks

        private Stack<int> testStackA;
        private Stack<int> testStackB;
        private Stack<int> testSortedStack;

        private Stack<int> testStackResultA;
        private Stack<int> testStackResultB;
        private Stack<int> testSortedStackResult;

        private readonly int[] testStackElementsA = { 26, 3, 6, 5 };
        private readonly int[] testStackResultElementsA = { -1, 6, -1, -1 };

        private readonly int[] testStackElementsB = { 14, 8, 7, 13 };
        private readonly int[] testStackResultElementsB = { -1, 13, 13, -1 };

        private readonly int[] testSortedStackElements = { 20, 15, 4, 3 };
        private readonly int[] testSortedStackResultElements = { -1, -1, -1, -1 };

        #endregion Stacks

        #region ClassifiedDictionary

        private Dictionary<int, EValueType> testDict1;
        private Dictionary<int, EValueType> testDict2;
        private Dictionary<int, EValueType> testDict3;

        private readonly int[] testDict1Elements = { 10, 4, 5, 3, 9, 34, 8, 13, 7 };
        private readonly int[] testDict2Elements = { 11, 23, 41, 61, 7, 20, 40, 99 };
        private readonly int[] testDict3Elements = { 30, 25, 45, 8, 56, 105, 21, 1, 2 };

        private readonly Dictionary<int, EValueType> resultDict1 = new Dictionary<int, EValueType>()
        {
            { 10, EValueType.Two },
            { 4, EValueType.Two },
            { 5, EValueType.Five },
            { 3, EValueType.Three },
            { 9, EValueType.Three },
            { 34, EValueType.Two },
            { 8, EValueType.Two },
            { 13, EValueType.Prime },
            { 7, EValueType.Seven }
        };

        private readonly Dictionary<int, EValueType> resultDict2 = new Dictionary<int, EValueType>()
        {
            { 11, EValueType.Prime },
            { 23, EValueType.Prime },
            { 41, EValueType.Prime },
            { 61, EValueType.Prime },
            { 7, EValueType.Seven },
            { 20, EValueType.Two },
            { 40, EValueType.Two },
            { 99, EValueType.Three },
        };

        private readonly Dictionary<int, EValueType> resultDict3 = new Dictionary<int, EValueType>()
        {
            { 30, EValueType.Two },
            { 25, EValueType.Five },
            { 45, EValueType.Three },
            { 8, EValueType.Two },
            { 56, EValueType.Two },
            { 105, EValueType.Three },
            { 21, EValueType.Three },
            { 1, EValueType.Prime },
            { 2, EValueType.Two },
        };

        private readonly Dictionary<int, EValueType> sortedResultDict1 = new Dictionary<int, EValueType>()
        {
            { 34, EValueType.Two },
            { 13, EValueType.Prime },
            { 10, EValueType.Two },
            { 9, EValueType.Three },
            { 8, EValueType.Two },
            { 7, EValueType.Seven },
            { 5, EValueType.Five },
            { 4, EValueType.Two },
            { 3, EValueType.Three },
        };

        private readonly Dictionary<int, EValueType> sortedResultDict2 = new Dictionary<int, EValueType>()
        {
            { 99, EValueType.Three },
            { 61, EValueType.Prime },
            { 41, EValueType.Prime },
            { 40, EValueType.Two },
            { 23, EValueType.Prime },
            { 20, EValueType.Two },
            { 11, EValueType.Prime },
            { 7, EValueType.Seven },
        };

        private readonly Dictionary<int, EValueType> sortedResultDict3 = new Dictionary<int, EValueType>()
        {
            { 105, EValueType.Three },
            { 56, EValueType.Two },
            { 45, EValueType.Three },
            { 30, EValueType.Two },
            { 25, EValueType.Five },
            { 21, EValueType.Three },
            { 8, EValueType.Two },
            { 2, EValueType.Two },
            { 1, EValueType.Prime },
        };

        #endregion ClassifiedDictionary

        #region ServiceCenterStructures

        private Queue<Ticket> resultPaymentQueue;
        private Queue<Ticket> resultSubscriptionQueue;
        private Queue<Ticket> resultCancellationQueue;

        private readonly List<Ticket> testTicketElements = new List<Ticket>
        {
            new Ticket(ERequestType.Payment, 30),
            new Ticket(ERequestType.Cancellation, 24),
            new Ticket(ERequestType.Cancellation, 50),
            new Ticket(ERequestType.Subscription, 99),
            new Ticket(ERequestType.Payment, 31),
            new Ticket(ERequestType.Subscription, 80),
            new Ticket(ERequestType.Payment, 80),
            new Ticket(ERequestType.Cancellation, 1),
            new Ticket(ERequestType.Subscription, 30),
            new Ticket(ERequestType.Cancellation, 80),
            new Ticket(ERequestType.Payment, 10),
            new Ticket(ERequestType.Payment, 6),
            new Ticket(ERequestType.Cancellation, 39),
            new Ticket(ERequestType.Subscription, 95),
            new Ticket(ERequestType.Subscription, 43),
            new Ticket(ERequestType.Cancellation, 70),
            new Ticket(ERequestType.Payment, 15),
            new Ticket(ERequestType.Payment, 41),
            new Ticket(ERequestType.Subscription, 66),
            new Ticket(ERequestType.Cancellation, 3),
        };

        private Ticket[] resultPaymentTicketElements =
        {
            new Ticket(ERequestType.Payment, 6),
            new Ticket(ERequestType.Payment, 10),
            new Ticket(ERequestType.Payment, 15),
            new Ticket(ERequestType.Payment, 30),
            new Ticket(ERequestType.Payment, 31),
            new Ticket(ERequestType.Payment, 41),
            new Ticket(ERequestType.Payment, 80),
        };

        private Ticket[] resultSubscriptionTicketElements =
        {
            new Ticket(ERequestType.Subscription, 30),
            new Ticket(ERequestType.Subscription, 43),
            new Ticket(ERequestType.Subscription, 66),
            new Ticket(ERequestType.Subscription, 80),
            new Ticket(ERequestType.Subscription, 95),
            new Ticket(ERequestType.Subscription, 99),
        };

        private Ticket[] resultCancellationTicketElements =
        {
            new Ticket(ERequestType.Cancellation, 1),
            new Ticket(ERequestType.Cancellation, 3),
            new Ticket(ERequestType.Cancellation, 24),
            new Ticket(ERequestType.Cancellation, 39),
            new Ticket(ERequestType.Cancellation, 50),
            new Ticket(ERequestType.Cancellation, 70),
            new Ticket(ERequestType.Cancellation, 80),
        };

        #endregion ServiceCenterStructures

        public void PopulateTicketCollections()
        {
            TestUtils.Populate(ref resultPaymentQueue, resultPaymentTicketElements);
            TestUtils.Populate(ref resultSubscriptionQueue, resultSubscriptionTicketElements);
            TestUtils.Populate(ref resultCancellationQueue, resultCancellationTicketElements);
        }

        [TearDown]
        public void ClearAllStructures()
        {
            ClearNGVStacks();
            ClearDictionaries();
            ClearQueues();
            ClearQueues();
        }

        /// <summary>
        /// Tests TestMethods.FillDictionaryFromSource
        /// </summary>
        [Test]
        public void TestFillDictionaryFromSource()
        {
            FillTestDictionaries();

            // Tests dictionaries are filled as expected.
            Assert.IsTrue(testDict1.HasSameElementsAtIndeces(resultDict1));
            Assert.IsTrue(testDict2.HasSameElementsAtIndeces(resultDict2));
            Assert.IsTrue(testDict3.HasSameElementsAtIndeces(resultDict3));

            // Tests dictionary keys are associated with the correct value
            Assert.IsTrue(testDict1.GetValueOrDefault(13) == EValueType.Prime);
            Assert.IsTrue(testDict1.GetValueOrDefault(10) == EValueType.Two);
            Assert.IsTrue(testDict1.GetValueOrDefault(7) == EValueType.Seven);

            Assert.IsTrue(testDict2.GetValueOrDefault(61) == EValueType.Prime);
            Assert.IsTrue(testDict2.GetValueOrDefault(99) == EValueType.Three);
            Assert.IsFalse(testDict2.GetValueOrDefault(20) == EValueType.Five);

            Assert.IsFalse(testDict3.GetValueOrDefault(21) == EValueType.Seven);
            Assert.IsFalse(testDict3.GetValueOrDefault(105) == EValueType.Five);
            Assert.IsTrue(testDict3.GetValueOrDefault(1) == EValueType.Prime);
        }

        /// <summary>
        /// Tests TestMethods.CountDictionaryRegistriesWithValueType
        /// </summary>
        [Test]
        public void TestCountDictionaryRegistriesWithValueType()
        {
            FillTestDictionaries();

            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict1, EValueType.Two), 4);
            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict1, EValueType.Five), 1);
            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict1, EValueType.Three), 2);

            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict2, EValueType.Five), 0);
            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict2, EValueType.Seven), 1);
            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict2, EValueType.Prime), 4);

            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict3, EValueType.Five), 1);
            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict3, EValueType.Two), 4);
            Assert.AreEqual(CountDictionaryRegistriesWithValueType(testDict3, EValueType.Three), 3);
        }

        /// <summary>
        /// Tests TestMethods.SortDictionaryRegistries
        /// </summary>
        [Test]
        public void TestSortDictionaryRegistries()
        {
            FillTestDictionaries();

            Dictionary<int, EValueType> sortedDict1 = SortDictionaryRegistries(testDict1);
            Dictionary<int, EValueType> sortedDict2 = SortDictionaryRegistries(testDict2);
            Dictionary<int, EValueType> sortedDict3 = SortDictionaryRegistries(testDict3);

            Assert.IsTrue(sortedDict1.HasSameElementsAtIndeces(sortedResultDict1));
            Assert.IsTrue(sortedDict2.HasSameElementsAtIndeces(sortedResultDict2));
            Assert.IsTrue(sortedDict3.HasSameElementsAtIndeces(sortedResultDict3));
        }

        /// <summary>
        /// Tests TestMethods.ClassifyTickets
        /// </summary>
        [Test]
        public void TestClassifyTickets()
        {
            PopulateTicketCollections();

            Queue<Ticket>[] resultQueues = { resultPaymentQueue, resultSubscriptionQueue, resultCancellationQueue };

            // Tests queues array has been correctly initialized and filled
            Queue<Ticket>[] testedQueues = ClassifyTickets(testTicketElements);
            Assert.IsNotEmpty(testedQueues);
            Assert.IsTrue(testedQueues.Length == 3);

            // Test each queue has the same elements in the same order
            Assert.IsTrue(testedQueues[0].HasSameElementsAtIndeces(resultPaymentQueue));
            Assert.IsTrue(testedQueues[1].HasSameElementsAtIndeces(resultSubscriptionQueue));
            Assert.IsTrue(testedQueues[2].HasSameElementsAtIndeces(resultCancellationQueue));
        }

        /// <summary>
        /// Tests TestMethods.AddNewTicket
        /// </summary>
        [Test]
        public void TestAddNewTicket()
        {
            Queue<Ticket>[] resultQueues = ClassifyTickets(testTicketElements);

            // Tests cannot add a turn higher than 99
            Assert.IsFalse(AddNewTicket(resultQueues[0], new Ticket(ERequestType.Payment, 100)));

            // Tests cannot add tickets of a different ERequestType in each queue
            Assert.IsTrue(AddNewTicket(resultQueues[0], new Ticket(ERequestType.Payment, 75)));
            Assert.IsTrue(AddNewTicket(resultQueues[0], new Ticket(ERequestType.Payment, 8)));
            Assert.IsFalse(AddNewTicket(resultQueues[0], new Ticket(ERequestType.Cancellation, 1)));

            Assert.IsTrue(AddNewTicket(resultQueues[1], new Ticket(ERequestType.Subscription, 15)));
            Assert.IsTrue(AddNewTicket(resultQueues[1], new Ticket(ERequestType.Subscription, 80)));
            Assert.False(AddNewTicket(resultQueues[1], new Ticket(ERequestType.Payment, 30)));

            Assert.IsFalse(AddNewTicket(resultQueues[2], new Ticket(ERequestType.Payment, 6)));
            Assert.IsFalse(AddNewTicket(resultQueues[2], new Ticket(ERequestType.Payment, 1)));
            Assert.IsTrue(AddNewTicket(resultQueues[2], new Ticket(ERequestType.Cancellation, 50)));
        }

        private void ClearNGVStacks()
        {
            testStackA?.Clear();
            testStackB?.Clear();
        }

        private void ClearQueues()
        {
            resultPaymentQueue?.Clear();
            resultSubscriptionQueue?.Clear();
            resultCancellationQueue?.Clear();
        }

        private void ClearDictionaries()
        {
            testDict1?.Clear();
            testDict2?.Clear();
            testDict3?.Clear();
        }

        private void PopulateTestNGVStacks()
        {
            TestUtils.Populate(ref testStackA, testStackElementsA);
            TestUtils.Populate(ref testStackResultA, testStackResultElementsA);
            TestUtils.Populate(ref testStackB, testStackElementsB);
            TestUtils.Populate(ref testStackResultB, testStackResultElementsB);
            TestUtils.Populate(ref testSortedStack, testSortedStackElements);
            TestUtils.Populate(ref testSortedStackResult, testSortedStackResultElements);
        }

        private void FillTestDictionaries()
        {
            testDict1 = FillDictionaryFromSource(testDict1Elements);
            testDict2 = FillDictionaryFromSource(testDict2Elements);
            testDict3 = FillDictionaryFromSource(testDict3Elements);
        }
    }
}