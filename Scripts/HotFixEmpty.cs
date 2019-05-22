using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XLua;

[Hotfix]
public class HotFixEmpty : MonoBehaviour {

	// Use this for initialization
    [LuaCallCSharp]
	void Start () {
		
	}

    // Update is called once per frame
    [LuaCallCSharp]
    void Update () {
		
	}

    [LuaCallCSharp]
    private void OnTriggerEnter(Collider other)
    {
        
    }

    [LuaCallCSharp]
    private void BehaviourMethod()
    {

    }
}
