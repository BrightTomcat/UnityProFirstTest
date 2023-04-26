namespace Elementary
{
    public sealed class Value<T> : IValue<T>
    {
        public T Current { get; }

        public Value(T value)
        {
            this.Current = value;
        }
    }
}