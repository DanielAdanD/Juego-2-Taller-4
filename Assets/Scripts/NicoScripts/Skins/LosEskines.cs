using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosEskines : MonoBehaviour
{
    public Sprite[] skins;
    public SpriteRenderer sr;
    public ElInt indiceSkin;
    int index;

    public void AplicarSkin()
    {
        index = indiceSkin.value;
        sr.sprite = skins[index];
    }

    private void Update()
    {
        AplicarSkin();
    }
}
