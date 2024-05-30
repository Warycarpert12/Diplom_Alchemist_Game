using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryAlter : MonoBehaviour
{

    public int Coin;
    public TextMeshProUGUI coinCount;
    

    public int gipnoGrib;
    public int muhomorApetitGrib;
    public int pogankaObikGrib;
    public int fireGrib;
    public int strongestGrib;

    public int polan;
    public int boyaresnic;
    public int borhevic;

    public int strongestPotion;
    public TextMeshProUGUI silaPotionCount;
    public int hillPotion;
    public TextMeshProUGUI hillPotionCount;
    public int unbornPotion;
    public TextMeshProUGUI fireAspectPotionCount;
    public int hipnosisPotion;
    public TextMeshProUGUI hipnosisPotionCount;
    public int poisonPotion;
    public TextMeshProUGUI poisonPotionCount;
    public int spidPotion;
    public TextMeshProUGUI spidPotionCount;

    public TextMeshProUGUI gipnoGribCount;
    public TextMeshProUGUI muhomorGribCount;
    public TextMeshProUGUI pogankaGribCount;
    public TextMeshProUGUI fireGribCount;
    public TextMeshProUGUI strongestGribCount;
    public TextMeshProUGUI polanCount;
    public TextMeshProUGUI boyarCount;
    public TextMeshProUGUI borheCount;

    public static InventoryAlter instance;

    public Transform stoneSourceTransform;

    public GameObject Player;
    public GameObject gipnoGribObgect;
    public GameObject muhomorApetitGribObgect;
    public GameObject pogankaObikGribObject;
    public GameObject fireGribObject;
    public GameObject strongestGribObject;
    public GameObject polanObject;
    public GameObject boyaresnicObject;
    public GameObject borhevicObject;

    public void DrawGipnoUI()
    {
        gipnoGribCount.text = gipnoGrib.ToString();
    }
    public void DrawMuhomorUI()
    {
        muhomorGribCount.text = muhomorApetitGrib.ToString();
    }
    public void DrawPogankaUI()
    {
        pogankaGribCount.text = pogankaObikGrib.ToString();
    }
    public void DrawFireUI()
    {
        fireGribCount.text = fireGrib.ToString();
    }
    public void DrawStrongetUI()
    {
        silaPotionCount.text = strongestGrib.ToString();
    }
    public void DrawPolanUI()
    {
        polanCount.text = polan.ToString();
    }
    public void DrawBoyarUI()
    {
        boyarCount.text = boyaresnic.ToString();
    }
    public void DrawBorhevUI()
    {
        borheCount.text = borhevic.ToString();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gipnoGribMetod();
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            muhomorApetitGribMetod();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pogankaObikGribMetod();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            fireGribMetod();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            strongestGribMetod();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            polanMetod();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            boyaresnicMetod();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            borhevicMetod();
        }

    }

    private void gipnoGribMetod()
    {
        if (gipnoGrib > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(gipnoGribObgect);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            gipnoGrib -= 1;
            DrawGipnoUI();
        }
    }
    private void muhomorApetitGribMetod()
    {
        if (muhomorApetitGrib>0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(muhomorApetitGribObgect);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            muhomorApetitGrib -= 1;
           DrawMuhomorUI();
        }
    }
    private void pogankaObikGribMetod()
    {
        if (pogankaObikGrib > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(pogankaObikGribObject);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            pogankaObikGrib -= 1;
           DrawPogankaUI();
        }
    }
    private void fireGribMetod()
    {
        if (fireGrib > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(fireGribObject);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            fireGrib -= 1;
            DrawFireUI();
        }
    }
    private void strongestGribMetod()
    {
        if (strongestGrib > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(strongestGribObject);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            strongestGrib -= 1;
            DrawStrongetUI();
        }
    }
    private void polanMetod()
    {
        if (polan > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(polanObject);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            polan -= 1;
            DrawPolanUI();  
        }
    }
    private void boyaresnicMetod()
    {
        if (boyaresnic > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(boyaresnicObject);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            boyaresnic -= 1;
            DrawBoyarUI();
        }
    }
    private void borhevicMetod()
    {
        if (borhevic > 0)
        {
            Debug.Log("Сработало");
            var spawnedStone = Instantiate(borhevicObject);
            spawnedStone.transform.position = stoneSourceTransform.position;
            spawnedStone.GetComponent<Rigidbody>().AddForce(stoneSourceTransform.forward * 0);
            borhevic -= 1;
            DrawBorhevUI();
        }
    }

    public void DrawSilaPotionUI()
    {
        silaPotionCount.text = strongestPotion.ToString();
    }

    public void DrawSpidPotionUI()
    {
        spidPotionCount.text = spidPotion.ToString();
    }

    public void DrawFirePotionUI()
    {
        fireAspectPotionCount.text = unbornPotion.ToString();
    }

    public void DrawHipnosisPotionUI()
    {
        hipnosisPotionCount.text = hipnosisPotion.ToString();
    }

    public void DrawPoisonPotionUI()
    {
        poisonPotionCount.text = poisonPotion.ToString();
    }

    public void DrawHillPotionUI()
    {
        hillPotionCount.text = hillPotion.ToString();
        Debug.Log("ПРивевт");
    }

    public void DrawCoinUI()
    {
        coinCount.text = Coin.ToString();
    }


}
