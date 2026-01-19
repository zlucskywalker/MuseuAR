using UnityEngine;

public class GaleriaManager : MonoBehaviour
{
    public GameObject[] listaObras;
    public GameObject painelFinal;
    public QuizManager quizManager;

    private bool[] statusRespostas;
    private int indiceAtual = 0;

    void Start()
    {
        statusRespostas = new bool[listaObras.Length];
        MostrarObra(0);
    }

    void MostrarObra(int index)
    {
        foreach (GameObject obra in listaObras)
        {
            obra.SetActive(false);
        }

        listaObras[index].SetActive(true);
        indiceAtual = index;

        if (quizManager != null)
        {
            quizManager.AtivarPergunta(index);
        }
    }

    public void RegistrarResposta()
    {
        statusRespostas[indiceAtual] = true;
        BuscarProximaPendente();
    }

    public void PularObra()
    {
        statusRespostas[indiceAtual] = false;
        BuscarProximaPendente();
    }

    void BuscarProximaPendente()
    {
        for (int i = 1; i <= listaObras.Length; i++)
        {
            int proximoIndex = (indiceAtual + i) % listaObras.Length;

            if (statusRespostas[proximoIndex] == false)
            {
                MostrarObra(proximoIndex);
                return;
            }
        }

        FinalizarJogo();
    }

    void FinalizarJogo()
    {
        listaObras[indiceAtual].SetActive(false);

        if (quizManager != null)
        {
            quizManager.MostrarTelaFinal();
        }
        else
        {
            if (painelFinal) painelFinal.SetActive(true);
        }
    }
}