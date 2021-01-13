using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    public float movementSpeed = 3;

    void Update()
    {
        //rotation
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0, -1 * angle + 180, 0));

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, movementSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= new Vector3(0, 0, movementSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
