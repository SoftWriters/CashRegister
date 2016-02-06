using StructureMap.AutoMocking;

namespace BasicConsoleAppTests
{
    public class With<TSubject> where TSubject : class
    {
        public With()
        {
            Mocks = new RhinoAutoMocker<TSubject>();
        }

        public static TDependency For<TDependency>()
            where TDependency : class
        {
            return Mocks.Get<TDependency>();
        }

        public static RhinoAutoMocker<TSubject> Mocks { get; private set; }
    }
}
