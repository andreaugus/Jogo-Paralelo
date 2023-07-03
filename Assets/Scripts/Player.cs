using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc;
    public GameObject pfTiro;
    private float podeDisparar;
    public float tempoDeDisparo = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Metodo Start de " + this.name);
        veloc = 5.0f;
        transform.position = new Vector3(-7, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * entradaHorizontal * Time.deltaTime * veloc);

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime * veloc);

        if (transform.position.y > 3.0f)
        {
            transform.position = new Vector3(-7, -3, 0);
        }

        if (transform.position.y < -3.0f)
        {
            transform.position = new Vector3(-7, 3, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > podeDisparar)
            {
                Instantiate(pfTiro, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
                podeDisparar = Time.time + tempoDeDisparo;
            }
        }
    }

    public void Disparo()
    {
        if (Time.time > podeDisparar)
        {
            Instantiate(pfTiro, transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);
        }
    }
}
