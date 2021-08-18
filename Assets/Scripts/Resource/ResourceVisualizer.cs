using UnityEngine;
using TMPro;

public class ResourceVisualizer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinText;

    private void Awake()
    {
        ResourceViewer.ResourceView.OnCoinChange.AddListener((count) => 
        {
            _coinText.text = count.ToString();
        });
    }

}
