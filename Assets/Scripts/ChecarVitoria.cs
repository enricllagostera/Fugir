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

	void Awake () {
		restante = intervalo;
		contagem = 0;
		vitoria = false;
		Linha.contagemCruzamento = 0;
		Linha.totalCruzamento = energiaPortao;
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
			msgTempo.text = "Linhas faltando: " + 
				Mathf.Clamp(restante, 0, 10000).ToString("00.0") + 
				"\nLinhas: " + Linha.contagemCruzamento;
		}
	}
}
