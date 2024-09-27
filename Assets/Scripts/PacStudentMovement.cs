using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tweener tweener;
    private LayerMask wallLayer;  

    void Start()
    {
        tweener = GetComponent<Tweener>();
        if (tweener == null)
        {
            Debug.LogError("Tweener component not found on " + gameObject.name);
        }
        wallLayer = LayerMask.GetMask("wallLayer"); 
    }

    void Update()
    {

        if (tweener == null)
        {
            Debug.LogError("Tweener is null");
            return;
        }
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;

        if (Input.GetKeyDown(KeyCode.W))
        {
            endPos += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            endPos += Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            endPos += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            endPos += Vector3.right;
        }

        if (CanMoveTo(endPos))
        {
            tweener.AddTween(transform, startPos, endPos, 0.5f);
        }
    }

    bool CanMoveTo(Vector3 targetPos)
    {
        return !Physics2D.OverlapCircle(targetPos, 0.1f, wallLayer);
    }
}
