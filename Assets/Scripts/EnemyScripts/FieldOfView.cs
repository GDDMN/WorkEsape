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
        private void Start()
        {
            gameManager = FindObjectOfType<GameSceneManager>();
        }

        public void DrawFieldOfView()
        {
            int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
            float stepAngleSize = viewAngle / stepCount;
            for(int i=0;i<stepCount;i++)
            {
                float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * 1;
            }
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

