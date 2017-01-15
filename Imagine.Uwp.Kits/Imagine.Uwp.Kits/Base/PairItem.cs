namespace Imagine.Uwp.Kits.Base
{
    public class PairItem
    {
        public enum ValueType
        {
            StringValue,
            IntValue,
            LongValue,
            DoubleValue,
            ByteArrayValue,
            MemoryStreamValue
        }

        public string Key { get; set; }

        public object Value { get; set; }
        
        public ValueType TypeOfValue
        {
            get; set;
        }
    }
}
