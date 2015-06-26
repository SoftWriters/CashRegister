namespace CashRegisterProject.Business
{
    public abstract class AbsTranslator
    {
        abstract public string TranslateAmount(decimal number);
        
        protected string AddComma(string str)
        {
            return str.Length > 0 ? ", " : "";
        }

    }

}
