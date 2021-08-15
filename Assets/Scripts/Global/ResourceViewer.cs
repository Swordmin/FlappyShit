using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceViewer 
{

    [SerializeField] private static int _coin;
    [SerializeField] private static int _diamond;

    public static void AddCoin(int coin) 
    {
        if(coin < 0)
        {
            throw new ArgumentException();
        }
        _coin += coin;
    }
    public static void AddDiamond(int diamond)
    {
        if (diamond < 0)
        {
            throw new ArgumentException();
        }
        _diamond += diamond;
    }

    public static void RemoveCoin(int coin) 
    {
        if (coin < 0)
        {
            throw new ArgumentException();
        }
        _coin -= coin;
    }
    public static void RemoveDiamond(int diamond)
    {
        if (diamond < 0)
        {
            throw new ArgumentException();
        }
        _diamond -= diamond;
    }

    public static int GetCoin() => _coin;
    public static int GetDiamond() => _diamond;

}
