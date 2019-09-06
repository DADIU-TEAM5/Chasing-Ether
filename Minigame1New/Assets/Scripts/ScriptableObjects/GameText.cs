using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameText : ScriptableObject
{
    public Dictionary<Locale, string> TextVariations;

    public LocaleVariable CurrentLocale; 

    public string GetText() {
        var text = "";

        TextVariations.TryGetValue(CurrentLocale.Value, out text);

        return text;
    }
}
