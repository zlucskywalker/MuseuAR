using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [Header("Conexão com a Galeria")]
    public GaleriaManager galeriaManager;

    [Header("UI Jogo")]
    public GameObject painelQuiz;
    public Text txtPergunta;
    public Text txtFeedback;
    public Button[] btnsOpcoes;
    public Button btnResponder;
    public Button btnPular;

    [Header("UI Final")]
    public GameObject painelFim;
    public Text txtResultado;
    public Button btnReiniciar;

    [System.Serializable]
    public class Pergunta
    {
        [TextArea] public string enunciado;
        public string[] alternativas;
        public int correta;
    }
    public List<Pergunta> perguntas;

    private int indexAtual = 0;
    private int acertos = 0;
    private int selecionado = -1;

    void Start()
    {
        if (painelFim) painelFim.SetActive(false);

        btnResponder.onClick.AddListener(Checar);
        if (btnPular) btnPular.onClick.AddListener(Pular);
        if (btnReiniciar) btnReiniciar.onClick.AddListener(ReiniciarJogo);

        for (int i = 0; i < btnsOpcoes.Length; i++)
        {
            int x = i;
            btnsOpcoes[i].onClick.AddListener(() => Selecionar(x));
        }
    }

    public void AtivarPergunta(int idObra)
    {
        indexAtual = idObra;
        painelQuiz.SetActive(true);
        Carregar();
    }

    void Carregar()
    {
        selecionado = -1;
        txtFeedback.text = "";
        btnResponder.interactable = true;

        if (indexAtual < perguntas.Count)
        {
            Pergunta p = perguntas[indexAtual];
            txtPergunta.text = p.enunciado;

            for (int i = 0; i < btnsOpcoes.Length; i++)
            {
                btnsOpcoes[i].GetComponent<Image>().color = Color.white;
                btnsOpcoes[i].GetComponentInChildren<Text>().text = p.alternativas[i];
                btnsOpcoes[i].interactable = true;
            }
        }
    }

    void Selecionar(int i)
    {
        selecionado = i;

        foreach (var b in btnsOpcoes) b.GetComponent<Image>().color = Color.white;
        btnsOpcoes[i].GetComponent<Image>().color = Color.yellow;
    }

    public void Checar()
    {
        if (selecionado == -1)
        {
            txtFeedback.text = "Escolha uma alternativa!";
            txtFeedback.color = Color.yellow;
            return;
        }

        btnResponder.interactable = false;

        if (selecionado == perguntas[indexAtual].correta)
        {
            txtFeedback.text = "ACERTOU!";
            txtFeedback.color = Color.green;
            btnsOpcoes[selecionado].GetComponent<Image>().color = Color.green;
            acertos++;
        }
        else
        {
            txtFeedback.text = "ERROU!";
            txtFeedback.color = Color.red;
            btnsOpcoes[selecionado].GetComponent<Image>().color = Color.red;
        }

        StartCoroutine(AvancarParaProxima(true));
    }

    public void Pular()
    {
        txtFeedback.text = "PULOU - Vamos voltar nela depois!";
        txtFeedback.color = Color.yellow;
        StartCoroutine(AvancarParaProxima(false));
    }

    IEnumerator AvancarParaProxima(bool foiRespondida)
    {
        yield return new WaitForSeconds(1.5f);

        if (galeriaManager != null)
        {
            if (foiRespondida)
                galeriaManager.RegistrarResposta();
            else
                galeriaManager.PularObra();
        }
    }

    public void MostrarTelaFinal()
    {
        painelQuiz.SetActive(false);
        painelFim.SetActive(true);

        if (acertos > 4)
        {
            txtResultado.text = "Parabéns! Mandou bem.\n\nNota Final: " + acertos + "/8";
            txtResultado.color = Color.green;
        }
        else
        {
            txtResultado.text = "Pra ser ruim tem que melhorar muito ainda\n\nNota Final: " + acertos + "/8";
            txtResultado.color = Color.white;
        }
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}