using CashDrawer.Core;
using CashDrawer.Core.Writers;
using System;
using System.IO;

namespace CashDrawer.App.FileWriters
{
    public class OutputFileWriter : IOutputWriter
    {
        private readonly string     _filename;
        private readonly IHumanizer _humanizer;


        public OutputFileWriter(string filename, IHumanizer humanizer)
        {
            _filename = filename;
            _humanizer = humanizer;
        }


        public void Write(Change change)
        {
            var line = _humanizer.Humanize(change);
            File.AppendAllText(_filename, line + Environment.NewLine);
        }


        public void WriteError(string error)
        {
            File.AppendAllText(_filename, error);
        }
    }
}
