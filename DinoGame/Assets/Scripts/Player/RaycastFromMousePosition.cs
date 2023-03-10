using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromMousePosition : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            hit.collider.TrigCollider<IClickable>((iClickable) =>
            {
                iClickable.Click();
            });
        }
    }
}
