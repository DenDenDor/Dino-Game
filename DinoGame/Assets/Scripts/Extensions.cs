using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class Extensions
{
    public static void TrigCollider<T>(this Collider2D collider2D, Action<T> action) 
    {
        if (collider2D.TryGetComponent<T>(out T other))
        {
            action?.Invoke(other);
        }
    }
    public static void TrigSimpleCollider<T>(this Collider2D collider2D, Action action) where T : MonoBehaviour
    {
        if (collider2D.GetComponent<T>())
        {
            action?.Invoke();
        }
    }
    public static IEnumerator Fade(this CanvasGroup canvasGroup, float end, float during)
    {
        float start = canvasGroup.alpha;
        float time = 0;
        while (time < during)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, time / during);
            yield return null;
        }
    }
    public static void ChangeStateOfCanvasGroup(this CanvasGroup canvasGroup, bool isTurnedOn)
    {
        if (isTurnedOn == canvasGroup.blocksRaycasts)
        {
            return;
        }
        canvasGroup.alpha = isTurnedOn ? 1 : 0;
        canvasGroup.blocksRaycasts = isTurnedOn;
     //   canvasGroup.interactable = isTurnedOn;
    }
    

}
