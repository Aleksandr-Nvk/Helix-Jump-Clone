using System.Collections.Generic;
using Dictionaries.Pairs;

namespace Dictionaries.Lists
{
    public abstract class BasePairList<T1, T2>
    {
        protected abstract IEnumerable<BasePair<T1, T2>> List { get; }

        /// <summary>
        /// Converts list into a dictionary
        /// </summary>
        /// <returns> New dictionary from the list </returns>
        public Dictionary<T1, T2> ToDictionary()
        {
            var newDictionary = new Dictionary<T1, T2>();
            
            foreach (var item in List)
            {
                newDictionary.Add(item.Key, item.Value);
            }

            return newDictionary;
        }
    }
}