using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float trackingSpeed = 0f;
    public float mouseDeadzone=0f;
    void Update()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
                
        if (Physics.Raycast (ray, out hit, 500))*/
        if(!mouseWithinDeadzone(mouseDeadzone))
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,3f)),trackingSpeed*Time.deltaTime,0f));

    }

    private bool mouseWithinDeadzone(float deadzone) {
        return Vector2.Distance(Input.mousePosition,new Vector2(Screen.width/2f,Screen.height/2f))<deadzone;
    }
}
