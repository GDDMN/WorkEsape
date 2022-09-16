using UnityEngine;

namespace PurpleDrank
{
    public class CoinInteract : InteractWithPlayer
    {
        [SerializeField] private ParticleSystem _particle;

        public override void Interact()
        {
            var particle = Instantiate(_particle, transform.position, Quaternion.identity);
            resManager.IncreaseResource(ResourceType.GOLD, 1);

            Destroy(particle, 3f);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Interact();
        }
    }
}

