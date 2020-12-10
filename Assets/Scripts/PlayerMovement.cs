using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody; //Astronaut RigidBody -> Fester Körper mit Physikalischen verhalten
    public float torque;
    public GameObject oxygen;


    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool rotateLeft;
    private bool rotateRight;
    private bool boost;

    public float energy = 100f;
    public float energy_step = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>(); //Abholen von Astronaut
        rbody.AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f))); // Kraft (in 3D) anwenden um Bewegung zu starten
        rbody.AddRelativeTorque(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f))); // Rotierung
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) // UP
        {
            moveUp = true;
        }
        if (Input.GetKey("s")) // DOWN
        {
            moveDown = true;
        }
        if (Input.GetKey("a")) // LEFT
        {
            moveLeft = true;
        }
        if (Input.GetKey("d")) // RIGHT
        {
            moveRight = true;
        }
        if (Input.GetKey("c")) // ROTATE LEFT
        {
            rotateLeft = true;
        }
        if (Input.GetKey("v")) // ROTATE RIGHT
        {
            rotateRight = true;
        }

    }

    // Called every physics update
    private void FixedUpdate()
    {

        if (moveUp)
        {
            rbody.AddForce(Vector3.up);
            //- Energy steps
            energy -= energy_step;
            ShowNitrogen(energy);
            moveUp = false;
        }
        if (moveDown)
        {
            rbody.AddForce(Vector3.down);
            //- Energy steps
            energy -= energy_step;
            ShowNitrogen(energy);
            moveDown = false;
        }
        if (moveLeft)
        {
            rbody.AddForce(Vector3.left);
            //- Energy steps
            energy -= energy_step;
            ShowNitrogen(energy);
            moveLeft = false;
        }
        if (moveRight)
        {
            rbody.AddForce(Vector3.right);
            //- Energy steps
            energy -= energy_step;
            ShowNitrogen(energy);
            moveRight = false;
        }
        if (rotateLeft)
        {
            rbody.AddRelativeTorque(Vector3.up * 0.1f);
            //- Energy steps
            energy -= energy_step;
            ShowNitrogen(energy);
            rotateLeft = false;
        }
        if (rotateRight)
        {
            rbody.AddRelativeTorque(Vector3.down * 0.1f);
            //- Energy steps
            energy -= energy_step;
            ShowNitrogen(energy);
            rotateRight = false;
        }
    }


    private void ShowNitrogen(float value)
    {
        if (value >= 0)
        {

            oxygen.transform.Find("level.000").gameObject.SetActive(true);
            oxygen.transform.Find("level.001").gameObject.SetActive(true);
            oxygen.transform.Find("level.002").gameObject.SetActive(true);
            oxygen.transform.Find("level.003").gameObject.SetActive(true);
            oxygen.transform.Find("level.004").gameObject.SetActive(true);
            oxygen.transform.Find("level.005").gameObject.SetActive(true);
            oxygen.transform.Find("level.006").gameObject.SetActive(true);
            oxygen.transform.Find("level.007").gameObject.SetActive(true);
            oxygen.transform.Find("level.008").gameObject.SetActive(true);
            oxygen.transform.Find("level.009").gameObject.SetActive(true);

            if (value < 90)
            {
                oxygen.transform.Find("level.009").gameObject.SetActive(false);
                if (value < 80)
                {
                    oxygen.transform.Find("level.008").gameObject.SetActive(false);
                    if (value < 70)
                    {
                        oxygen.transform.Find("level.007").gameObject.SetActive(false);
                        if (value < 60)
                        {
                            oxygen.transform.Find("level.006").gameObject.SetActive(false);
                            if (value < 50)
                            {
                                oxygen.transform.Find("level.005").gameObject.SetActive(false);
                                if (value < 40)
                                {
                                    oxygen.transform.Find("level.004").gameObject.SetActive(false);
                                    if (value < 30)
                                    {
                                        oxygen.transform.Find("level.003").gameObject.SetActive(false);
                                        if (value < 20)
                                        {
                                            oxygen.transform.Find("level.002").gameObject.SetActive(false);
                                            if (value < 10)
                                            {
                                                oxygen.transform.Find("level.001").gameObject.SetActive(false);
                                                if (value < 4)
                                                {
                                                    oxygen.transform.Find("level.000").gameObject.SetActive(false);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

          
            //switch (value)
            //{
            //    case 90:
            //        oxygen.transform.Find("level.009").gameObject.SetActive(false);
            //        break;
            //    case 80:
            //        oxygen.transform.Find("level.008").gameObject.SetActive(false);
            //        break;
            //    case 70:
            //        oxygen.transform.Find("level.007").gameObject.SetActive(false);
            //        break;
            //    case 60:
            //        oxygen.transform.Find("level.006").gameObject.SetActive(false);
            //        break;
            //    case 50:
            //        oxygen.transform.Find("level.005").gameObject.SetActive(false);
            //        break;
            //    case 40:
            //        oxygen.transform.Find("level.004").gameObject.SetActive(false);
            //        break;
            //    case 30:
            //        oxygen.transform.Find("level.003").gameObject.SetActive(false);
            //        break;
            //    case 20:
            //        oxygen.transform.Find("level.002").gameObject.SetActive(false);
            //        break;
            //    case 10:
            //        oxygen.transform.Find("level.001").gameObject.SetActive(false);
            //        break;
            //    case 0:
            //        oxygen.transform.Find("level.000").gameObject.SetActive(false);
            //        break;
            //    case 100:
            //        oxygen.transform.Find("level.000").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.001").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.002").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.003").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.004").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.005").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.006").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.007").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.008").gameObject.SetActive(true);
            //        oxygen.transform.Find("level.009").gameObject.SetActive(true);
            //        break;
            //}
        }
        else {
            // Back to Startmenu
            SceneManager.LoadScene("MainMenu");
        }
    }
}

