//InteractiveModeScreen
//Since the application is a "SPA", of sorts...
//This class to keep track of an audit trail for when the user traverses to this virtual screen
namespace CCDS.res.forms.traversal.screens
{
    public class InteractiveModeScreen : AuditTrail
    {
        public InteractiveModeScreen()
        {
            SetScreenName("INTERACTIVE_MODE_SCREEN");
            SetActiveStatus(false);
        } 
    }
}
