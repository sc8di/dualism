using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 50f;

    [SerializeField]
    TelekineticEngine telekineticEngine;

    [SerializeField]
    GameObject player;

    [SerializeField]
    NavMeshAgent navMeshAgent;

    [SerializeField]
    LayerMask walkOn;

    [SerializeField]
    float timerToGo = 0.1f;

    float touchTimer = 0;

    private void Start()
    {
        telekineticEngine.SetPlayerAsTarget(player);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchTimer = 0;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //Отключаем телекинез
            telekineticEngine.DisableTelekineticField();
            //Включаем персонажу мозг.
            navMeshAgent.enabled = true;
            if (touchTimer < timerToGo)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100, walkOn))
                {
                    navMeshAgent.destination = hit.point;
                }
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Когда ждем на левую почку крысы
            if (touchTimer < timerToGo)
            {
                //Жопускаем таймер.
                touchTimer += Time.deltaTime;
            }
            else
            {                
                //По окончанию тиканья таймера начинаем включать телекинез
                //Если он не активен в момент после окончания работы таймера, то запускаем его процесс.
                if (!telekineticEngine.TelekineticFieldEnabled())
                {
                    //Кастуем позицию куда поставить телекинез.
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    //Если кастанули по нужному слою, ставим туда телекинез.
                    if (Physics.Raycast(ray, out RaycastHit hit, 100, walkOn))
                    {
                        telekineticEngine.SetLocation(hit.point);
                        telekineticEngine.EnableTelekineticField();
                        //Отключаем мозг персонажа.
                        navMeshAgent.enabled = false;
                    }
                }
                telekineticEngine.AddRotationForce(Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed);
            }
        }
    }
}
