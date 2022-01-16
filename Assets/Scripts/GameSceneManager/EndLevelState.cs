using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class EndLevelState : MonoBehaviour, IGameState
    {
        HypercasualEndLvl _endLvlUI;
        Vector3 _startPosImage;
        public EndLevelState()
        {
            _endLvlUI = FindObjectOfType<HypercasualEndLvl>();
            _startPosImage = new Vector3(_endLvlUI.transform.position.x, _endLvlUI.transform.position.y + 320.0f, _endLvlUI.transform.position.z);
        }
        public void Entry()
        {
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
        }
    }
}
