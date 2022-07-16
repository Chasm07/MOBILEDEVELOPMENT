using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{

    public TextMeshProUGUI output;

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            output.text = "";
        }
        if (val == 1)
        {
            output.text = "Get at least one pen";
        }
        if (val == 2)
        {
            output.text = "Finish the game under 40 seconds";
        }
    }
}