using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBuild : MonoBehaviour
{
    public NavMeshSurface[] navMeshSurfaces;

    public void ClearAndBakeNavMesh()
    {
        NavMesh.RemoveAllNavMeshData();

        navMeshSurfaces = new NavMeshSurface[0];

        navMeshSurfaces = FindObjectsOfType<NavMeshSurface>();

        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }
}
