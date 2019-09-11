using System;

namespace DataAccess.Entity
{
    public class DelimitedFileValidationRule
    {
        public DelimitedFileValidationRule()
        {
            this.ColIndex = -1;
            this.ExpectedDataType = Type.GetType("System.Decimal");
            this.Required = false;
            this.MinValue = null;
            this.MaxValue = null;
        }

        public string InputFileType { get; set; }

        /// <summary>
        /// Zero based
        /// </summary>
        public int ColIndex { get; set; }

        public Type ExpectedDataType { get; set; }

        public bool Required { get; set; }

        public decimal? MinValue { get; set; }

        public decimal? MaxValue { get; set; }
    }
}