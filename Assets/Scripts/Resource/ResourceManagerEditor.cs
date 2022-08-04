//using UnityEngine;
//using UnityEditor;
//using UnityEditor.SceneManagement;

//namespace PurpleDrank
//{
//    [CustomEditor(typeof(ResourceManager))]
//    public class ResourceManagerEditor : Editor
//    {
//        private ResourceManager _resManager;
//        private ResourceType _type;
    
//        public void OnEnable()
//        {
//            _resManager = (ResourceManager)target;
//        }

//        public override void OnInspectorGUI()
//        {
//            if (_resManager.resources.Count > 0)
//            {
//                foreach (var res in _resManager.resources)
//                {
    
//                    GUILayout.BeginVertical("box");
//                    EditorGUILayout.EnumFlagsField("Тип: ", res.Key);
//                    res.Value.current = EditorGUILayout.IntField("Количество: ", res.Value.current);
//                    res.Value.name = EditorGUILayout.TextField("Имя: ", res.Value.name);
//                    res.Value.icon = (Sprite)EditorGUILayout.ObjectField("Иконка: ", res.Value.icon, typeof(Sprite), false);
//                    if (GUILayout.Button("x", GUILayout.Width(15), GUILayout.Height(15)))
//                    {
//                        _resManager.resources.Remove(res.Key);
//                    }
//                    EditorGUILayout.Space(10);
//                    GUILayout.EndVertical();
    
//                }
//            }
    
//            _type = (ResourceType)EditorGUILayout.EnumPopup("Создать обхект типа: ", _type);
    
//            if (GUILayout.Button("Add Resource"))
//            {
    
//                _resManager.AddRes(_type);
//            }
    
//            if (GUI.changed)
//            {
//                SetObjectDirty(_resManager.gameObject);
//            }
//        }
    
//        public static void SetObjectDirty(GameObject a)
//        {
//            EditorUtility.SetDirty(a);
//            EditorSceneManager.MarkSceneDirty(a.scene);
//        }
//    }
//}

