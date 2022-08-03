using UnityEngine;

namespace PurpleDrank
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        public ResourceItem resources;
        public void AddRes(ResourceType type)
        {
            ResourceInfo _res = new ResourceInfo();
            resources.Add(type, _res);
        }
    }
}

