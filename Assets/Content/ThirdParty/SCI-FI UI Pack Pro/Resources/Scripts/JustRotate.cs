using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour {

 
	void Update () {
		transform.Rotate(15f*Vector3.forward*Time.deltaTime);
	}
}
