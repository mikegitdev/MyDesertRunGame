using UnityEngine;
using System.Collections;

public class BackgroundScaler : MonoBehaviour 
{

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempscale = transform.localScale;

        float width = sr.sprite.bounds.size.x;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        tempscale.x = worldScreenWidth / width;

        transform.localScale = tempscale;

    }

}
