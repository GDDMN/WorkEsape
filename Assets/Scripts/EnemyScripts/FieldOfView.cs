using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public partial class FieldOfView : MonoBehaviour
    {
        [SerializeField] private float viewRadius;
        [Range(0, 360), SerializeField] private float viewAngle;
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private LayerMask obstracleMask;
        [SerializeField] private List<Transform> visiableTargets = new List<Transform>();
        [SerializeField] private float meshResolution;
        [SerializeField] private MeshFilter viewMeshFilter;

        private Mesh viewMesh;

        public Mesh ViewMesh => viewMesh;
        public float ViewAngle => viewAngle;
        public float ViewRadius => viewRadius;

        private void Start()
        {
            viewMesh = new Mesh();
            viewMesh.name = "view mesh";
            viewMeshFilter.mesh = viewMesh;
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
                        GameSceneManager.Instance.SetLoseState();
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

    }
}

