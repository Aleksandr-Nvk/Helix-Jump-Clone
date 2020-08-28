using System.Collections.Generic;
using Interfaces;
using System;

namespace Containers
{
    public class ReferencesContainer : IContainer
    {
        private readonly Dictionary<Type, object> _references = new Dictionary<Type, object>();

        /// <summary>
        /// Adds the reference and its type to the references dictionary
        /// </summary>
        /// <param name="reference"> Reference to add </param>
        /// <typeparam name="T1"> Reference type </typeparam>
        public void Add<T1>(T1 reference)
        {
            _references.Add(reference.GetType(), reference);
        }

        /// <summary>
        /// Takes the reference from the dictionary
        /// </summary>
        /// <typeparam name="T1"> Reference type </typeparam>
        /// <returns> Reference </returns>
        public T1 Resolve<T1>() where T1 : class
        {
            return _references[typeof(T1)] as T1;
        }
    }
}