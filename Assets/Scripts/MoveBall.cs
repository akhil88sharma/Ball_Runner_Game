using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    Rigidbody rb;// Start is called before the first frame update
    public int ballspeed;
    public int jumpspeed;
    bool istouching=true;
    public Text Coinstext;
    int counter;
    public AudioClip aclip;
    public AudioSource asource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
        Coinstext.text = "Coins:" + counter;
    }

    // Update is called once per frame
    void Update()
    {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(Hmove, 0.0f, Vmove);
        rb.AddForce(move*ballspeed);
        bool ifjump = Input.GetKey(KeyCode.Space);
       

        if ((ifjump) && (istouching))
        { Vector3 jump = new Vector3(0.0f, 10, 0.0f);
            rb.AddForce(jump*jumpspeed);
            istouching = false;
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        istouching = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cointag"))
        {
            other.gameObject.SetActive(false);
            counter++;
            Coinstext.text = "Coins:" + counter;
            asource.PlayOneShot(aclip);
        }
        if (counter == 18)
        {
            SceneManager.LoadScene("End Scene");
        }
    }
}
