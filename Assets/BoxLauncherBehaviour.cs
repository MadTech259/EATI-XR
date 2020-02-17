using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLauncherBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float Xdirection;
    [SerializeField] private float Ydirection;
    [SerializeField] private float Zdirection;
    private float holdTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                holdTime += Time.deltaTime;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                var currentP = Instantiate(projectile, transform.position, transform.rotation);
                Vector3 force = Vector3.forward* 500;
                Debug.Log(transform.forward);

                force.x += Xdirection;
                force.y += Ydirection;
                force.z += Zdirection;
                force *= (holdTime * 50);
                currentP.GetComponent<Rigidbody>().AddForce(force);
                holdTime = 0;

            }

        }

        if (Input.GetButton("Fire1"))
        {
            holdTime += Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            var currentP = Instantiate(projectile, transform.position, transform.rotation);
            Vector3 force =  transform.forward;
            Debug.Log(transform.forward);

            force.x += Xdirection;
            force.y += Ydirection;
            force.z += Zdirection;
            force *= (holdTime * 50);
            currentP.GetComponent<Rigidbody>().AddForce(force);
            holdTime = 0;

        }
    }
}
