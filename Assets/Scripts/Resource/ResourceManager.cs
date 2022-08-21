using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PurpleDrank
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        public ResourceItem resources;
        public List<UIResourceLabel> labels = new List<UIResourceLabel>(); 

        public void AddRes(ResourceType type)
        {
            ResourceInfo _res = new ResourceInfo();
            resources.Add(type, _res);
        }

        public void IncreaseResource(ResourceType type, int count)
        {
            resources[type].current += count;
            UIResourceLabel lable = labels.FirstOrDefault(label => label.GetResourceType() == type);
            lable.OnResourceUpdate.Invoke();
        }
    }
}

