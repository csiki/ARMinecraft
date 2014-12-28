using UnityEngine;
using System.Collections.Generic;

public enum Dir { FRONT, BACK, RIGHT, LEFT, FRONT_RIGHT, FRONT_LEFT, BACK_RIGHT, BACK_LEFT };

public class MCMap : MonoBehaviour {

    private ARWorld arworld;
    private MCWorld mcworld;
    private Dictionary<Actor, Dictionary<Dir, Stack<ARItem>>> actorSurrounding;
    private Dictionary<Actor, bool> surroundingChange;

	// Use this for initialization
	void Start () {
        arworld = GameObject.FindObjectOfType<ARWorld>();
        mcworld = GameObject.FindObjectOfType<MCWorld>();

        // TODO arbitrary number of actors
        actorSurrounding = new Dictionary<Actor, Dictionary<Dir, Stack<ARItem>>>();
	}
	
	// Update is called once per frame
	void Update () {
	    // FIXME
        var actormarker = GameObject.Find("FrameMarker0/Player");
        var resmarker = GameObject.Find("FrameMarker15/Cube");
        //Debug.Log("ActorCoord: " + actormarker.transform.position + "; Rot: " + actormarker.transform.rotation);
        //Debug.Log("ResCoord: " + resmarker.transform.position + "; Rot: " + resmarker.transform.rotation);
	}
}
