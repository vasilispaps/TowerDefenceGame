using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moneytext : MonoBehaviour
{

    public Text moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + Player.Money.ToString();
    }
}