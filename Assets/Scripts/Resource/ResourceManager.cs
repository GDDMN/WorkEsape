using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
//using UnityEditor.SceneManagement;

namespace PurpleDrank
{

    public class ResourceManager : MonoBehaviour
    {
        public ResourceItem resources;
        public void AddRes(ResourceType type)
        {
            ResourceInfo _res = new ResourceInfo();
            resources.Add(type, _res);
        }
    }


    //[CustomEditor(typeof(ResourceManager))]
    //public class customeInspector : Editor
    //{
    //    ResourceManager a;
    //    ResourceType type;
    
    //    public void OnEnable()
    //    {
    //        a = (ResourceManager)target;
    //    }
    //    public override void OnInspectorGUI()
    //    {
    //        if (a.resources.Count > 0)
    //        {
    //            foreach (var res in a.resources)
    //            {
    
    //                GUILayout.BeginVertical("box");
    //                EditorGUILayout.EnumFlagsField("Тип: ", res.Key);
    //                res.Value.current = EditorGUILayout.IntField("Количество: ", res.Value.current);
    //                res.Value.name = EditorGUILayout.TextField("Имя: ", res.Value.name);
    //                res.Value.icon = (Sprite)EditorGUILayout.ObjectField("Иконка: ", res.Value.icon, typeof(Sprite), false);
    //                if (GUILayout.Button("x", GUILayout.Width(15), GUILayout.Height(15)))
    //                {
    //                    a.resources.Remove(res.Key);
    //                }
    //                EditorGUILayout.Space(10);
    //                GUILayout.EndVertical();
    
    //            }
    //        }
    
    //        type = (ResourceType)EditorGUILayout.EnumPopup("Создать обхект типа: ", type);
    
    //        if (GUILayout.Button("Add Resource"))
    //        {
    
    //            a.AddRes(type);
    //        }
    
    //        if (GUI.changed)
    //        {
    //            SetObjectDirty(a.gameObject);
    //        }
    //    }
    
    //    public static void SetObjectDirty(GameObject a)
    //    {
    //        EditorUtility.SetDirty(a);
    //        EditorSceneManager.MarkSceneDirty(a.scene);
    //    }
    //}
}

