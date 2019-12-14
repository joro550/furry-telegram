using System.Collections.Generic;
using System.Threading.Tasks;
using Pulumi;
using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

namespace Infra
{
    internal static class Program
    {
        private static Task<int> Main()
        {
            return Deployment.RunAsync(() => {

                // Create an Azure Resource Group
                var resourceGroup = new ResourceGroup("rgspeedruns");

                var appServicePlan = new Plan("sp-Speedruns", new PlanArgs
                {
                    Location = "UKSouth",
                    Kind = "FunctionApp",
                    ResourceGroupName = resourceGroup.Name,
                    Sku = new PlanSkuArgs
                    {
                        Tier = "Dynamic",
                        Size = "Y1"
                    }
                });

                var storageAccount = new Account("SpeedStorage", new AccountArgs
                {
                    AccountKind = "Storage",
                    AccountTier = "Standard",
                    AccountReplicationType = "LRS",
                    ResourceGroupName = resourceGroup.Name,
                });

                var updateRunnerApp = new FunctionApp("fn-UpdateRunners", new FunctionAppArgs
                {
                    AppServicePlanId = appServicePlan.Id,
                    ResourceGroupName = resourceGroup.Name,
                    StorageConnectionString = storageAccount.PrimaryConnectionString
                });

                return new Dictionary<string, object?> { };
            });
        }
    }
}
