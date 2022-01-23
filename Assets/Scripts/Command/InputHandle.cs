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
        public InputHandle(Animator animator, GameObject human, GameObject thing, ParticleSystem explosion)
        {
            _animator = animator;
            _human = human;
            _thing = thing;
            _explosion = explosion;
            InitStates();
        }
        public Command handleInput()
        {
            _fixedJoystic = FindObjectOfType<Joystick>();
            var vPlayerMove = new Vector2(_fixedJoystic.Horizontal, _fixedJoystic.Vertical);
            if (vPlayerMove != Vector2.zero)
            {
                if (stateChange == true)
                {
                    SetWalk();
                    stateChange = false;
                }
                _animator.SetBool("Walk", true);
            }
            else
            {
                if(stateChange == false)
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
    }

    public interface IPlayerState
    {
        void Entry();
        void OnUpdate();
        void Exit();

    }

    public class Wait : MonoBehaviour, IPlayerState
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
            _human.SetActive(true);
            _thing.SetActive(false);
            _explosion.Play();
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {

        }
    }
    public class Idle: MonoBehaviour, IPlayerState
    {
        ParticleSystem _explosion;
        GameObject _human;
        GameObject _thing;
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
            _explosion.Play();
        }
        public void OnUpdate()
        {
            
        }
        public void Exit()
        {
            
        }
    }
    public class Walk : MonoBehaviour, IPlayerState
    {
        ParticleSystem _explosion;
        GameObject _human;
        GameObject _thing;
        GameObject player = FindObjectOfType<PlayerController>().gameObject;
        public Walk(ParticleSystem explosion, GameObject human, GameObject thing)
        {
            _human = human;
            _thing = thing;
            _explosion = explosion;
        }
        public void Entry()
        {
            _human.transform.position = player.transform.position;
            _thing.SetActive(false);
            _human.SetActive(true);
            _explosion.Play();
        }
        public void OnUpdate()
        {

        }
        public void Exit()
        {

        }
    }

}

