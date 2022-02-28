using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace PurpleDrank
{
    public class InputHandle : MonoBehaviour
    {
        Joystick _fixedJoystic;
        Animator _animator;

        GameObject _human;
        GameObject _thing;
        ParticleSystem _explosion;

        

        private Dictionary<Type, IPlayerState> _playerStates;
        public IPlayerState activeState;
        bool stateChange = false;
        bool firstWalk = false;
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
            _fixedJoystic = FindObjectOfType<Joystick>();
            var vPlayerMove = new Vector2(_fixedJoystic.Horizontal, _fixedJoystic.Vertical);
            if (vPlayerMove != Vector2.zero)
            {
                firstWalk = true;
                if (stateChange == true)
                {
                    SetWalk();
                    stateChange = false;
                    
                }
                _animator.SetBool("Walk", true);
            }
            else
            {
                if(stateChange == false & firstWalk == true)
                {
                    SetIdle();
                    stateChange = true;
                }
                
                _animator.SetBool("Walk", false);
            }
            return new Move(vPlayerMove);
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
        ParticleSystem _explosion;
        GameObject _human;
        GameObject _thing;
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
        ParticleSystem _explosion;
        GameObject _human;
        GameObject _thing;
        GameObject player = GameObject.FindObjectOfType<PlayerController>().gameObject;
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
        }
    }
    public class Walk : IPlayerState
    {
        ParticleSystem _explosion;
        GameObject _human;
        GameObject _thing;
 
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
        GameObject player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        public void Entry()
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            player.GetComponent<PlayerController>().animator.SetBool("Walk", false);
            player.GetComponent<PlayerController>().animator.SetTrigger("Win");
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
        GameObject player = GameObject.FindObjectOfType<PlayerController>().gameObject;
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

