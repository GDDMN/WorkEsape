using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PurpleDrank
{
    public class HypercasualMainMenu : MonoBehaviour
    {
        public void OpenWindow(UIWindow window)
        {
            window.gameObject.SetActive(true);
        }

        public void CloseMenu()
        {
            this.gameObject.SetActive(false);
        }
    }
}

