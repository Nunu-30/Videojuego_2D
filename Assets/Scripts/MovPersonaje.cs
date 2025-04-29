using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float multiplicador = 1f;
    public float multiplicadorSalto = 5f;
    private bool puedoSaltar = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-8.1f,0.1f,0);
    }

    // Update is called once per frame
    void Update()
    {
        float movTeclas = Input.GetAxis("Horizontal");//(a -if - b if)
       //float movTeclasY = Input.GetAxis("Vertical");//(a -if - b if)
       //aproximacion 1
          transform.position = new Vector3 (
            transform.position.x + (movTeclas/100),
            transform.position.y,
            transform.position.z );

        float miDeltaTime = Time.deltaTime;
        Debug.Log(Time.deltaTime);

        /*
        transform.Translate (
            movTeclas*(Time.deltaTime*multiplicador),
            0,
            0

        );

        */

        rb.velocity = new Vector2(movTeclas*multiplicador, rb.velocity.y);
       
        // Flip 
        if(movTeclas < 0){
        this.GetComponent<SpriteRenderer>().flipX = true;
        }else if(movTeclas > 0){
        this.GetComponent<SpriteRenderer>().flipX = false;
        }

        // Intento con raycast
        
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if(hit){
            puedoSaltar = true;
            Debug.Log(hit.collider.name);
        }else{
            puedoSaltar = false;
        }
        */

        //Salto
        if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar){
        rb.AddForce(new Vector2(0,multiplicadorSalto),
        ForceMode2D.Impulse
        );
        puedoSaltar = false;
        }

       }

        void OnCollisionEnter2D (){
            puedoSaltar = true;
        
        }

        //Debug.Log(Input.GetAxis("Horizontal")
    
}

