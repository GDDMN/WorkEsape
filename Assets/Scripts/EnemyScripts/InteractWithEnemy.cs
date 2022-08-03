using UnityEngine;

namespace PurpleDrank
{
    abstract public class InteractWithEnemy : MonoBehaviour
    {
        public abstract void Interact(EnemyController enemy);
    }
}