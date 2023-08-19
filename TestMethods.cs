using System;
using System.Collections.Generic;
using System.Linq;

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

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            Stack<int> resultStack = new Stack<int>();
            Stack<int> tempStack = new Stack<int>();

            while (sourceStack.Count > 0)
            {
                int current = sourceStack.Pop();

                while (tempStack.Count > 0 && tempStack.Peek() <= current)
                {
                    tempStack.Pop();
                }

                if (tempStack.Count > 0)
                {
                    resultStack.Push(tempStack.Peek());
                }
                else
                {
                    resultStack.Push(-1);
                }

                tempStack.Push(current);
            }

            while (resultStack.Count > 0)
            {
                sourceStack.Push(resultStack.Pop());
            }

            return sourceStack;
        }


        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            foreach (int num in sourceArr)
            {
                if (num % 2 == 0)
                    result[num] = EValueType.Two;
                else if (num % 3 == 0)
                    result[num] = EValueType.Three;
                else if (num % 5 == 0)
                    result[num] = EValueType.Five;
                else if (num % 7 == 0)
                    result[num] = EValueType.Seven;
                else
                    result[num] = EValueType.Prime;
            }

            return result;
        }


        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int count = sourceDict.Count(kv => kv.Value == type);
            return count;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = sourceDict.OrderByDescending(kv => kv.Key)
                                                           .ToDictionary(kv => kv.Key, kv => kv.Value);
            return result;
        }


        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3];

            for (int i = 0; i < 3; i++)
            {
                result[i] = new Queue<Ticket>();
            }

            var groupedTickets = sourceList.OrderBy(ticket => ticket.Turn)
                                          .GroupBy(ticket => ticket.RequestType);

            foreach (var group in groupedTickets)
            {
                switch (group.Key)
                {
                    case Ticket.ERequestType.Payment:
                        foreach (var ticket in group)
                        {
                            result[0].Enqueue(ticket);
                        }
                        break;
                    case Ticket.ERequestType.Subscription:
                        foreach (var ticket in group)
                        {
                            result[1].Enqueue(ticket);
                        }
                        break;
                    case Ticket.ERequestType.Cancellation:
                        foreach (var ticket in group)
                        {
                            result[2].Enqueue(ticket);
                        }
                        break;
                }
            }

            return result;
        }


        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            if (ticket.Turn <1 || ticket.Turn >99)
            {
                return false;
            }

            targetQueue.Enqueue(ticket);
            return true;
        }
    }
}
