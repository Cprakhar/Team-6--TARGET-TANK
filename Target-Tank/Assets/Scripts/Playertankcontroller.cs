using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertankcontroller : MonoBehaviour
{
    #region Variables
    //Movement
    private float Forwardinput;
    private float Rotationinput;
    public float Forwardspeed;
    public float Rotationspeed;
    public Rigidbody rb;
    public Transform turret;
    public float s_turrent;
    float a_turret;

    //Score
    public float maxscore = 0f;
    float score = 0f;
    public bool haskilled = false;
    
    public int no_of_bullets;

    //Shoot
    public string fire;
    public Transform cannon, head;
    public GameObject Muzzleeffect;
    public GameObject obj;
    public float force = 1000f;
    public float firerate;
    private float nextfirerate = 0f;
    #endregion
    #region Methods
    void FixedUpdate()
    {
        if (turret)
        {
            Rotate_turret();
        }
        Forwardinput = Input.GetAxis("Vertical");
        Rotationinput = Input.GetAxis("Horizontal");
        

        Vector3 currposition = transform.position + (transform.forward * Forwardinput * Forwardspeed * Time.deltaTime);
        rb.MovePosition(currposition);
        Quaternion currrotation = transform.rotation * Quaternion.Euler(Vector3.up * (Rotationspeed * Rotationinput * Time.deltaTime));
        rb.MoveRotation(currrotation);

        score = gameObject.transform.position.z;
        if(score > maxscore)
        {
            maxscore = score;
        }
        FindObjectOfType<Score>().setscore((int)maxscore, haskilled);
        haskilled = false;

        if (Input.GetButton("Fire1") && no_of_bullets > 0 && Time.time >= nextfirerate)
        {

            nextfirerate = Time.time + 1f / firerate;
            GameObject proj = Instantiate(obj, cannon.transform.position, cannon.rotation);
            FindObjectOfType<AudioManager>().Play(fire);
            GameObject effectmuzzle = Instantiate(Muzzleeffect, cannon.transform.position, cannon.rotation);


            Destroy(effectmuzzle, 1f);


            proj.GetComponent<Rigidbody>().AddRelativeForce(obj.transform.forward * force, ForceMode.Impulse);
            no_of_bullets--;
            if (no_of_bullets == 0)
            {
                Exit();
            }
        }

    }
    
    void Rotate_turret()
    {
        a_turret += Input.GetAxis("Mouse X") * s_turrent * -Time.deltaTime;
        a_turret = Mathf.Clamp(a_turret, -60, 60);
        turret.localRotation = Quaternion.AngleAxis(a_turret, Vector3.back);
    }

    void Exit()
    {
        Debug.Log("No Bullets Left");
    }
    #endregion
}
