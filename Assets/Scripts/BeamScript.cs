using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// using System.Debug;


public class BeamScript : MonoBehaviour
{

    public UIScript TextScript_;
    public TextWood TextWood_;
    public TextMetal TextMetal_;
    public TexCloth TextCloth_;
    public Animator curAnimation;
    float lenthRay = 200f;
    Vector3 originePos;
    Vector3 dir;
    RaycastHit hitinfo;
    GameObject hitten;
    LineRenderer ray;
    bool isHitting;
    Color beforC;

    private int maxWood = 20;
    private int maxCloth = 20;
    private int maxMetal = 20;


    // Use this for initialization
    void Start()
    {
        ray = GameObject.FindGameObjectWithTag("Ray").GetComponent<LineRenderer>();
        // Score=0;
        // Score_Wood=0;
        // Score_Cloth=0;
        // Score_Metal=0;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Fire1") || OVRInput.Get(OVRInput.Button.Three) || Input.GetKey("v")) && (this.curAnimation.GetCurrentAnimatorStateInfo(0).IsName("Airborne")))
        { // ADD THIS 
            originePos = transform.position;
            ray.enabled = true;
            Color c1 = Color.blue;
            Quaternion rot = transform.rotation;
            dir = transform.right;
            // Debug.DrawRay(originePos, dir, Color.blue);
            Vector3 newpos = transform.position;
           // newpos.y += 1.9f;
            Vector3 newerpos = newpos;
           // newerpos.y += 0.5f;
            ray.SetPosition(0, transform.position + transform.up * 1.9f + transform.right* 3); // ADD THIS
            ray.SetPosition(1, transform.position + transform.up * 2.4f + transform.right* 30);
           
            if (Physics.Raycast(originePos, dir, out hitinfo, lenthRay))
            {
                ray.SetColors(c1, c1);
                hitten = hitinfo.transform.gameObject;
                print(hitinfo.collider.tag);
                if (hitinfo.collider.tag == "Wood_Trigger")
                {
                    // StartCoroutine(HideBall(hitinfo.collider.gameObject));
                    print("Hit");
                    if (TextScript_.ReturnWood() >= TextWood_.ReturnReqW())
                    {
                        TextScript_.UpdateWood(-(TextWood_.ReturnReqW()));
                        TextScript_.UpdateScore(1);
                        TextWood_.NewReqW();
                    }

                    // Score++;

                }

                if (hitinfo.collider.tag == "Metal_Trigger")
                {
                    // StartCoroutine(HideBall(hitinfo.collider.gameObject));
                    print("Hit");
                    if (TextScript_.ReturnMetal() >= TextMetal_.ReturnReqM())
                    {
                        TextScript_.UpdateMetal(-(TextMetal_.ReturnReqM()));
                        TextScript_.UpdateScore(1);
                        TextMetal_.NewReqM();
                    }

                    // Score++;

                }

                if (hitinfo.collider.tag == "Cloth_Trigger")
                {
                    // StartCoroutine(HideBall(hitinfo.collider.gameObject));
                    print("Hit");
                    if (TextScript_.ReturnCloth() >= TextCloth_.ReturnReqC())
                    {
                        TextScript_.UpdateCloth(-(TextCloth_.ReturnReqC()));
                        TextScript_.UpdateScore(1);
                        TextCloth_.NewReqC();
                    }

                    // Score++;

                }
                if (hitinfo.collider.tag == "Crate_Wood" && TextScript_.ReturnWood() < maxWood)
                {
                    // StartCoroutine(HideBall(hitinfo.collider.gameObject));
                    print("Hit Wood");
                    hitten.transform.position = Vector3.MoveTowards(hitten.transform.position, this.transform.position, 1f);
                    if (Vector3.Distance(hitten.transform.position, this.transform.position) < 15)
                    {
                        TextScript_.UpdateWood(1);
                        int x = UnityEngine.Random.Range(-1400, 2709);
                        int y = UnityEngine.Random.Range(-477, 485);
                        int z = UnityEngine.Random.Range(-1611, 593);
                        hitten.transform.position = new Vector3(x, y, z);
                    }
                }
                if (hitinfo.collider.tag == "Crate_Metal" && TextScript_.ReturnMetal() < maxMetal)
                {
                    // StartCoroutine(HideBall(hitinfo.collider.gameObject));
                    print("Hit Metal");
                    hitten.transform.position = Vector3.MoveTowards(hitten.transform.position, this.transform.position, 1f);
                    if (Vector3.Distance(hitten.transform.position, this.transform.position) < 15)
                    {
                        TextScript_.UpdateMetal(1);
                        int x = UnityEngine.Random.Range(-1400, 2709);
                        int y = UnityEngine.Random.Range(-477, 485);
                        int z = UnityEngine.Random.Range(-1611, 593);
                        hitten.transform.position = new Vector3(x, y, z);
                    }


                }
                if (hitinfo.collider.tag == "Crate_Cloth" && TextScript_.ReturnCloth() < maxCloth)
                {
                    // StartCoroutine(HideBall(hitinfo.collider.gameObject));
                    print("Hit Cloth");
                    hitten.transform.position = Vector3.MoveTowards(hitten.transform.position, this.transform.position, 1f);
                    if (Vector3.Distance(hitten.transform.position, this.transform.position) < 15)
                    {
                        TextScript_.UpdateCloth(1);
                        int x = UnityEngine.Random.Range(-1400, 2709);
                        int y = UnityEngine.Random.Range(-477, 485);
                        int z = UnityEngine.Random.Range(-1611, 593);
                        hitten.transform.position = new Vector3(x, y, z);
                    }

                }
            }
            //hitten.transform.GetComponent<MeshRenderer> ().material.color = beforC;
            if (hitten != null)
            {
                print(hitten.name);
            }
        }
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp("v") || OVRInput.GetUp(OVRInput.Button.Three))
        {
            ray.enabled = false;
        }
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(5);
    }

}
