using UnityEngine.AI;
using UnityEngine;

namespace PurpleDrank
{
    public class MeshBuilder : MonoBehaviour
    {
        public void Initialize() => GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}