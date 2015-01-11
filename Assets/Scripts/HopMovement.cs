using UnityEngine;
using System.Collections;

public class HopMovement : MonoBehaviour {

    AudioSource hopAudio;

	// Use this for initialization
	void Start () {
        hopAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            hopAudio.Play();
            transform.position = transform.position + Vector3.up;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                hopAudio.Play();
                transform.position = transform.position - Vector3.up;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    hopAudio.Play();
                    transform.position = transform.position + Vector3.right;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        hopAudio.Play();
                        transform.position = transform.position - Vector3.right;
                    }
                }
            } 

        }
	}
}
