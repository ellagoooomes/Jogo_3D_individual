
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float velocidade = 6f;
    public float forcaPulo = 7f;
    public float sensibilidade = 2f;

    private Rigidbody rb;
    private bool estaNoChao;

    private float rotacaoY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Prende o mouse no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Começa olhando na direção atual do personagem
        rotacaoY = transform.eulerAngles.y;
    }

    void Update()
    {
     

        float mouseX = Mouse.current.delta.x.ReadValue();

        // Mouse gira o personagem para os lados
        rotacaoY += mouseX * sensibilidade;

        transform.rotation = Quaternion.Euler(0, rotacaoY, 0);



        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            input.y += 1;

        if (Keyboard.current.sKey.isPressed)
            input.y -= 1;

        if (Keyboard.current.dKey.isPressed)
            input.x += 1;

        if (Keyboard.current.aKey.isPressed)
            input.x -= 1;

     
        Vector3 movimento =
            transform.forward * input.y +
            transform.right * input.x;

        movimento.Normalize();

        rb.linearVelocity = new Vector3(
            movimento.x * velocidade,
            rb.linearVelocity.y,
            movimento.z * velocidade
        );


      

        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaNoChao)
        {
            rb.AddForce(
                Vector3.up * forcaPulo,
                ForceMode.Impulse
            );

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
