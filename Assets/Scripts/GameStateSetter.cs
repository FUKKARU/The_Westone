using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameStateSetter
{
    [RuntimeInitializeOnLoadMethod]
    static void RuntimeInitializeOnLoadMethods()
    {
        SetResolutionAndFullScreenMode(); // �𑜓x�ƃt���X�N���[���ɂ��邩�ǂ�����ݒ�
        SetVsyncAndTargetFrameRate(); // Vsync�i�ƃ^�[�Q�b�g�t���[�����[�g�j�̐ݒ�
    }

    #region �ڍ�
    static void SetResolutionAndFullScreenMode()
    {
        Screen.SetResolution(GameStateSO.Entity.ResolutionH, GameStateSO.Entity.ResolutionV, GameStateSO.Entity.IsFullScreen);
    }

    static void SetVsyncAndTargetFrameRate()
    {
        if (GameStateSO.Entity.IsVsyncOn)
        {
            QualitySettings.vSyncCount = 1; // VSync��ON�ɂ���
        }
        else
        {
            QualitySettings.vSyncCount = 0; // VSync��OFF�ɂ���
            Application.targetFrameRate = GameStateSO.Entity.TargetFrameRate; // �^�[�Q�b�g�t���[�����[�g�̐ݒ�
        }
    }
    #endregion
}

// SO�̃o�O�����m
[InitializeOnLoad]
public class AnnounceSOBug
{
    static bool errorShown = false; // �G���[���b�Z�[�W��\���������ǂ����̃t���O

    static AnnounceSOBug()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode && !errorShown)
        {
            // �I������Ă���A�Z�b�g���擾
            Object[] selectedAssets = Selection.objects;

            // �I�����ꂽ�A�Z�b�g���`�F�b�N
            foreach (Object selectedAsset in selectedAssets)
            {
                // �I������Ă���A�Z�b�g�� ScriptableObject �ł��邩���m�F
                if (selectedAsset is ScriptableObject)
                {
                    Debug.LogWarning("<color=yellow>Scriptable Object ��I��������ԂŃQ�[�������s����ƁA�G���[���o��ꍇ������܂��B\r\n����͌���Unity2022�ȍ~�Ŕ������Ă���o�O�ł���A�������m�F�������ł͎��Q�͂���܂���B</color>");
                    Debug.LogWarning("<color=yellow>�Q�l�L���Fhttps://www.create-forever.games/unity2022-3-value-cannot-be-null-_unity_self/</color>");
                    errorShown = true;
                    break;
                }
            }
        }
    }
}