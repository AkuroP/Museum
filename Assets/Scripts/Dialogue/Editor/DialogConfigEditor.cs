using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static DialogConfig;

//Custom editor de dialog config
/*[CustomEditor(typeof(DialogConfig))]
[CanEditMultipleObjects]
public class DialogConfigEditor : Editor
{
    private DialogConfig _source;

    private GUIStyle _titleStyle;


    private void OnEnable()
    {
        _source = target as DialogConfig;
    }
    
    #region INSPECTOR
    public override void OnInspectorGUI()
    {
        InitStyle(GUI.skin.label, TextAnchor.MiddleCenter, FontStyle.Bold);
        
        DrawSpeakersDatabasePanel();

        EditorGUILayout.Space();
        EditorGUI.BeginDisabledGroup(_source.speakerDatabase.Count == 0 || _source.speakerDatabase.Exists(x => x == null));
        DrawSpeakersPanel();


    }
    
    private void DrawSpeakersDatabasePanel()
    {
        EditorGUILayout.BeginVertical("box");

        DrawHeader();
        DrawBody();
        DrawFooter();

        EditorGUILayout.EndVertical();

        void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Speakers Database", _titleStyle);
            if (GUILayout.Button(new GUIContent("X", "Clear all Database"), GUILayout.Width(30)))
            {
                if (EditorUtility.DisplayDialog("Delete all database", "Do you want delete all speakers database?", "Yes", "No"))
                    _source.speakerDatabase.Clear();
            }

            EditorGUILayout.EndHorizontal();
        }
        void DrawBody()
        {
            if (_source.speakerDatabase.Count != 0)
            {
                for (int i = 0; i < _source.speakerDatabase.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    _source.speakerDatabase[i] = EditorGUILayout.ObjectField(_source.speakerDatabase[i], typeof(SpeakerDatabase), false) as SpeakerDatabase ;

                    if (GUILayout.Button(new GUIContent("X", "Remove database"), GUILayout.Width(30)))
                    {
                        _source.speakerDatabase.RemoveAt(i);
                        break;
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }
        }
        void DrawFooter()
        {
            if (GUILayout.Button(new GUIContent("Add new database", "")))
            {
                _source.speakerDatabase.Add(null);
            }
        }
    }

    private void DrawSpeakersPanel()
    {
        EditorGUILayout.BeginVertical("box");
        
            DrawHeader();
            DrawBody();
            DrawFooter();

        EditorGUILayout.EndVertical();

        void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Speaker", _titleStyle);
            if(GUILayout.Button(new GUIContent("X", "Clear All Speakers"), GUILayout.Width(30)))
            {
                if(EditorUtility.DisplayDialog("Delete All Speakers", "Do you want to delete all speakers ?", "Yes", "No"))
                    _source.speakers.Clear();
            }

            EditorGUILayout.EndHorizontal();

        }

        void DrawBody()
        {
            if(_source.speakers.Count != 0)
            {
                for(int i = 0; i < _source.speakers.Count; i++)
                {
                    //nouvelle valeur config
                    SpeakerConfig config = _source.speakers[i];

                    EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.Popup(0, new string[]{"0", "1"});
                    
                    config.SetPosition((SpeakerConfig.POSITION)EditorGUILayout.EnumPopup(config.position));
                    //equivalent : config.position = (SpeakerConfig.POSITION)EditorGUILayout.EnumPopup(config.position);
                    
                    if(GUILayout.Button(new GUIContent("X", "Remove Speaker"), GUILayout.Width(30)))
                    {
                        Debug.Log($"Removed {_source.speakers[i].speakerData.label}");
                        _source.speakers.RemoveAt(i);
                        break;
                    }
                    
                    _source.speakers[i] = config;
                    EditorGUILayout.EndHorizontal();
                }
            }
        }

        void DrawFooter()
        {
            if(GUILayout.Button(new GUIContent("Add new Speaker", "")))
            {
                _source.speakers.Add(new DialogConfig.SpeakerConfig());

            }
        }

    }

    #endregion

    #region STYLE
    private void InitStyle(GUIStyle style, TextAnchor textAnchor, FontStyle fontStyle)
    {
        _titleStyle = style;
        _titleStyle.alignment = textAnchor;
        _titleStyle.fontStyle = fontStyle;
    }
    #endregion
}*/
