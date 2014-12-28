using UnityEngine;
using System.Collections;

public class ActorResourceCollider : MonoBehaviour {

    public Actor actor;

	void Start () {
        actor = GameObject.Find("FrameMarker0/Player").GetComponent<Actor>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER ENTER !: " + other.name);
        actor.frontResource = other.GetComponent<Resource>();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("TRIGGER EXIT !");
        actor.frontResource = null;
    }
}
