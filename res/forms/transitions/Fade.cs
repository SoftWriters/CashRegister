// Provides the form with fade-in and fade-out opacity capability
using System;
using System.Threading;
using System.Windows.Forms;
namespace CCDS.res.forms.transitions
{
    class Fade
    {
        private const int fadeAmt = 9;
        private const int fadeMax = 97;
        private const int fadeMin = 1;
        private const int fadeSleep = 5;
        public void In(Form form)
        {
            for (var i = 0; (i <= fadeMax); i = (i + fadeAmt))
            {
                StepOpacity(form, i);
            }
        }
        public void Out(Form form)
        {
            for (var i = fadeMax; (i >= fadeMin); i = (i - fadeAmt))
            {
                StepOpacity(form, i);
            }
        }
        private static void StepOpacity(Form form, int idx)
        {
            form.Opacity = (idx / Math.Pow(Math.Abs(fadeAmt), 2));
            form.Refresh();
            Thread.Sleep(Math.Abs(fadeAmt * fadeSleep));
        }
    }
}