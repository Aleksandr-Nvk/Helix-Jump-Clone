namespace Containers
{
    // platform entity 
    public class Platform<T>
    {
        public readonly T[] Pieces = new T[Consts.PiecesCount];
    }
}