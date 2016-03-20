using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconManager : MonoBehaviour
{
    public Sprite[] icons;

	public Sprite GetRandomIcon()
    {
        Sprite sprite = new Sprite();

        int random = Random.Range(0, icons.GetLength(0));
        sprite = icons[random];

        return sprite;
    }
}
