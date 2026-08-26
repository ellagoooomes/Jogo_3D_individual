using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float velocidade = 6f;
    public float forcaPulo = 7f;

    private Rigidbody rb;
    private bool estaNoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            input.y += 1;

        if (Keyboard.current.sKey.isPressed)
            input.y -= 1;

        if (Keyboard.current.dKey.isPressed)
            input.x += 1;

        if (Keyboard.current.aKey.isPressed)
            input.x -= 1;

        Vector3 movimento = new Vector3(input.x, 0, input.y).normalized;

        rb.linearVelocity = new Vector3(
            movimento.x * velocidade,
            rb.linearVelocity.y,
            movimento.z * velocidade
        );

        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            estaNoChao = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }
    }
}