using UnityEngine;

namespace PurpleDrank
{
    public class LoseState : IGameState
    {
        private PlayerController _player;

        public LoseState()
        {
            if (HypercasualLoose.Instance!= null) HypercasualLoose.Instance.gameObject.SetActive(false);
        }

        public void Entry()
        {
            _player = GameObject.FindObjectOfType<PlayerController>();
            HypercasualLoose.Instance.gameObject.SetActive(true);
            _player.GetInputHandle.SetLose();
        }

        public void OnUpdate()
        {

        }

        public void Exit()
        {
            HypercasualLoose.Instance.gameObject.SetActive(false);
            GameSceneManager.Instance.onLoadSceneAction.Invoke();
        }
    }
}

