using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePoses : MonoBehaviour
{
    public GameObject cat;
    public GameObject rabbit;
    public GameObject fox;
    public GameObject bear;
    
    public void startPose1()
    {
        cat.GetComponent<Animation>().Play("catIdle");
        rabbit.GetComponent<Animation>().Play("rabbitIdle");
        fox.GetComponent<Animation>().Play("foxIdle");
        bear.GetComponent<Animation>().Play("bearIdle");
    }

    public void startPose2()
    {
        cat.GetComponent<Animation>().Play("catSit");
        rabbit.GetComponent<Animation>().Play("rabbitDead");
        fox.GetComponent<Animation>().Play("foxSit");
        bear.GetComponent<Animation>().Play("bearSit");
    }

}
