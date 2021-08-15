using System;
using UnityEngine;
using UnityEngine.Events;

public class CoinChangeEvent : UnityEvent<int> {}
public static class ResourceViewer 
{

    private static int _coin;
    private static int _diamond;
    public static CoinChangeEvent OnCoinChange = new CoinChangeEvent();

    public static void AddCoin(int coin) 
    {
        if(coin < 0)
        {
            throw new ArgumentException();
        }
        _coin += coin;

        OnCoinChange?.Invoke(_coin);
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
        OnCoinChange?.Invoke(_coin);
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
