namespace Trendyol.TyMiddleware.Outputs.Logging.LogConfig
{
    public class CustomField
    {
        private string _fieldName;
        private object _fieldValue;

        public CustomField(string name, object value)
        {
            FieldName = name;
            FieldValue = value;
        }

        public string FieldName
        {
            get => _fieldName;
            set => _fieldName = value;
        }

        public object FieldValue
        {
            get => _fieldValue;
            set => _fieldValue = value;
        }
    }
}