namespace Interfaces
{
    // represents common piece behaviour data
    public interface IPiece
    {
        /// <summary>
        /// Destroys the inherited piece with special animation
        /// </summary>
        /// <param name="time"> Animation duration </param>
        void Delete(float time);
    }
}