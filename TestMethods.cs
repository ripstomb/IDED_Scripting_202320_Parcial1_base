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

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            Stack<int> result = null;
            int currentValue;
            int nextValue;

            
            for (int i = sourceStack.Count - 1; i >= 0; i--)
            {
                currentValue = sourceStack[i];

                // Busca el siguiente número mayor en la pila.
                for (int j = i + 1; j < sourceStack.Count; j++)
                {
                    nextValue = sourceStack[j];

                    if (nextValue > currentValue)
                    {
                        result.Push(nextValue);
                        break;
                    }
                }

                // Si no se encuentra un número mayor, ponemos -1.
                if (result.Count == 0)
                {
                    result.Push(-1);
                }
            }

            return result;
        }
    

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            return 0;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = null;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            return result;
        }        
    }
}