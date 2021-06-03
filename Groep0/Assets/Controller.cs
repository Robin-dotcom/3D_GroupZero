using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 target;
    float snelheid = 1.1f;

    void Start()
    {
        Target(new Vector3(
            transform.position.x + 10,
            transform.position.y,
            transform.position.z + 10));
    }

    void Update()
    {
     FollowTheMouse();
     Vector3 direction = target - transform.position;
     transform.Translate(direction.normalized * snelheid * Time.deltaTime, Space.World);
    }

    void FollowTheMouse()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitted;
            if (Physics.Raycast(ray.origin, ray.direction, out hitted) == true)
            {
                Target(new Vector3(hitted.point.x, transform.position.y, hitted.point.z));

            }
        }
    }

    void Target(Vector3 newTarget)
    {
        target = newTarget;
        transform.LookAt(target);
    }
}
