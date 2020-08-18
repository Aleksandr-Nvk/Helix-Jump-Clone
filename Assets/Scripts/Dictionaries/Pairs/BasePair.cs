namespace Dictionaries.Pairs
{
    public abstract class BasePair<T1, T2>
    {
        public T1 Key;
        public T2 Value;

        protected BasePair(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }
    }
}