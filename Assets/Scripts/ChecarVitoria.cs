using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class ChecarVitoria : MonoBehaviour {

	public int energiaPortao;
	public float intervalo;
	public float contagem;
	public float restante;
	public bool vitoria;
	public GUIText msgTempo;

	void Start () {
		restante = intervalo;
		contagem = 0;
		vitoria = false;
	}

	void Update () {
		contagem += Time.deltaTime;
		//restante = intervalo - contagem;
		restante = Mathf.Max(0, energiaPortao - Linha.contagemCruzamento);
		if (restante <= 0 && !vitoria) {
			print ("abriu");
			vitoria = true;
			MessageKit.post (Eventos.VitoriaFase);
		}
		else {
			msgTempo.text = Mathf.Clamp(restante, 0, 10000).ToString("00.0") + "\nLinhas: " + Linha.contagemCruzamento;
		}
	}
}
