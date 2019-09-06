using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameText))]
public class GameTextEditor : Editor
{
    private Locale _newLocale;
    private string _newText;
    
    private string _errorMessage;

    private int _currentChosenLocaleText;

    public override void OnInspectorGUI() {
        
        var gametextObj = (GameText) target;

        if (gametextObj.TextVariations == null) {
            gametextObj.TextVariations = new Dictionary<Locale, string>();
        }

        foreach(var localetext in gametextObj.TextVariations) {
            GUILayout.Label(localetext.Key.name);
            gametextObj.TextVariations[localetext.Key] = EditorGUILayout.TextArea(localetext.Value);
        }


        _newLocale = (Locale) EditorGUILayout.ObjectField(_newLocale, typeof(Locale), true);
        _newText = EditorGUILayout.TextArea(_newText);

        if (GUILayout.Button("Add locale text")) {
            if (!gametextObj.TextVariations.ContainsKey(_newLocale) && _newText?.Length > 0) {
                 gametextObj.TextVariations.Add(_newLocale, _newText);
            }
        }
   }

}
