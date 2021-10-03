using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that scrolls an Image's hue
/// through all possible hues.
///
/// Must be attached to a GameObject
/// with an Image.
/// </summary>
public class RGBBackground : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    private float nextTime;
    public float deltaHue;
    public float deltaT;
    public Color startingColor;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        image.color = startingColor;
        nextTime = 0f;
    }

    void Update()
    {
        if (image != null && Time.time >= nextTime)
        {
            Color color = image.color;

            // Step 1: Calculate HSV for RGB
            Color.RGBToHSV(color, out float H, out float S, out float V);

            // Step 2: Cycle through Hue
            if (H == 360)
            {
                H = 0;
            }
            else
            {
                H += deltaHue;
            }

            // Step 3: Calculate RGB for new HSV
            Color newColor = Color.HSVToRGB(H, S, V);

            // Step 4: Set new Color
            image.color = newColor;
            nextTime += deltaT;
        }
    }
}
