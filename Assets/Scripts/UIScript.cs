using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text throttleText;
    public Text ssText;
    public Text lzText;
    public Text rdText;
    public Text scoreT;

    public TextMetal tMetal;
    public TexCloth tCloth;
    public TextWood tWood;

    public TransportControl ship;
    public Animator shipAnim;

    public int Score = 0;
    public int Score_Wood = 0;
    public int Score_Metal = 0;
    public int Score_Cloth = 0;

    // Use this for initialization
    void Start () {
		// metal-asteroid, cloth-planet, wood-moon
	}
	
	// Update is called once per frame
	void Update () {
        throttleText.text = "" + (int)(ship.Throttle * 100);

        lzText.text = "";
        AnimatorStateInfo stateInfo = shipAnim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Landed")) {
            ssText.text = "Landed";
            lzText.text = "Press A to Take Off";
        } else if (stateInfo.IsName("Lift Off")) {
            ssText.text = "Take Off";
        } else if (stateInfo.IsName("Airborne")) {
            ssText.text = "Airborne";
            if (ship.GetInLandingZone())
            {
                lzText.text = "Press A to Land";
            }
        }  else if (stateInfo.IsName("Landing")) {
            ssText.text = "Landing";
        }

        rdText.text = "";
        if (ship.landingZoneName != "")
        {
            if(ship.landingZoneName == "asteriod_station_landing_zone")
            {
                if (tMetal.ReturnReqM() > Score_Metal)
                {
                    rdText.text = ""+(tMetal.ReturnReqM() - Score_Metal) + " More Metal Required";
                }
                else
                {
                    rdText.text = "Press X to Sell Metal";
                }
            }
            else if (ship.landingZoneName == "moon_station_landing_zone")
            {
                if (tWood.ReturnReqW() > Score_Wood)
                {
                    rdText.text = "" + (tWood.ReturnReqW() - Score_Wood) + " More Wood Required";
                }
                else
                {
                    rdText.text = "Press X to Sell Wood";
                }
            }
            else if (ship.landingZoneName == "main_Station_Landing_Zone")
            {
                if (tCloth.ReturnReqC() > Score_Cloth)
                {
                    rdText.text = "" + (tCloth.ReturnReqC() - Score_Cloth) + " More Cloth Required";
                }
                else
                {
                    rdText.text = "Press X to Sell Cloth";
                }
            }
        }

        scoreT.text = "Score: " + Score + "\n" + "Wood: "+ Score_Wood + "/20\n" + "Metal: " + Score_Metal + "/20\n" + "Cloth: " + Score_Cloth + "/20";
    }

    public void UpdateScore(int offset)
    {
        Score += offset;
    }

    public void UpdateWood(int offset)
    {
        Score_Wood += offset;
    }

    public void UpdateMetal(int offset)
    {
        Score_Metal += offset;
    }

    public void UpdateCloth(int offset)
    {
        Score_Cloth += offset;
    }

    public int ReturnWood()
    {
        return Score_Wood;
    }

    public int ReturnMetal()
    {
        return Score_Metal;
    }
    public int ReturnCloth()
    {
        return Score_Cloth;
    }
}
