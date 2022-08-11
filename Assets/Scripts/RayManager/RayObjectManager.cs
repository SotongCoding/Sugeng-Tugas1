using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayObjectManager
{
    static public void RayObject2D(Vector2 screenPos)
    {
        //make sure you have a camera in the scene tagged as 'MainCamera'
        var hitm = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(screenPos), Vector2.zero);
        if (!hitm) return;
        if (hitm.collider.TryGetComponent<IRayObject>(out var rayObject))
        {
            rayObject.OnHitRayEvent();
        }

    }
}
