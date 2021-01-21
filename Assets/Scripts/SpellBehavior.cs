using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    private GameObject camera;
    private Vector3 direction;

    void Start()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
        if (camera.GetComponent<CameraBehaviour>().isFisrtPerson)
        {
            direction = camera.transform.forward;
        }
        else
        {
            direction = player.transform.forward;
        }
        transform.rotation = camera.transform.rotation;
        //rb.AddForce(player.transform.right);
        StartCoroutine(DestroySpell());
        
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(direction * 2f * Time.deltaTime, ForceMode.Impulse);
        if (GetComponent<Rigidbody>().useGravity)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0.5f,0) * 2f * Time.deltaTime, ForceMode.Impulse);
        }
        //rb.AddForce(direction * Time.deltaTime, ForceMode.Acceleration);
    }

    private IEnumerator DestroySpell()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
