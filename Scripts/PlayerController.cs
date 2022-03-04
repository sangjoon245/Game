using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;
    public Transform shootOrigin;
    public GameObject projectile;
    public GameObject shadow;
    private GameObject currentshadow;

    private float timeBtwShots;
    public float startTimeBtwShots = 0.8f;

    private float timeBtwA1 = 0;
    public float startTimeBtwA1 = 10f;
    private float timeBtwA2 = 0;
    public float startTimeBtwA2 = 4f;
    private bool shadowOut = false;

    private float timeBtwVoices;
    private float startTimeBtwVoices = 18f;

    public CD2 shootcd;
    public CD a1cd;
    
    private void Awake()
    {
        timeBtwVoices = startTimeBtwVoices + Random.Range(-5f, 20f);
    }
    


    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.y = mousePosition.y - 1.5f;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            float angle = Vector3.Angle(Vector3.up, mousePosition);
            float rotZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.Euler(0f, 0f, (rotZ - 90f));
            ClientSend.PlayerShoot(q);
            
            if (timeBtwShots <= 0)
            {
                shootcd.setCD(startTimeBtwShots);
                timeBtwShots = startTimeBtwShots;
                if (shadowOut == false)
                {
                    SoundManagerScript.PlaySound("Knife2");
                }
                else
                {
                    SoundManagerScript.PlaySound("Knife1");
                }
            }


        }

        if (Input.GetKey(KeyCode.Mouse1))
        {

            mousePosition.x = Mathf.Clamp((mousePosition.x), -6f, 6f);
            mousePosition.y = Mathf.Clamp((mousePosition.y), -4f, 4f);
            camTransform.position = new Vector3(transform.position.x + mousePosition.x/2, transform.position.y + mousePosition.y/2, transform.position.z - 10f);
            Debug.Log(camTransform.position);
            Debug.Log(mousePosition.x + ", " + mousePosition.y);
            Debug.Log(transform.position);

        } else
        {
            camTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10f);
        }

        if(timeBtwVoices <= 0)
        {

            int voice_number = (int) Random.Range(1f, 9f);
            if(voice_number == 1)
            {
                SoundManagerScript.PlaySound("Voice1");
            }
            if (voice_number == 2)
            {
                SoundManagerScript.PlaySound("Voice2");
            }
            if (voice_number == 3)
            {
                SoundManagerScript.PlaySound("Voice3");
            }
            if (voice_number == 4)
            {
                SoundManagerScript.PlaySound("Voice4");
            }
            if (voice_number == 5)
            {
                SoundManagerScript.PlaySound("Voice5");
            }
            if (voice_number == 6)
            {
                SoundManagerScript.PlaySound("Voice6");
            }
            if (voice_number == 7)
            {
                SoundManagerScript.PlaySound("Voice7");
            }
            if (voice_number == 8)
            {
                SoundManagerScript.PlaySound("Voice8");
            }

            timeBtwVoices = startTimeBtwVoices + Random.Range(-5f, 20f);
        }

        SendInputToServer();
    }

    private void FixedUpdate()
    {

        timeBtwShots -= Time.deltaTime;
        timeBtwA1 -= Time.deltaTime;
        timeBtwVoices -= Time.deltaTime;
    }

    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
        };


        bool _input2 = Input.GetKeyDown("space");
        bool _input3 = Input.GetKeyDown(KeyCode.LeftShift);
        bool _input4 = Input.GetKeyDown(KeyCode.C);


        ClientSend.PlayerJump((_input2));
        ClientSend.PlayerMovement(_inputs);

        if (_input3 && timeBtwA1 <= 0) //THE SHADOW ATTACK
        {
            if(shadowOut == false) //DASH and throw out shadow
            {
                ClientSend.PlayerA1(_input3, false);
                shadowOut = true;
                timeBtwShots = 0;
            } 
            else
            if(shadowOut == true) //TP BACK TO SHADOW
            {
                ClientSend.PlayerA1(_input3, true);
                a1cd.setCD(startTimeBtwA1);
                timeBtwA1 = startTimeBtwA1;
                shadowOut = false;
                Invoke("DestroyShadow", 2f);
            }

        }

        if (_input4) //THE SLASH
        {
            ClientSend.PlayerA2(_input4);
            timeBtwShots = 0;
            timeBtwA2 = startTimeBtwA2;
        }

    }



    private void DestroyShadow()
    {
        Destroy(currentshadow);
    }

}