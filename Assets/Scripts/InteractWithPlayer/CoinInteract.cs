using UnityEngine;

namespace PurpleDrank
{
    public class CoinInteract : InteractWithPlayer
    {
        public override void Interact()
        {
            resManager.IncreaseResource(ResourceType.GOLD, 1);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Interact();
        }
    }
}

