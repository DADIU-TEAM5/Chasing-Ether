using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditor.EditorTools;

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
            gametextObj.TextVariations = new List<GameText.TextVariation>();
        }

        _newLocale = (Locale) EditorGUILayout.ObjectField(_newLocale, typeof(Locale), false);
        _newText = EditorGUILayout.TextArea(_newText);

        if (GUILayout.Button("Add locale text")) {
            if (!gametextObj.TextVariations.Any(x => x.Locale == _newLocale) && _newText?.Length > 0) {
                 gametextObj.TextVariations.Add(new GameText.TextVariation { Locale = _newLocale, Text = _newText});
            }
        }

        for (int i = 0; i < gametextObj.TextVariations.Count; i++) {
            GUILayout.Label(gametextObj.TextVariations[i].Locale.name);
            gametextObj.TextVariations[i].Text = EditorGUILayout.TextArea(gametextObj.TextVariations[i].Text);
        }

        EditorUtility.SetDirty(target);
   }
}
