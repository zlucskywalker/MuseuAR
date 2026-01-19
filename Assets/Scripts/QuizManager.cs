using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic; // Necessário para usar HashSet

public class QuizManager : MonoBehaviour
{
    [Header("UI Jogo")]
    public GameObject painelQuiz;
    public Text txtPergunta;
    public Text txtFeedback;
    public Button[] btnsOpcoes; // Apenas 3 botões (A, B, C)
    public Button btnResponder;
    public Button btnPular;

    [Header("UI Final")]
    public GameObject painelFim;     // Painel que aparece quando acaba tudo
    public Text txtResultado;        // Texto "Nota: 7/8"
    public Button btnReiniciar;      // Botão para jogar de novo

    [System.Serializable]
    public class Pergunta
    {
        [TextArea] public string enunciado;
        public string[] alternativas; // 3 opções
        public int correta; // 0, 1 ou 2
    }
    public List<Pergunta> perguntas; // Suas 8 perguntas

    // Variáveis de Controle
    private int indexAtual = 0;
    private int acertos = 0;
    private int selecionado = -1;

    // Memória para saber quais obras já foram respondidas (para não repetir ponto)
    private HashSet<int> obrasRespondidas = new HashSet<int>();

    void Start()
    {
        // Garante que o jogo começa limpo
        if (painelFim) painelFim.SetActive(false);
        painelQuiz.SetActive(false);

        // Configura os cliques dos botões
        btnResponder.onClick.AddListener(Checar);
        if (btnPular) btnPular.onClick.AddListener(Pular);
        if (btnReiniciar) btnReiniciar.onClick.AddListener(ReiniciarJogo);

        for (int i = 0; i < btnsOpcoes.Length; i++)
        {
            int x = i;
            btnsOpcoes[i].onClick.AddListener(() => Selecionar(x));
        }
    }

    // --- CHAMADA PELO VUFORIA ---
    public void AtivarPergunta(int idObra)
    {
        // Se o jogo já acabou ou essa obra já foi respondida, não abre o quiz de novo
        if (painelFim.activeSelf || obrasRespondidas.Contains(idObra)) return;

        indexAtual = idObra;
        painelQuiz.SetActive(true);
        Carregar();
    }

    void Carregar()
    {
        selecionado = -1;
        txtFeedback.text = "";
        btnResponder.interactable = true;

        Pergunta p = perguntas[indexAtual];
        txtPergunta.text = p.enunciado;

        // Reseta botões para branco e coloca os textos
        for (int i = 0; i < btnsOpcoes.Length; i++)
        {
            btnsOpcoes[i].GetComponent<Image>().color = Color.white;
            btnsOpcoes[i].GetComponentInChildren<Text>().text = p.alternativas[i];
        }
    }

    void Selecionar(int i)
    {
        selecionado = i;
        foreach (var b in btnsOpcoes) b.GetComponent<Image>().color = Color.white;
        btnsOpcoes[i].GetComponent<Image>().color = Color.yellow; // Destaca seleção
    }

    void Checar()
    {
        if (selecionado == -1) return; // Não escolheu nada
        btnResponder.interactable = false;

        // Lógica de Acerto/Erro
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

        // Marca esta obra como concluída
        obrasRespondidas.Add(indexAtual);

        StartCoroutine(FecharAposResposta());
    }

    void Pular()
    {
        txtFeedback.text = "PULOU";
        painelQuiz.SetActive(false);
    }

    IEnumerator FecharAposResposta()
    {
        yield return new WaitForSeconds(2.0f); // Espera 2 segundos para ler o feedback
        painelQuiz.SetActive(false);

        // Verifica se já respondeu todas as 8 obras
        VerificarFimDeJogo();
    }

    void VerificarFimDeJogo()
    {
        // Se a quantidade de obras respondidas for igual ao total de perguntas (8)
        if (obrasRespondidas.Count >= perguntas.Count)
        {
            MostrarResultadoFinal();
        }
    }

    void MostrarResultadoFinal()
    {
        painelFim.SetActive(true); // Liga a tela final

        if (acertos > 4)
        {
            txtResultado.text = "Parabéns! Você sabe muito.\nNota Final: " + acertos + "/8";
            txtResultado.color = Color.green;
        }
        else
        {
            txtResultado.text = "Pra ser ruim tem que melhorar muito ainda.\nNota Final: " + acertos + "/8";
            txtResultado.color = Color.white;
        }
    }

    void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}