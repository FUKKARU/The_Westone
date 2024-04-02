using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game 
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance = null;

        public float maxScore;
        public float ratioScore;

        public int songID;
        public float noteSpeed;

        public bool Start;
        public float StartTime;

        public int combo;
        public int score;

        public int perfect;
        public int great;
        public int good;
        public int bad;
        public int miss;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

}

