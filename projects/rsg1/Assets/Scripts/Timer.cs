using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    public int time;

    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Advance()
    {
        time++;
    }
}
