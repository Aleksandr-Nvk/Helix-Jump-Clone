namespace Interfaces
{
    public interface IContainer
    {
        /// <summary>
        /// Adds the reference and its type to the references dictionary
        /// </summary>
        /// <param name="reference"> Reference to add </param>
        /// <typeparam name="T1"> Reference type </typeparam>
        void Add<T1>(T1 reference);
        
        /// <summary>
        /// Takes the reference from the dictionary
        /// </summary>
        /// <typeparam name="T1"> Reference type </typeparam>
        /// <returns> Reference </returns>
        T1 Resolve<T1>() where T1: class;
    }
}