using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[SerializeField]
public struct ActivePoint
{
    [SerializeField] public Vector3 position;
    [SerializeField] public int index;
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Color pointColors = new Color(); 
    [SerializeField] private List<Vector3> _walkPoints = new List<Vector3>();
    [SerializeField] private ActivePoint _activePoint;
    private NavMeshAgent _agent;

    private void OnDrawGizmos()
    {
        Gizmos.color = pointColors;

        foreach (var point in _walkPoints)
            Gizmos.DrawSphere(point, .3f);
    }

    private void Start()
    {
        Initiailize();
    }

    public void Initiailize()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _activePoint.position = _walkPoints[0];
        _activePoint.index = 0;
        _agent.SetDestination(_activePoint.position);
    }

    public void OnUpdate()
    {
        SetNewDistantion();
    }

    private void SetNewDistantion()
    {
        if (gameObject.transform.position.x == _activePoint.position.x &&
            gameObject.transform.position.z == _activePoint.position.z)
        {
            SetActivePoint(_activePoint.index);
            _agent.SetDestination(_activePoint.position);
        }
            
    }

    private void ChangeActivePoint()
    {
        foreach(var point in _walkPoints)
            if (_activePoint.position == point)
                SetActivePoint(_walkPoints.IndexOf(point));
    }

    private void SetActivePoint(int index)
    {
        if(index == _walkPoints.Count-1)
            index = 0;
        else
            index++;

        _activePoint.position = _walkPoints[index];
        _activePoint.index = index;
    }

}
