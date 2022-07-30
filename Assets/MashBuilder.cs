using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class MashBuilder : MonoBehaviour
{
    public void Initialize()
    {
        NavMeshBuilder.BuildNavMesh();
    }
}
