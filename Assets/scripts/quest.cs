using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quest : MonoBehaviour
{
    static int ghosts;
    public TextMeshPro text;
    public void statsup()
    {
        ghosts += 1;
        text.text = "Убито " + ghosts + "/10 призраков";
        if (ghosts >= 10)
        {
            text.text = "Город спасён от призраков";
        }
    }
}
