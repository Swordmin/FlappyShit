using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class CoinChangeEvent : UnityEvent<int> {}
public class ResourceViewer : MonoBehaviour
{
    private int _coin;
    public int Coin 
    {
        get { return _coin; }
        set 
        {
            _coin = value;

            OnCoinChange?.Invoke(_coin);
        }
    }

    private int _diamond;
    public int Diamond 
    {
        get { return _diamond; }
        set 
        {
            _diamond = value;
        }
    }

    public CoinChangeEvent OnCoinChange = new CoinChangeEvent();

    public static ResourceViewer ResourceView;

    private void Awake() 
    {
        DontDestroyOnLoad(this);
        ResourceView = this;
    }
}
