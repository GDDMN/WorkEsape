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
        private Vector2 _joystickPos = new Vector2(0.0f, 0.0f);
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
        [SerializeField] private ParticleSystem _emotionParticle;
        [SerializeField] private Transform _emotionParticlePosition;

        public Animator GetAnimator => _animator;
        public PlayerStatus Status => _status;
        public Joystick GetJoystick => _fixedJoystick;
        public InputHandle GetInputHandle => _input;
        
        public void Awake()
        {
            InitializeCameras();
            InitializeJoystick();
            _input = new InputHandle(_animator, _human, _thing, _explosion);
            Player = this.gameObject;
        }

        private void InitializeCameras()
        {
            _cameraPlay.SetActive(true);
            _cameraWin.SetActive(false);
        }

        private void InitializeJoystick()
        {
            _fixedJoystick = Instantiate(_fixedJoystick, _joystickPos, Quaternion.identity);
            _fixedJoystick.transform.SetParent(FindObjectOfType<Canvas>().transform);
            _fixedJoystick.gameObject.SetActive(false);
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
            ChangeCameraView();
            _animator.SetBool("Walk", false);
            _animator.SetTrigger("Win");
        }

        public void Lose()
        {
            ChangeCameraView();
            _animator.SetBool("Walk", false);
            _animator.SetTrigger("Lose");
            var emotionParticle = Instantiate(_emotionParticle, _emotionParticlePosition.position, Quaternion.identity);
        }

        private void ChangeCameraView()
        {
            _cameraPlay.SetActive(false);
            _cameraWin.SetActive(true);

        }
    }

}
