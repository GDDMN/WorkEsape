using UnityEngine;
using UnityEngine.Events;

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
        private bool _startEmoWasShowed = false;

        [SerializeField] private Transform _cameraPlayStartPos; 
        [SerializeField] private Joystick _fixedJoystick;
        [SerializeField] private Animator _animator;

        public GameObject _cameraPlay;
        public GameObject _cameraWin;
        public GameObject _cameraMenu;

        [SerializeField] private GameObject _human;
        [SerializeField] private GameObject _thing;
        [SerializeField] private ParticleSystem _explosion;

        [SerializeField] private InputHandle _input;
        [SerializeField] private ParticleSystem _emotionParticle;
        [SerializeField] private Transform _emotionParticlePosition;

        [SerializeField] private ParticleSystem _bloodPuddle;


        public UnityEvent OnLvlStart;

        public ParticleSystem Puddle => _bloodPuddle;
        public Animator GetAnimator => _animator;
        public PlayerStatus Status => _status;
        public Joystick Joystick { get; set; } 
        public InputHandle GetInputHandle => _input;
        
        public void Awake()
        {
            InitializeJoystick();

            OnLvlStart.AddListener(ActivateGameCamera);
            InitializeCameras();
            _input = new InputHandle(_animator, _human, _thing, _explosion);
            Player = this.gameObject;
        }

        private void InitializeCameras()
        {
            _cameraMenu.SetActive(true);
            _cameraPlay.SetActive(false);
            _cameraWin.SetActive(false);
        }

        private void InitializeJoystick()
        {
            _fixedJoystick = HypercasualPlaymodeScreen.Instance.GetJoystick();
        }

        public void SetActiveStatus()
        {
            _animator.SetBool("Start", true); 
            _animator.SetBool("Walk", true);
            _status = PlayerStatus.ACTIVE;
        }

        private void ActivateGameCamera()
        {
            _cameraPlay.transform.position = new Vector3(0.0f, _cameraPlay.transform.position.y,
                                                    _cameraPlay.transform.position.z);

            _cameraPlay.SetActive(true);
            _cameraMenu.SetActive(false);
            _cameraWin.SetActive(false);

            _animator.SetBool("Start", true);
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
            _cameraWin.SetActive(true);
            _cameraPlay.SetActive(false);
            _cameraMenu.SetActive(false);
        }
    }

}
