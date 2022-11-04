using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public Click cl;

    public GameObject shopUI;
    public GameObject HellIsGood;
    public GameObject[] describeText;

    public string[] describeList;

    public int autoPlayCost = 100;

    private float HellDisplayTime = 2f;
    private void Start()
    {
        shopUI.SetActive(false);
        HellIsGood.SetActive(false);
        cl = cl.GetComponent<Click>();
    }
    private void Update()
    {
        CheckInHell();
    }
    private void CheckInHell()
    {
        if (HellIsGood.activeSelf == true)
        {
            HellDisplayTime -= Time.deltaTime;
            if (HellDisplayTime < 0)
            {
                HellDisplayTime = 2f;
                HellIsGood.SetActive(false);
            }
        }
    }
    public void BuyAutoPlay()
    {
        if (cl.GetCount() >= autoPlayCost)
        {
            cl.HellJoke(autoPlayCost);
            autoPlayCost *= 2;
            describeText[0].GetComponent<TextMeshProUGUI>().text = 
            describeText[0].GetComponent<TextMeshProUGUI>().text = (describeList[0] + autoPlayCost).Replace("\\n", "\n");
            CloseShop();
            if(cl.canAutoPlay == true){
                cl.AutoPlaySpeedUp();
            }
            cl.canAutoPlay = true;
        }
        else
        {
            HellIsGood.SetActive(true);
        }
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
    public void OpenShop()
    {
        shopUI.SetActive(true);
    }
}
