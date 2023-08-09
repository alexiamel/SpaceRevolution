using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Corpo para usar fisica no inimigo
    public Rigidbody enemyBody;

    //Variavel para saber a direção que o inimigo esta olhando
    private int direction = 1;

    //Variavel para definir a velocidade do inimigo e o tempo para se virar
    public float enemySpeed, timeToFlip;

    // Start is called before the first frame update
    void Start()
    {
        //Pega o componente rigidbody
        enemyBody = GetComponent<Rigidbody>();
        //Coroutinas são funções para aplicarmos algo a partir de um tempo real em segundos e é assim que nós usamos uma
        StartCoroutine("ChangeDirection");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Passando um vetor no corpo do inimigo para mover ele no eixo X
        enemyBody.velocity = new Vector3(enemySpeed * direction, enemyBody.velocity.y, enemyBody.velocity.z);
    }

    IEnumerator ChangeDirection()
    {
        //Retorno obrigatorio da coroutina passando a variavel do tempo para girar
        yield return new WaitForSeconds(timeToFlip);
        //Inverter a direção
        direction *= -1;
        if (direction == 1)
        {
            //Virar o inimigo
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        if (direction == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
        }
        //Chamar novamente a coroutine para que fique em loop
        StartCoroutine("ChangeDirection");
    }

}