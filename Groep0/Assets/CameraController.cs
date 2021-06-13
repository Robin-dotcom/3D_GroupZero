using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // variables
    public SpelerController speler;
    float cl = 85f;
    float sens = 400f;
    float rotatieV, rotatieH;

    private void Start()
    {
        this.rotatieV = this.transform.localEulerAngles.x;
        this.rotatieH = this.transform.eulerAngles.y;
    }

    private void Update()
    {
        float MVertical = -Input.GetAxis("Mouse Y");
        float MHorizontal = Input.GetAxis("Mouse X");

        this.rotatieV += MVertical * this.sens * Time.deltaTime;
        this.rotatieH += MHorizontal * this.sens * Time.deltaTime;

        this.rotatieV = Mathf.Clamp(this.rotatieV, -this.cl, this.cl);

        this.transform.localRotation = Quaternion.Euler(this.rotatieV, 0f, 0f);
        this.speler.transform.rotation = Quaternion.Euler(0f, this.rotatieH, 0f);
        Debug.DrawRay(this.transform.position, this.transform.forward * 2, Color.white);
    }
}
