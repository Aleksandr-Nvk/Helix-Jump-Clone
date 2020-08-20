using System.Collections.Generic;
using Dictionaries.Pairs;
using System.Linq;

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
            return List.ToDictionary(item => item.Key, item => item.Value);
        }
    }
}