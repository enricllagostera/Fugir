using UnityEngine;
using System.Collections;

public class Navegador : MonoBehaviour {

	public float intervalo;

	// Use this for initialization
	void Start () {
		StartCoroutine ("AtualizarGrafo");
	}
	
	// Update is called once per frame
	IEnumerator AtualizarGrafo () {
		while (enabled) {
			AstarPath.active.UpdateGraphs(new Bounds(Vector3.zero, new Vector3(50, 50, 0)));
			yield return new WaitForSeconds (intervalo);
		}
	}
}
