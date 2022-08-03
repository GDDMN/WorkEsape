using UnityEngine;

namespace PurpleDrank
{
    public class InteractWithWalkPoint : InteractWithEnemy
    {
        public override void Interact(EnemyController enemy) => enemy.SetNewDistantion();
    }

}