using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public static class LanguageChange 
{

    public static UnityEvent OnChageLanguage = new UnityEvent();

    public static void Change(TextID textId) //Refactoring this bullshit
    {

        string language = PlayerPrefs.GetString("Language");

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Application.dataPath + "/Resources/XML/Language.xml");
        XmlElement xRoot = xDoc.DocumentElement;


        foreach (XmlNode childnode in xRoot.ChildNodes)
        {

            if (childnode.LocalName == language)
            {

                foreach (XmlNode child in childnode)
                {

                    if (child.LocalName == textId.Id)
                    {
                        textId.SetText(child.InnerText);
                    }

                }

            }

        }

    }

    public static void ChangeLanguage() 
    {
        OnChageLanguage?.Invoke();
    }
}

