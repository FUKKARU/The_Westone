using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game 
{
    public class Light : MonoBehaviour
    {
        [SerializeField] float speed = 3;

        [Header("ÉåÅ[ÉìÇÃî‘çÜ")]
        [SerializeField] int laneNum;

        Renderer renderer;
        float alpha = 0;

        void Start() { renderer = GetComponent<Renderer>(); }

        void Update()
        {
            ColorController();
            InputSystem();
            AlphaController();
        }

        void ColorChange()
        {
            alpha = 0.3f;
            renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);
        }
        void ColorController() { if (!(renderer.material.color.a <= 0)) renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha); }
        void InputSystem()
        {
            if (laneNum == 1 && Input.GetKeyDown(KeyCode.A)) ColorChange();
            if (laneNum == 2 && Input.GetKeyDown(KeyCode.S)) ColorChange();
            if (laneNum == 3 && Input.GetKeyDown(KeyCode.D)) ColorChange();
            if (laneNum == 4 && Input.GetKeyDown(KeyCode.F)) ColorChange();
        }
        void AlphaController()
        {
            if (alpha > 0.03f)
            {
                alpha -= speed * Time.deltaTime;
                if (alpha < 0) alpha = 0;
            }
            else alpha = 0;
        }
    }
}

