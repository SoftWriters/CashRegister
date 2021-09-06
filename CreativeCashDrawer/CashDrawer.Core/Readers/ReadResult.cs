namespace CashDrawer.Core.Readers
{
    public record ReadResult
    {
        public readonly decimal Due;
        public readonly decimal Paid;
        public readonly string  Error;

        public bool HasError => Error != null;


        public ReadResult(decimal due, decimal paid, string error)
        {
            Due = due;
            Paid = paid;
            Error = error;
        }

        public static ReadResult Failed(string error)
        {
            return new ReadResult(0, 0, error);
        }

        public static ReadResult Ok(decimal due, decimal paid)
        {
            return new ReadResult(due, paid, null);
        }

    }
}
