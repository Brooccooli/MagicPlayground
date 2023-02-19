using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    private int targetFrameRate = 70;
 
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
    
    void Update()
    {
        _text.text = "FPS: " + (int) (1f / Time.unscaledDeltaTime);
    }
}
