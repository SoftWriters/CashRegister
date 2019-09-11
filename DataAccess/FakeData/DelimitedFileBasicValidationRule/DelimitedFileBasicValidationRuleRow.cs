using System;

namespace DataAccess.FakeData.DelimitedFileBasicValidationRule
{
    public abstract class DelimitedFileBasicValidationRuleRow
    {
        public abstract string InputFileType { get; }

        public abstract int ColIndex { get; }

        public abstract string ExpectedDataTypeText { get; }

        public Type ExpectedDataType
        {
            get
            {
                return Type.GetType(this.ExpectedDataTypeText);
            }
        }

        public abstract bool Required { get; }

        public abstract decimal? MinValue { get; }

        public abstract decimal? MaxValue { get; }
    }
}