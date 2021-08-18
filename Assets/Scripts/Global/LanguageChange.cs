using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class LanguageChange : MonoBehaviour
{

    public UnityEvent OnChangeLanguage = new UnityEvent();

    public static LanguageChange LanguageChanged;

    private void Awake()
    {
        LanguageChanged = this;
    }

    public void Change(TextID textId)
    {

        string language = PlayerPrefs.GetString("Language");

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Application.dataPath + "/Resource/XML/Language.xml");
        XmlElement xRoot = xDoc.DocumentElement;


        foreach (XmlNode childnode in xRoot.ChildNodes) 
        {

            if (childnode.LocalName != language) continue;

            foreach (XmlNode child in childnode)
            {

                if (child.LocalName != textId.Id) continue;

                textId.SetText(child.InnerText);

            }


        }

    }

    public void ChangeLanguage()
    {
        OnChangeLanguage?.Invoke();
    }
}