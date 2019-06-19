//Command Console/Prompt/Terminal specific functionality...
using ZBobb; //<= 3rd party .dll control for transparent textbox (@see CashRegister\res\ctrls\console\AlphaBlendTextBox.dll)

namespace CCDS.res.ctrls.console.io.output
{
    class Prompt
    {
        private int _cursor;
        private AlphaBlendTextBox _console;

        public Prompt(AlphaBlendTextBox textTerminal)
        {
            SetConsole(textTerminal);
            initializeText();
        }
        public int GetPromptStartingPosition() => _cursor;

        public void SetCursorPosition(int pos) => _cursor = pos;

        public AlphaBlendTextBox GetConsole() => _console;

        public void SetConsole(AlphaBlendTextBox textTerminal) => _console = textTerminal;

        public void initializeText() => _console.Text = $@"Please enter the total due, and the amount paid separated by a comma (e.g., ""2.13, 3.00""):  ";
        public void reInitializeText() => _console.AppendText($@"{Program.CarriageReturnLineFeed}{Program.CarriageReturnLineFeed}Please enter the total due, and the amount paid separated by a comma (e.g., ""2.13, 3.00""):  ");

        public void Clear()
        {
            initializeText();
            ResetCursorPosition();
            _console.ReadOnly = false;
            _console.Focus();
            _console.Select(_console.TextLength, 0);
        }
        public void ResetCursorPosition() => SetCursorPosition(_console.TextLength);

        public void WriteInformationMessageToConsole(string msg)
        {
            _console.AppendText($"{Program.CarriageReturnLineFeed}");
            _console.AppendText($"{Program.CarriageReturnLineFeed}==============================================================");
            _console.AppendText($"{msg}");
            _console.AppendText($"{Program.CarriageReturnLineFeed}==============================================================");
            reInitializeText();
            ResetCursorPosition();
        }
    }
}