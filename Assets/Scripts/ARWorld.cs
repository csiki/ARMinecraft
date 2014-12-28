using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ARWorld : MonoBehaviour {

    public static readonly int markernum = 16;
    public List<Stack<ARItem>> aritems = new List<Stack<ARItem>>(markernum);

	// Use this for initialization
	void Start () {
        // load previous state
        // TODO deserialize last saved aritems list | use fillARitemsDefault()
        
        // create actor
        // TODO aritems.Add( new component Actor) as 0th aritem --> eleve legyen benne Actor, ne autómatikusan generáld és itt csak kérd le GetComponenttel
        
        // create resources
        for (int i = 1; i < markernum; ++i)
        {
            // FIXME
            /*var mt = (MarkerTracker)TrackerManager.Instance.GetTracker<MarkerTracker>();
            var mb = mt.CreateMarker(i, "FrameMarker" + i, 100f);
            mb.transform.position = new Vector3(0, 0, 0);*/

            
            // TODO load 3D objects of stack (aritems[i]) and set as child of 'mb': http://answers.unity3d.com/questions/145299/how-do-you-add-a-child-through-code.html
            // TODO also position the 3D objects
            // resource típusokat hozz létre
        }
	}
	
	// Update is called once per frame
	void Update () {
        // TODO check if any aritem has died or added - check size of stacks only
	}

    private void fillARitemsDefault()
    {
        // TODO
    }
}
