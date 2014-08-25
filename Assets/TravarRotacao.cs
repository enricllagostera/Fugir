using UnityEngine;
using System.Collections;

public class TravarRotacao : MonoBehaviour {

	public Vector3 direcao;
	
	// Update is called once per frame
	void Update () {
		transform.up = direcao;
	}
}
