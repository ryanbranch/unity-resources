using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public GameObject wrGo;
    public Wrapper wr;

    // Start is called before the first frame update
    void Start()
    {
        wrGo = GameObject.Find(Instructions.wrapperGoName);
        wr = wrGo.GetComponent<Wrapper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
