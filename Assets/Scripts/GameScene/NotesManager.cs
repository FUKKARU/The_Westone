using System;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    [Serializable]
    public class JsonData
    {
        public string name;
        public int maxBlock;
        public int BPM;
        public int offset;
        public Note[] notes;

    }
    [Serializable]
    public class Note
    {
        public int type;
        public int num;
        public int block;
        public int LPB;
    }

    public class NotesManager : MonoBehaviour
    {
        public int noteNum;
        private string songName;

        public List<int> LaneNum = new List<int>();
        public List<int> NoteType = new List<int>();
        public List<float> NotesTime = new List<float>();
        public List<GameObject> NotesObj = new List<GameObject>();

        private float NotesSpeed;
        [SerializeField] GameObject noteObj;

        void OnEnable()
        {
            //Debug.Log(NotesSpeed);
            //Debug.Log(TimeManager.instance.noteSpeed);
            NotesSpeed = TimeManager.instance.noteSpeed;
            noteNum = 0;
            songName = "2s_441khz16bit";
            Load(songName);
        }

        private void Load(string SongName)
        {
            string inputString = Resources.Load<TextAsset>(SongName).ToString();
            JsonData inputJson = JsonUtility.FromJson<JsonData>(inputString);

            noteNum = inputJson.notes.Length;
            Debug.Log(TimeManager.instance.maxScore);
            TimeManager.instance.maxScore = noteNum * 5;
            for (int i = 0; i < inputJson.notes.Length; i++)
            {
                float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
                float beatSec = kankaku * (float)inputJson.notes[i].LPB;
                float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
                NotesTime.Add(time);
                LaneNum.Add(inputJson.notes[i].block);
                NoteType.Add(inputJson.notes[i].type);

                float z = NotesTime[i] * NotesSpeed;
                NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, 0.55f, z), Quaternion.identity));
            }
        }
    }

}

