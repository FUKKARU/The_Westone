using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    public class Notes : MonoBehaviour
    {
        [Header("ノーツのスピード")]
        float noteSpeed = 8;

        bool start;

        private void Start()
        {
            noteSpeed = TimeManager.instance.noteSpeed;
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
            }
            if (start)
            {
                transform.position -= transform.forward * noteSpeed * Time.deltaTime;
            }

        }
    }
}

