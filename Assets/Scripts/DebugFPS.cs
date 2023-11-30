using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugFPS : MonoBehaviour
{
    [SerializeField] private TMP_Text textFPS;

    // Update is called once per frame
    void Update()
    {
        if (textFPS != null) 
        {
            textFPS.text = (1/Time.deltaTime).ToString("0.0");
        }
    }
}
