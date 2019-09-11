namespace DataAccess.FakeData.DelimitedFileBasicValidationRule
{
    public class CashTransactionInputFileColumn2 : DelimitedFileBasicValidationRuleRow
    {
        public override string InputFileType { get { return "CashTransaction"; } }

        public override int ColIndex { get { return 1; } }

        public override string ExpectedDataTypeText { get { return "System.Decimal"; } }

        public override bool Required { get { return true; } }

        public override decimal? MinValue { get { return 0; } }

        public override decimal? MaxValue { get { return null; } }
    }
}
