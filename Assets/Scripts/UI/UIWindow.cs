using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PurpleDrank
{
    public class UIWindow : MonoBehaviour
    {
        public Text title;
        public string titleName;

        private void Awake()
        {
            title.text = titleName;
            this.gameObject.SetActive(false);
        }

        public void CloseWindow()
        {
            this.gameObject.SetActive(false);
        }
    }
}

