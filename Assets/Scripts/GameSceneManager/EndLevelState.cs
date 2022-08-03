using UnityEngine;

namespace PurpleDrank
{
    public class EndLevelState : IGameState
    {
        private HypercasualEndLvl _endLvlUI;
        private Vector3 _startPosImage;
        
        public EndLevelState()
        {
            _endLvlUI = GameObject.FindObjectOfType<HypercasualEndLvl>();
            if(_endLvlUI != null)
            {
                _endLvlUI.gameObject.SetActive(false);
                _startPosImage = new Vector3(_endLvlUI.transform.position.x, _endLvlUI.transform.position.y + 320.0f, _endLvlUI.transform.position.z);
            }
        }
        
        public void Entry()
        {
            PlayerController player = GameObject.FindObjectOfType<PlayerController>();
            player.Win();
            player.input.SetWin();
            _endLvlUI.finImage.transform.position = _startPosImage;
            _endLvlUI.gameObject.SetActive(true);
            _endLvlUI.SetEndLvlTrigger();
        }
        
        public void OnUpdate()
        {

        }
        
        public void Exit()
        {
            _endLvlUI.finImage.transform.position = _startPosImage + new Vector3(0.0f, 1.0f, 0.0f);
            _endLvlUI.gameObject.SetActive(false);
            SaveGameManager.Instance.SaveGameProgress();
        }
    }
}
