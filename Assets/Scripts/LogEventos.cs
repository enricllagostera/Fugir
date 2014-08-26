using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class LogEventos : MonoBehaviour {
	[Range (0.5f, 20f)] public float intervalo;
	private GUIText _msg;
	void Start () {
		_msg = GetComponent<GUIText>();
		MessageKit.addObserver (Eventos.DerrotaFase, Perdeu);
		MessageKit.addObserver (Eventos.CruzouLinha, Cruzou);
		MessageKit.addObserver (Eventos.VitoriaFase, Ganhou);
	}

	void Perdeu () {
		_msg.text = "Perdeu";
		StartCoroutine("LimpaMsg");
	}

	void Cruzou () {
		_msg.text = "Cruzou uma linha";
		StartCoroutine("LimpaMsg");
	}

	void Ganhou () {
		_msg.text = "O portao abriu";
		StartCoroutine("LimpaMsg");
	}

	void OnDestroy () {
		MessageKit.clearMessageTable();
	}

	IEnumerator LimpaMsg () {
		yield return new WaitForSeconds(intervalo);
		_msg.text = "";
	}
}
