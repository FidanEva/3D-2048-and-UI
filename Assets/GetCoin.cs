using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GetCoin : MonoBehaviour
{
   [SerializeField] TMP_Text _coinCount;
    
    void Start()
    {
        
        if (!PlayerPrefs.HasKey("coinCount"))
        {
            PlayerPrefs.SetFloat("coinCount",0);
        }
        else
        {
            _coinCount.text=PlayerPrefs.GetFloat("coinCount").ToString();
        }
    }

    public void GetCoins()
    {
        //textInt = int.Parse(GetComponentInParent<Text>().text);
        float buttonCoin=float.Parse(transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
       float _coinInt= float.Parse(_coinCount.text);
       _coinInt+=buttonCoin;
       _coinCount.text=_coinInt.ToString();
       PlayerPrefs.SetFloat("coinCount",_coinInt);
       //GetComponent<Button>().interactable = false;
    }  
}
