using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyButton
{
    public class ButtonManager : MonoBehaviour
    {
        public static void UI_On(GameObject ui)
        {
            ui.SetActive(true);
        }
        public static void UI_Off(GameObject ui)
        {
            ui.SetActive(false);
        }
    }
}
