using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaks : MonoBehaviour
{
    // Use this for initialization
    void Start ()
    {
		
    }
	
    // Update is called once per frame
    void Update ()
    {

        Collider collider = GetComponent<Collider> ();
        if (Input.GetKey (KeyCode.Space) && canBreak) {
            Debug.Log (collider.material.staticFriction);
            //collider.material.staticFriction = Mathf.Lerp(collider.material.staticFriction, 10, 0.1f * Time.deltaTime);
            collider.material.dynamicFriction = Mathf.Lerp (collider.material.dynamicFriction, 10, 0.1f * Time.deltaTime);

            collider.material = collider.material;

            var emission = GetComponent<ParticleSystem> ().emission;
    
            var rate = emission.rate;
            rate.constantMax = 10 * GetComponentInParent<Rigidbody> ().velocity.magnitude;
            emission.rate = rate;
           
            //collider.enabled = true;
        } else {
            //if (Input.GetKeyUp(KeyCode.Space)) {
            //collider.material.staticFriction = Mathf.Lerp(collider.material.staticFriction, 0, 0.1f * Time.deltaTime);
            collider.material.dynamicFriction = Mathf.Lerp (collider.material.dynamicFriction, 0, 0.5f * Time.deltaTime);
            //collider.enabled = false;
            collider.material = collider.material;

            var emission = GetComponent<ParticleSystem> ().emission;

            var rate = emission.rate;
            rate.constantMax = 0;
            emission.rate = rate;


            //GetComponent<ParticleSystem> ().Stop ();
        }
        //canBreak = false;
           
    }
    private bool canBreak = false;

        void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "level") {
            canBreak = true;
        }
      
        }
    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "level") {
            canBreak = false;
        }

    }
}
