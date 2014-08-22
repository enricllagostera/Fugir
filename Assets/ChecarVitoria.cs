using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class ChecarVitoria : MonoBehaviour {

	public float intervalo;
	public float contagem;
	public float restante;
	public bool vitoria;

	void Start () {
		restante = intervalo;
		contagem = 0;
		vitoria = false;
	}

	void Update () {
		contagem += Time.deltaTime;
		restante = intervalo - contagem;
		if (restante <= 0 && !vitoria) {
			print ("abriu");
			vitoria = true;
			MessageKit.post (Eventos.VitoriaFase);
		}
	}
}
