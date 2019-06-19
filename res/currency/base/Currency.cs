// Base class for currency creation - acts as an abstract "ordering" mechanism for making them...
namespace CCDS.res.currency.@base
{
    public abstract class Currency
    {
        private string _pluralName;
        private string _singularName;
        private long _quantity;
        private decimal _value;
        // Newly defined objects change easily from here: 
        public string GetPluralName() => _pluralName;
        public long GetQuantity() => _quantity;
        public decimal GetValue() => _value;
        public void SetPluralName(string name) => _pluralName = name;
        public string GetSingularName() => _singularName;
        public void SetSingularName(string name) => _singularName = name;
        public void SetQuantity(long quantity) => _quantity = quantity;
        public void SetValue(decimal value) => _value = value;
        protected internal abstract void ChooseCurrency();
        public void GetCurrencyName() => GetPluralName();
        /*public decimal GetCurrencyValue() => Value.ToDecimal();
         public long GetCurrencyQuantity() => Quantity.ToInt64();*/   //todo - add specific denomination class files
    }
}