using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;

    public void Update()
    {
        //transform.rotation = Quaternion.Euler(0f, camera.transform.rotation.eulerAngles.y, 0f);
        camera.transform.rotation = Quaternion.Euler(camera.transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, 0f);
    }
    void FixedUpdate()
    {
        if (!camera.GetComponent<CameraBehaviour>().isFisrtPerson)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0F, camera.transform.rotation.eulerAngles.y, 0F), 2f * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, camera.transform.rotation.eulerAngles.y, 0f);
        }
    }

}
