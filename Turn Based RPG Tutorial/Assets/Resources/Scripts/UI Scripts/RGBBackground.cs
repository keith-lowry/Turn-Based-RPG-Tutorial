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
    public float deltaHue;
    public float deltaTime;
    public Color startingColor;

    private UnityEngine.UI.Image image;
    private float nextTime;


    // Start is called before the first frame update
    public void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        image.color = startingColor;
        nextTime = 0f;
    }

    public void Update()
    {
        if (image != null && Time.time >= nextTime)
        {
            // Step 1: Calculate HSV
            Color.RGBToHSV(image.color, out float H, out float S, out float V);

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
            Color newColor = Color.HSVToRGB(H, S,
                V);

            // Step 4: Set Color
            image.color = newColor;
            nextTime += deltaTime;
        }
    }
}
