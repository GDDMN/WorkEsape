using UnityEngine;

namespace PurpleDrank
{
    public abstract class InteractWithPlayer : MonoBehaviour
    {
        public ResourceManager resManager;

        public void Awake()
        {
            resManager = FindObjectOfType<ResourceManager>();
        }

        public abstract void Interact();
    }
}