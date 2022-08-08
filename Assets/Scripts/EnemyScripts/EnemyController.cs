using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[SerializeField]
public struct ActivePoint
{
    [SerializeField] public Vector3 position;
    [SerializeField] public int index;
}

namespace PurpleDrank
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Color _pointColors = new Color();
        [SerializeField] private List<Transform> _walkPoints = new List<Transform>();
        [SerializeField] private ActivePoint _activePoint;

        [SerializeField] private Animator _animator;

        private NavMeshAgent _agent;

        public UnityEvent OnLoseGame;

        private void OnDrawGizmos()
        {
            Gizmos.color = _pointColors;
            foreach (var point in _walkPoints)
                Gizmos.DrawSphere(point.position, .3f);
        }

        public void Initiailize()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _activePoint.position = _walkPoints[0].position;
            _activePoint.index = 0;
            _agent.SetDestination(_activePoint.position);
            _animator.SetBool("Walking", false);

            OnLoseGame.AddListener(LoseGame);
        }

        public void SetNewDistantion()
        {
            _animator.SetBool("Walking", true);
            SetActivePoint(_activePoint.index);
            _agent.SetDestination(_activePoint.position);
        }

        private void SetActivePoint(int index)
        {
            if (index == _walkPoints.Count - 1)
                index = 0;
            else
                index++;

            _activePoint.position = _walkPoints[index].position;
            _activePoint.index = index;
        }

        private void LoseGame()
        {
            _animator.SetBool("Walking", false);
            _animator.SetTrigger("LoseGame");
            _agent.isStopped = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<InteractWithEnemy>() == null)
                return;

            other.GetComponent<InteractWithEnemy>().Interact(this);
        }
    }
}

