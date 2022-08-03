using UnityEngine;

namespace PurpleDrank
{
    public enum PlayerStatus
    {
        ACTIVE,
        DISAPPEAR
    }

    public class PlayerController : MonoBehaviour
    {
        private GameObject Player;
        private PlayerStatus _status;

        [SerializeField] private Joystick _fixedJoystick;
        [SerializeField] private Animator _animator;

        public GameObject _cameraPlay;
        public GameObject _cameraWin;

        [SerializeField] private GameObject _human;
        [SerializeField] private GameObject _thing;
        [SerializeField] private ParticleSystem _explosion;

        [SerializeField] private InputHandle _input;

        public Animator GetAnimator => _animator;
        public PlayerStatus Status => _status;
        public Joystick GetJoystick => _fixedJoystick;
        public InputHandle GetInputHandle => _input;
        
        public void Awake()
        {
            _cameraPlay.SetActive(true);
            _cameraWin.SetActive(false);
            _input = new InputHandle(_animator, _human, _thing, _explosion);
            _fixedJoystick = Instantiate(_fixedJoystick, _fixedJoystick.transform.position, Quaternion.identity);
            _fixedJoystick.transform.SetParent(FindObjectOfType<Canvas>().transform);
            _fixedJoystick.gameObject.SetActive(false);
            Player = this.gameObject;
        }

        public void SetActiveStatus()
        {
            _status = PlayerStatus.ACTIVE;
        }

        public void SetDisappearStatus()
        {
            _status = PlayerStatus.DISAPPEAR;
        }

        public void PlayerControllerUpdate()
        {
            Command command = _input.handleInput();
            if (command != null)
            {
                command.execute(Player);
            }
        }

        public void Win()
        {
            _cameraPlay.SetActive(false);
            _cameraWin.SetActive(true);
        }
    }

}
