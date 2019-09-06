using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LocaleManager : ScriptableObject
{
    public Locale[] AvailableLocales;

    public LocaleVariable CurrentLocale;

    public void SetLocale(Locale locale) {
        if (locale != null)
            CurrentLocale.Value = locale;
    }

    public Locale GetLocale() => CurrentLocale.Value;
}
