using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PurpleDrank
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius;
        [Range(0, 360)]
        public float viewAngle;

        public LayerMask targetMask;
        public LayerMask obstracleMask;

        public List<Transform> visiableTargets = new List<Transform>();

        public GameSceneManager gameManager;

        public float meshResolution;

        public MeshFilter viewMeshFilter;
        Mesh viewMesh;
        private void Start()
        {
            viewMesh = new Mesh();
            viewMesh.name = "view mesh";
            viewMeshFilter.mesh = viewMesh;

            gameManager = FindObjectOfType<GameSceneManager>();
        }

        public void DrawFieldOfView()
        {
            int stepCount = (int)(viewAngle * meshResolution);
            float stepAngleSize = viewAngle / stepCount;

            List<Vector3> viewPoints = new List<Vector3>();
            for(int i=0;i<=stepCount;i++)
            {
                float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
                ViewCastInfo newViewCast = ViewCast(angle);
                viewPoints.Add(newViewCast.point);
            }

            int vertexCount = viewPoints.Count + 1;
            Vector3[] vertices = new Vector3[vertexCount];
            int[] triangles = new int[(vertexCount - 2) * 3];

            vertices[0] = Vector3.zero;
            for(int i=0;i<=vertexCount; i++)
            {
                vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
                if(i<vertexCount-2)
                {
                    triangles[i * 3] = 0;
                    triangles[i * 3 + 1] = i + 1;
                    triangles[i * 3 + 2] = i + 2;
                }else
                {
                    break;
                }
            }
            viewMesh.Clear();
            viewMesh.vertices = vertices;
            viewMesh.triangles = triangles;
            viewMesh.RecalculateNormals();
        }
        public void FindVisiableTargets()
        {
            visiableTargets.Clear();
            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
            for(int i=0;i<targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirTarget = (target.position - transform.position).normalized;
                if(Vector3.Angle(transform.forward, dirTarget) < viewAngle/2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirTarget, distanceToTarget, obstracleMask))
                    {
                        visiableTargets.Add(target);
                        gameManager.SetLoseState();
                    }
                }
            }

        }

        ViewCastInfo ViewCast(float globalAngle ){
            Vector3 dir = DirFromAngle(globalAngle, true);
            RaycastHit hit;

            if(Physics.Raycast(transform.position, dir, out hit, viewRadius, obstracleMask))
            {
                return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
            }
            else
            {
                return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
            }
        }
        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if(!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),
                0,
                Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        public struct ViewCastInfo
        {
            public bool hit;
            public Vector3 point;
            public float dst;
            public float angle;

            public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
            {
                hit = _hit;
                point = _point;
                dst = _dst;
                angle = _angle;
            }
        }

    }

    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfViewEditor : Editor
    {
        private void OnSceneGUI()
        {
            FieldOfView fow = (FieldOfView)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fow.transform.position,
                                Vector3.up,
                                Vector3.forward,
                                360,
                                fow.viewRadius);
            Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
            Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);
    
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);
        }
    }
}

