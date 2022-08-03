using UnityEngine;

namespace PurpleDrank
{
    public class SaveGameManager : Singleton<SaveGameManager>
    {
        [HideInInspector] public ResourceInfo[] _allRes;
        [SerializeField] private string key;

        private void Awake()
        {
            for(int i=0;i<ResourceManager.Instance.resources.Count;i++)
            {
                var res = ResourceManager.Instance.resources[(ResourceType)i];
                _allRes[i] = res;
            }
        }
        public void SaveGameProgress()
        {
            foreach(var res in _allRes)
                PlayerPrefs.SetInt(res.name + key, res.current);
        }
        public void LoadGameProgress()
        {
            foreach(var res in ResourceManager.Instance.resources.Values)
                res.current = PlayerPrefs.GetInt(res.name + key);
        }
    }
}