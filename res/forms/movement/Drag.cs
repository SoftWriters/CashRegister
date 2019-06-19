// Enables/Disables the ability to drag the form around the available screen real estate
using System.Windows.Forms;

namespace CCDS.res.forms.movement
{
    class Drag
    {
        private bool drag;
        private int mousex;
        private int mousey;
        private Form form;
        public void Disable()
        {
            Set(false);  //'Sets the variable drag to false.
        }
        public Drag(Form frm)
        {
            form = frm;
        }
        public void Enable()
        {
            Set(true);  //Sets the variable drag to true.
            ResetMouseCursorCoordinates(); 
        }
        private bool Get() => drag;
        public bool IsEnabled() => Get();
        public void Move()
        {
            form.Top = (Cursor.Position.Y - mousey);
            form.Left = (Cursor.Position.X - mousex); // If drag is set to true then move the form accordingly.
        }
        private void ResetMouseCursorCoordinates()
        {
            mousex = (Cursor.Position.X - form.Left);
            mousey = (Cursor.Position.Y - form.Top);  // Sets variable mousex, Sets variable mouse-y
        }
        private void Set(bool truthVal)
        {
            drag = truthVal;
        }
    }
}