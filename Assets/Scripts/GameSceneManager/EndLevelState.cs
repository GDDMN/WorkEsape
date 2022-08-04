using UnityEngine;

namespace PurpleDrank
{
    public class EndLevelState : IGameState
    {
        private Vector3 _startPosImage;
        
        public EndLevelState()
        {
            HypercasualEndLvl.Instance.gameObject.SetActive(false);
            _startPosImage = new Vector3(HypercasualEndLvl.Instance.transform.position.x, 
                                         HypercasualEndLvl.Instance.transform.position.y + 320.0f,
                                         HypercasualEndLvl.Instance.transform.position.z);
        }
        
        public void Entry()
        {
            PlayerController player = GameObject.FindObjectOfType<PlayerController>();
            HypercasualEndLvl.Instance.finImage.transform.position = _startPosImage;
            HypercasualEndLvl.Instance.gameObject.SetActive(true);
            HypercasualEndLvl.Instance.SetEndLvlTrigger();
            
            player.Win();
            player.GetInputHandle.SetWin();
        }
        
        public void OnUpdate()
        {

        }
        
        public void Exit()
        {
            HypercasualEndLvl.Instance.finImage.transform.position = _startPosImage + new Vector3(0.0f, 1.0f, 0.0f);
            HypercasualEndLvl.Instance.gameObject.SetActive(false);
            SaveGameManager.Instance.SaveGameProgress();
            GameSceneManager.Instance.onPlayerWinAction.Invoke();
            GameSceneManager.Instance.onLoadSceneAction.Invoke();
        }
    }
}
