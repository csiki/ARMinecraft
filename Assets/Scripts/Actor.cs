using UnityEngine;
using System.Collections;

public class Actor : ARItem {

    public Animator animator;
    public GameObject arcamera;
    public Resource frontResource = null;

	void Start ()
    {
        base.Start();
        animator = GetComponent<Animator>();
        arcamera = GameObject.Find("ARCamera");
	}
	
	void Update ()
    {
        base.Update();

        // idle state
        animator.SetBool("handInteract", false);

        // TODO call front interaction
        if (frontResource != null) frontResource.interact(this);
        else if (Mathf.Abs(arcamera.transform.rotation.y) < 0.3)
            animator.SetTrigger("wave");

	}

    public void hit()
    {
        animator.SetBool("handInteract", true);
    }
}
