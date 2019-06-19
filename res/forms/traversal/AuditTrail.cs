//Abstract class implements a factory design pattern for screens presented to the user that get created at runtime
//Keeps track, or "audits" user navigation.
namespace CCDS.res.forms.traversal
{
    public abstract class AuditTrail
    {
        private string _screenName;
        private bool _focusValue;
        public string GetScreenName() => _screenName;
        public void SetScreenName(string name) => _screenName = name;
        public bool GetActiveStatus() => _focusValue;
        public void SetActiveStatus(bool activated) => _focusValue = activated;
    }
}