using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace game 
{
    [RequireComponent(typeof(AudioSource))]
    public class Judge : MonoBehaviour
    {

        [SerializeField] private GameObject[] MessageObj;
        [SerializeField] NotesManager notesManager;

        [SerializeField] TextMeshProUGUI comboValueText;
        [SerializeField] TextMeshProUGUI scoreValueText;
        [SerializeField] GameObject finishTextObj;

        AudioSource audioSource;
        [SerializeField] AudioClip hitSound;

        float endTime = 0;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            endTime = notesManager.NotesTime[notesManager.NotesTime.Count - 1];
        }
        void Update()
        {
            if (TimeManager.instance.Start)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (notesManager.LaneNum[0] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 0);
                    }
                    else
                    {
                        if (notesManager.LaneNum[1] == 0)
                        {
                            Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 1);
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (notesManager.LaneNum[0] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 0);
                    }
                    else
                    {
                        if (notesManager.LaneNum[1] == 1)
                        {
                            Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 1);
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (notesManager.LaneNum[0] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 0);
                    }
                    else
                    {
                        if (notesManager.LaneNum[1] == 2)
                        {
                            Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 1);
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (notesManager.LaneNum[0] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 0);
                    }
                    else
                    {
                        if (notesManager.LaneNum[1] == 3)
                        {
                            Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + TimeManager.instance.StartTime)), 1);
                        }
                    }
                }

                if (Time.time > endTime + TimeManager.instance.StartTime)
                {
                    finishTextObj.SetActive(true);
                    Invoke("ResultScene", 3f);
                    return;
                }

                if (Time.time > notesManager.NotesTime[0] + 0.2f + TimeManager.instance.StartTime)
                {
                    //miss
                    message(3);
                    deleteData(0);
                    TimeManager.instance.miss++;
                    TimeManager.instance.combo = 0;
                }
            }

        }
        void Judgement(float timeLag, int numOffset)
        {
            audioSource.PlayOneShot(hitSound);
            if (timeLag <= 0.05f)
            {
                //perfect
                message(0);
                TimeManager.instance.ratioScore += 5;
                TimeManager.instance.perfect++;
                TimeManager.instance.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.08f)
                {
                    //great
                    message(1);
                    TimeManager.instance.ratioScore += 3;
                    TimeManager.instance.great++;
                    TimeManager.instance.combo++;
                    deleteData(numOffset);
                }
                else
                {
                    if (timeLag <= 0.10f)
                    {
                        //bad
                        message(2);
                        TimeManager.instance.ratioScore += 1;
                        TimeManager.instance.bad++;
                        TimeManager.instance.combo++;
                        deleteData(numOffset);
                    }
                }
            }
        }
        float GetABS(float num)
        {
            if (num >= 0) return num;
            else return -num;
        }
        void deleteData(int numOffset)
        {
            notesManager.NotesTime.RemoveAt(numOffset);
            notesManager.LaneNum.RemoveAt(numOffset);
            notesManager.NoteType.RemoveAt(numOffset);
            TimeManager.instance.score = (int)Mathf.Round(1000000 * Mathf.Floor(TimeManager.instance.ratioScore / TimeManager.instance.maxScore * 1000000) / 1000000);
            comboValueText.text = TimeManager.instance.combo.ToString();
            scoreValueText.text = TimeManager.instance.score.ToString();
        }

        void message(int judge) { Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0)); }

        void ResultScene() { SceneManager.LoadScene("GameResult"); }
    }
}


