using UnityEngine;

public class PosicionadorAR : MonoBehaviour
{
    public float distancia = 5f;

    public float altura = -0.5f;

    void Start()
    {
        Transform camera = Camera.main.transform;

        Vector3 posicaoAlvo = camera.position + (camera.forward * distancia);
        posicaoAlvo.y = camera.position.y + altura;
        transform.position = posicaoAlvo;

        Vector3 direcao = camera.position - transform.position;
        direcao.y = 0;
        transform.rotation = Quaternion.LookRotation(direcao);

        transform.Rotate(0, 180, 0);
    }
}