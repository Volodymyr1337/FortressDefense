using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaleFactor : MonoBehaviour
{
    public float X { get; set; }
    public float Y { get; set; }

    private void Awake()
    {
        Initialization(GetComponent<SpriteRenderer>());
    }

    public void Initialization(SpriteRenderer sr)
    {
        if (sr == null) return;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        X = worldScreenWidth / width;
        Y = worldScreenHeight / height;

        transform.localScale = new Vector3(X, Y, transform.localScale.z);
        transform.position = Vector3.zero;
    }
}
