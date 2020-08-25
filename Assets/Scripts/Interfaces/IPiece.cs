namespace Interfaces
{
    public interface IPiece
    {
        /// <summary>
        /// Destroys the inherited piece with special animation
        /// </summary>
        /// <param name="time"> Animation duration </param>
        void Delete(float time);
    }
}