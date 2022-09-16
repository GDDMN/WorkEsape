using System;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class InputHandle
    {
        private Joystick _fixedJoystic;
        private Animator _animator;

        private GameObject _human;
        private GameObject _thing;
        private ParticleSystem _explosion;

        private bool stateChange = false;
        private bool firstWalk = false;
        private Dictionary<Type, IPlayerState> _playerStates;

        [SerializeField] private IPlayerState activeState;

        public InputHandle(Animator animator, GameObject human, GameObject thing, ParticleSystem explosion)
        {
            _animator = animator;
            _human = human;
            _thing = thing;
            _explosion = explosion;
            InitStates();
            SetWait();
        }

        public Command handleInput()
        {
            _fixedJoystic = HypercasualPlaymodeScreen.Instance.GetJoystick();
            Vector2 vPlayerMove = new Vector2(_fixedJoystic.Horizontal, _fixedJoystic.Vertical);

            if (vPlayerMove != Vector2.zero)
                EnterWalkingStatePLayer();
            else
                EnterIdleStatePlayer();

            return new Move(vPlayerMove);
        }

        private void EnterWalkingStatePLayer()
        {
            firstWalk = true;
            if (stateChange == true)
            {
                SetWalk();
                stateChange = false;
            }
            _animator.SetBool("Walk", true);
        }

        private void EnterIdleStatePlayer()
        {
            if (stateChange == false & firstWalk == true)
            {
                SetIdle();
                stateChange = true;
            }
            _animator.SetBool("Walk", false);
        }

        public void InitStates()
        {
            _playerStates = new Dictionary<Type, IPlayerState>();
            _playerStates[typeof(Idle)] = new Idle(_explosion, _human, _thing);
            _playerStates[typeof(Walk)] = new Walk(_explosion, _human, _thing);
            _playerStates[typeof(Wait)] = new Wait(_explosion, _human, _thing);
            _playerStates[typeof(Win)] = new Win();
            _playerStates[typeof(Lose)] = new Lose();

        }

        private void SetState(IPlayerState newState)
        {
            if (activeState != null)
                activeState.Exit();

            this.activeState = newState;
            this.activeState.Entry();
        }

        private T GetPlayerState<T>() where T : IPlayerState
        {
            var type = typeof(T);
            return (T)_playerStates[type];
        }

        public void SetIdle()
        {
            var state = GetPlayerState<Idle>();
            SetState(state);
        }

        public void SetWalk()
        {
            var state = GetPlayerState<Walk>();
            SetState(state);
        }

        public void SetWait()
        {
            var state = GetPlayerState<Wait>();
            SetState(state);
        }

        public void SetWin()
        {
            var state = GetPlayerState<Win>();
            SetState(state);
        }

        public void SetLose()
        {
            var state = GetPlayerState<Lose>();
            SetState(state);
        }
    }

    public interface IPlayerState
    {
        void Entry();
        void OnUpdate();
        void Exit();

    }

    public class Wait : IPlayerState
    {
        private ParticleSystem _explosion;
        private GameObject _human;
        private GameObject _thing;
        public Wait(ParticleSystem explosion, GameObject human, GameObject thing)
        {
            _human = human;
            _thing = thing;
            _explosion = explosion;
        }
        public void Entry()
        {
            _thing.SetActive(false);
            _human.SetActive(true);
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {

        }
    }

    public class Idle: IPlayerState
    {
        private ParticleSystem _explosion;
        private GameObject _human;
        private GameObject _thing;
        private PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        
        public Idle(ParticleSystem explosion, GameObject human, GameObject thing)
        {
            _human = human;
            _thing = thing;
            _explosion = explosion;
        }

        public void Entry()
        {
            _human.SetActive(false);
            _thing.SetActive(true);
            _explosion = GameObject.Instantiate(_explosion, player.transform.position + new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity);
            _explosion.Play();
            player.SetDisappearStatus();
        }

        public void OnUpdate()
        {
            
        }

        public void Exit()
        {
            _thing.SetActive(false);
            _human.SetActive(true);
            _human.transform.position = player.transform.position;
            _explosion = GameObject.Instantiate(_explosion, player.transform.position + new Vector3(0.0f, 1.5f, 0.0f), Quaternion.identity);
            _explosion.Play();

            player.SetActiveStatus();
        }
    }

    public class Walk : IPlayerState
    {
        private ParticleSystem _explosion;
        private GameObject _human;
        private GameObject _thing;
 
        public Walk(ParticleSystem explosion, GameObject human, GameObject thing)
        {
            _human = human;
            _thing = thing;
            _explosion = explosion;
        }
        public void Entry()
        {
            
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {

        }
    }

    public class Win : IPlayerState
    {
        private GameObject player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        
        public void Entry()
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);

        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {

        }
    }

    public class Lose : IPlayerState
    {
        private GameObject player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        
        public void Entry()
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
        public void OnUpdate()
        {

        }
        
        public void Exit()
        {

        }
    }
}

