namespace EasyDI.Core.Classes
{
    public class NameValueParameter
    {
        public string Name { get; }
        public object Value { get; }

        public NameValueParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
