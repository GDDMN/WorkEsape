using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace PurpleDrank
{
    public class UIResourceLabel : MonoBehaviour
    {
        [SerializeField] private Text resourceCount;
        [SerializeField] private Image resourceImage;

        [SerializeField] private ResourceManager _resManager;
        [SerializeField] private ResourceType resourceType;

        public UnityEvent OnResourceUpdate;
        public ResourceType GetResourceType() => resourceType;

        private void Awake()
        {
            Initialize();
            OnResourceUpdate.AddListener(UpdateUI);
        }

        private void Initialize()
        {
            resourceCount.text = _resManager.resources[resourceType].current.ToString();
            resourceImage.sprite = _resManager.resources[resourceType].icon;
        }

        private void UpdateUI()
        {
            resourceCount.text = _resManager.resources[resourceType].current.ToString();
        }
    }
}

