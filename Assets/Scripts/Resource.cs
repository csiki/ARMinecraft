using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Resource : ARItem {

    static List<Texture2D> hitTextures = new List<Texture2D>(11);

    int interactCounter = 0;
    bool interacted = false;
    List<MCItem> loot = null;
    int hitTolerance = 1000; // def
    int prevHitTextIndex = 0;

	void Start ()
    {
        base.Start();

        // fill hitTextures // TODO do elsewhere centraly
        if (hitTextures.Count == 0)
        {
            for (int i = 0; i <= 10; ++i)
            {
                Texture2D tmptex = Resources.Load("HitTextures/hit" + i, typeof(Texture2D)) as Texture2D;
                Debug.Log("TexName " + i + ": " + tmptex.name);
                hitTextures.Add(tmptex);
            }
        }
	}
	
	void Update ()
    {
        base.Update();
        if (interacted) ++interactCounter;
        else interactCounter = 0;
        interacted = false;
        
        // UV map texture TODO --> create function for mapping
        var mesh = transform.GetComponent<MeshFilter>().mesh;
        var UVs = new Vector2[mesh.uv.Length];
        UVs = mesh.uv;

        /// from http://answers.unity3d.com/questions/294165/apply-uv-coordinates-to-unity-cube-by-script.html
        /// texture part order: top, bot, side(1); side2, side3, side4
        /// UV coordinates for vertex coordinates (0,1), (1,1), (0,0), (1,0)
        //    2    3    0    1   Front
        //    6    7   10   11   Back
        //   19   17   16   18   Left
        //   23   21   20   22   Right
        //    4    5    8    9   Top
        //   15   13   12   14   Bottom
        /// Top like:
        //   4 --- 5
        //   |     |
        //   |     |
        //   8 --- 9
        
        // top
        UVs[4] = new Vector2(0, 1f);
        UVs[5] = new Vector2(0.33f, 1);
        UVs[8] = new Vector2(0, 0.5f);
        UVs[9] = new Vector2(0.33f, 0.5f);

        // bot
        UVs[15] = new Vector2(0.33f, 1f);
        UVs[13] = new Vector2(0.66f, 1);
        UVs[12] = new Vector2(0.33f, 0.5f);
        UVs[14] = new Vector2(0.66f, 0.5f);

        // sides
        UVs[2] = UVs[19] = UVs[23] = new Vector2(0.66f, 1f);
        UVs[3] = UVs[17] = UVs[21] = new Vector2(1f, 1f);
        UVs[0] = UVs[16] = UVs[20] = new Vector2(0.66f, 0.5f);
        UVs[1] = UVs[18] = UVs[22] = new Vector2(1f, 0.5f);
        // back
        UVs[6] = new Vector2(0.66f, 0.5f);
        UVs[7] = new Vector2(1f, 0.5f);
        UVs[10] = new Vector2(0.66f, 0f);
        UVs[11] = new Vector2(1f, 0f);

        mesh.uv = UVs;

        // set detail texture
        selectHitTexture();
	}

    public bool interact(Actor actor)
    {
        interacted = true;

        if (interactCounter > hitTolerance)
        {
            alive = false;
            interacted = false;
            interactCounter = 0;
            transform.renderer.enabled = false;
            // TODO add loot to actor
        }

        if (alive) actor.hit();
        return alive;
    }

    public void updateLoot(List<MCItem> loot_)
    {
        loot = loot_;
    }

    protected void selectHitTexture()
    {
        int index = (int)((float)interactCounter / (float)hitTolerance * (float)(hitTextures.Count - 1) + 0.5f);
        if (prevHitTextIndex != index)
        {
            prevHitTextIndex = index;
            renderer.material.SetTexture("_Detail", hitTextures[index]);
        }
    }
}
