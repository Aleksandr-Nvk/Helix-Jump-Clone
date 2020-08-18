using System;
using System.Collections.Generic;

namespace Oduvaanchikk.HelixJumpClone.Runtime
{
    [Serializable]
    public abstract class BasePairList<T1, T2>
    {
        protected abstract IEnumerable<BasePair<T1, T2>> List { get; }

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