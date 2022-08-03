using UnityEngine;

namespace PurpleDrank
{
    public class BoxTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            SaveGameManager.Instance._allRes[(int)ResourceType.GOLD].current += 10;
            GameSceneManager.Instance.SetEndLvlState();
        }
    }
}

