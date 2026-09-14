using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

    public float distancia = 5f;
    public float altura = 2f;

    private bool primeiraPessoa = false;

    private PlayerMove playerMove;

    void Start()
    {
       
        playerMove = player.GetComponent<PlayerMove>();
    }

    void LateUpdate()
    {
       
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            primeiraPessoa = !primeiraPessoa;
        }


        if (primeiraPessoa)
        {
            
            transform.position =
                player.position + Vector3.up * 1.6f;

          
            transform.rotation = player.rotation;
        }



        else
        {
            transform.position =
                player.position
                - player.forward * distancia
                + Vector3.up * altura;

            transform.LookAt(
                player.position + Vector3.up * 1f
            );
        }
    }
}