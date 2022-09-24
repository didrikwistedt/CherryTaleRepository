using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovementEndScene : MonoBehaviour
{
    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;

    private GameObject nextTarget;

    [SerializeField] public float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        nextTarget = point1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition(nextTarget);
    }

    private void MoveToPosition(GameObject moveToTarget)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.deltaTime);
        if (gameObject.transform.position == moveToTarget.transform.position)
        {
            ChangeTarget();
            gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void ChangeTarget()
    {
        if (nextTarget == point1)
        {
            nextTarget = point2;
        }
        else
        {
            nextTarget = point1;
        }
    }



}


