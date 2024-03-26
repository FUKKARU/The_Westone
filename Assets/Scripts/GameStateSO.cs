using UnityEngine;

[CreateAssetMenu(menuName = "SO/GameState", fileName = "GameStateSO")]
public class GameStateSO : ScriptableObject
{
    #region QOL���㏈��
    // �ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "GameStateSO";

    // ����
    private static GameStateSO _entity;
    public static GameStateSO Entity
    {
        get
        {
            // ���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<GameStateSO>(PATH);

                // ���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
    #endregion

    [Header("�𑜓x�i�����j")] public int ResolutionH;
    [Header("�𑜓x�i�c���j")] public int ResolutionV;
    [Header("�t���X�N���[���ɂ��邩")] public bool IsFullScreen;
    [Header("Vsync���I���ɂ��邩")] public bool IsVsyncOn;
    [Header("�iVsync���I�t�̏ꍇ�ɁjUnity���ڕW�Ƃ���FPS")] public int TargetFrameRate;
}
