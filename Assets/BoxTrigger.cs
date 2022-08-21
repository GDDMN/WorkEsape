using UnityEngine;

namespace PurpleDrank
{
    public class BoxTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            GameSceneManager.Instance.SetEndLvlState();
        }
    }
}

