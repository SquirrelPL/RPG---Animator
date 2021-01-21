using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject alphaSurface;
    public GameObject alphaJoints;
    public bool isFisrtPerson = true;
    public Vector3 fp;
    public Vector3 tp;
    private float mouseSensitivity = 100f;
    float xRotation = 0f;
    int rotation = 0;
    int rotationY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            if (isFisrtPerson)
            {
                isFisrtPerson = false;
            }
            else
            {
                isFisrtPerson = true;
            }
        }


        if (isFisrtPerson)
        {
            alphaSurface.GetComponent<SkinnedMeshRenderer>().enabled = false;
            alphaJoints.GetComponent<SkinnedMeshRenderer>().enabled = false;
            gameObject.transform.position = new Vector3(fp.x + player.transform.position.x, fp.y + player.transform.position.y, fp.z + player.transform.position.z);
            //transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z));
            //transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;

            //xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -70, 70);

            transform.localRotation = Quaternion.Euler(xRotation, gameObject.transform.rotation.eulerAngles.y, 0f);
            //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            gameObject.transform.Rotate(Vector3.up * mouseX);

        }
        else
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            alphaJoints.GetComponent<SkinnedMeshRenderer>().enabled = true;
            alphaSurface.GetComponent<SkinnedMeshRenderer>().enabled = true;
            //Cursor.lockState = CursorLockMode.None;
            
            if (mouseX>0)
                rotation += 1;
            else if(mouseX<0)
                rotation -= 1;
            if (mouseY > 0)
                rotationY += 1;
            else if (mouseY < 0)
                rotationY -= 1;
            transform.position = new Vector3(player.transform.position.x + tp.x, player.transform.position.y + tp.y, player.transform.position.z + tp.z);
            /////////////////transform.RotateAround(player.transform.position, Vector3.up, /*Input.mousePosition.x*/ xRotation * 10f /*/ 20f*/);
            transform.RotateAround(player.transform.position, Vector3.up , /*Input.mousePosition.x*/ rotation*mouseSensitivity/40f  /*/ 20f*/);
            
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z));

        }
    }

    void FixedUpdate()
    {


    }

}
