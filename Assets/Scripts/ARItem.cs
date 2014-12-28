using UnityEngine;
using System.Collections;

public class ARItem : MonoBehaviour {

    protected bool alive;

	protected void Start ()
    {
        alive = true;
	}
	
	protected void Update ()
    {
	
	}

    public bool isAlive() { return alive; }
    public virtual bool interact(Actor actor) { return alive; }
}
