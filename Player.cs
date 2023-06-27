using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField]
    public float Speed; // Controla velocidade do personagem

    [SerializeField]
    public float JumpForce; // Controla força do pulo

    private Rigidbody2D rig; // Usada para controlar o Rigidbody anexado ao player

    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); // Recebe o Rigidbody do objeto ao qual o script foi atribuído; nesse caso, o player

    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(Speed, rig.velocity.y); // Velocidade sendo passada pelo eixo x para movimento horizontal

         if(Input.GetMouseButtonDown(0) && !isJumping) {
            // GetMouseButtonDown é um método para capturar todas as vezes que o botão esquerdo do mouse é clicado

            Debug.Log("Cliquei :p");
            rig.velocity = new Vector2(rig.velocity.x, JumpForce);
            // Velocidade sendo passada pelo eixo y para movimento vertical

            isJumping = true;

        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.layer == 8) {
            // Confere colisão com layer "ground"
            isJumping = false;
        }
    }
}
