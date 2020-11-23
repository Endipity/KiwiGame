using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject ThePlayer, TheEgg;
    public float maxDistance = 5f, targetDistance, followSpeed = 0.2f, padding = .6f;
    public RaycastHit Shot;
    public static int eggCount = 0, coinCount = 0;
    bool notPadded = true;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        ThePlayer = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        count = coinCount;
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            targetDistance = Shot.distance;

            if (notPadded && TheEgg.GetComponent<Egg>().pickedUp)
                CreatePadding();

            if (targetDistance >= maxDistance && TheEgg.GetComponent<Egg>().pickedUp)
            {
                followSpeed = 0.4f;
                //Play Animation code
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;
                // play aniamtion code
            }

        }
    }

    void CreatePadding()
    {

        notPadded = false;
        maxDistance = 1f + (eggCount * padding);
        eggCount++;
    }
}
