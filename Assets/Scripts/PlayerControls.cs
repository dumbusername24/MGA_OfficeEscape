//using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update

    public float movementSpeed = 1000;
    public bool isMoving = false;
    public Animator animator;
    //public Rigidbody rb;


    void Start()
    {
        /* rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; */
    }

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
            isMoving = true;
            transform.position += new Vector3(0, 0, movementSpeed) * Time.deltaTime;
            //rb.MovePosition(transform.position);
            animator.SetBool("WalkOnOff", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            transform.position -= new Vector3(0, 0, movementSpeed) * Time.deltaTime;
            //rb.MovePosition(transform.position);
            animator.SetBool("WalkOnOff", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            transform.position += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
            //rb.MovePosition(transform.position);
            animator.SetBool("WalkOnOff", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            transform.position -= new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
            //rb.MovePosition(transform.position);
            animator.SetBool("WalkOnOff", true);
        }
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)))
        {
            isMoving = false;
            animator.SetBool("WalkOnOff", false);
        }


        //to open the menu
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        }

        
    }

}
