using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    string animationName = "";

    public void RefreshCollider(string i)
    {
        if (animationName != i)
        {
            animationName = i;
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
        }
    }
}
