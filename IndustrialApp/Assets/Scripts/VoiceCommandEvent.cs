using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class VoiceCommandEvent : MonoBehaviour {
    /*

    [System.Serializable]
    public class KeywordEventPair
    {
        public string Keyword;
        public UnityEvent EventAction;
    }

    [SerializeField]
    private KeywordEventPair[] KeywordTogglePairs;

    private KeywordActionListener keywordActionListener;

    private void Start()
    {

        var actionPairs = new Dictionary<string, System.Action>();

        foreach (var pair in KeywordTogglePairs)
        {
        actionPairs.Add(pair.Keyword, pair.EventAction.Invoke);
        }
        keywordActionListener = new KeywordActionListener(actionPairs);
    }
    */
}
