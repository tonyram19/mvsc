using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{
    public Color[] colors;

    public Color GenerateRandomColor()
    {
        Color color = new Color();

        int random = Random.Range(0, colors.GetLength(0) - 1);
        color = colors[random];

        return color;
    }
}
