using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpUnlockOrb : MonoBehaviour
{

    [SerializeField] private GameObject point1;
    

    public void OrbAppear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Invoke("MoveOrbToPosition", 0.5f);
    }

    private void MoveOrbToPosition()
    {
        Invoke("OrbExplode", 1f);
    }

    public void OrbExplode()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Explode");
        Invoke("DestroyOrb", 0.333f);
    }

    public void DestroyOrb()
    {
        Destroy(gameObject);    
    }
}
