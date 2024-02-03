using System.Linq;
using GameEngine;

namespace SaveLoaders
{
    public sealed class ResourcesSaveLoader : SaveLoader<ResourceData[], ResourceService>
    {
        protected override ResourceData[] ConvertToData(ResourceService service)
        {
            var resourceList = service.GetResources().ToArray();
            var resourceDataList = new ResourceData[resourceList.Length];
            
            for (int i = 0; i < resourceList.Length; i++)
            {
                resourceDataList[i].id = resourceList[i].ID;
                resourceDataList[i].amount = resourceList[i].Amount;
            }

            return resourceDataList;
        }

        protected override void SetupData(ResourceData[] data, ResourceService service)
        {
            var resourceList = service.GetResources().ToArray();

            for (int i = 0; i < data.Length; i++) 
            {
                if (resourceList[i].ID == data[i].id)
                {
                    resourceList[i].Amount = data[i].amount;
                }
            }
            
            service.SetResources(resourceList);
        }
    }
}