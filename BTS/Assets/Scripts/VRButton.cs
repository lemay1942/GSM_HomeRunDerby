using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{
    public Image BackgroundImage;
    public Color NormalColor;
    public Color HighlightColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGazeEnter()
    {
        BackgroundImage.color = HighlightColor;
    }
    public void OnGazeExit()
    {
        BackgroundImage.color = NormalColor;
    }
    public void onClick()
    {
        Debug.Log("Click");
    }
}
