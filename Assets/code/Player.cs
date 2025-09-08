
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public static int Money;
    public int startMoney = 400;

    public static int Rounds;


    public static int Lives;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;

    }

}