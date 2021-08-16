using TMPro;
using UnityEngine;
using System.Xml.Serialization;
public class TextID : MonoBehaviour
{

    [SerializeField] private string _id;
    [SerializeField] private TextMeshProUGUI _text;

    public string Id => _id.ToLower();

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        LanguageChange.Change(this);
        LanguageChange.OnChageLanguage.AddListener(TextUpdate);
    }

    public void SetText(string text)
    {

        _text.text = text;

    }
    private void TextUpdate()
    {
        LanguageChange.Change(this);
    }

}