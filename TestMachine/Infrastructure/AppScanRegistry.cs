using StructureMap;
using StructureMap.Graph;

namespace CashMachine.Infrastructure
{
    class AppScanRegistry : Registry
    {
        public AppScanRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AssembliesFromApplicationBaseDirectory();
                scan.WithDefaultConventions();
            });
        }
    }
}
