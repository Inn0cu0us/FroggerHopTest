using UnityEngine;
using System.Collections;

public class DriftMovement : MonoBehaviour {

    public float speed = 0.1f;
    public Vector3 direction = Vector3.right;


    Vector3 movement;
    
    void Awake()
    {
       
    }
	
	void Update () 
    {
        movement = direction * speed * Time.deltaTime;
        transform.position += movement;
	}
}