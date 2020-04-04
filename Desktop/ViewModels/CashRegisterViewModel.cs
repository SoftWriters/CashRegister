using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Threading;
using ReactiveUI;

namespace Desktop.ViewModels
{
    public class CashRegisterViewModel : ReactiveObject
    {
        private string _input = "";
        private string _output = "";

        public string Input
        {
            get { return _input; }
            set { this.RaiseAndSetIfChanged(ref this._input, value); }
        }

        public string Output
        {
            get { return _output; }
            set { this.RaiseAndSetIfChanged(ref this._output, value); }
        }
    }
}