using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthColor : MonoBehaviour
{
    [SerializeField] private Image fillColour;

    void Awake()
    {
        fillColour = GetComponent<Image>();
    }
    public void ColourGreen()
    {
        fillColour.color = new Color32(118, 232, 167, 255);
    }
    public void ColourYellow()
    {
        fillColour.color = new Color32(224, 229, 74, 255);
    }
    public void ColourRed()
    {
        fillColour.color = new Color32(158, 69, 55, 255);
    }
}
