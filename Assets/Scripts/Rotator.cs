using UnityEngine;
public class Rotator : MonoBehaviour
{
    void Update() { transform.Rotate(0, 15 * Time.deltaTime, 0); } // Gira devagar
}