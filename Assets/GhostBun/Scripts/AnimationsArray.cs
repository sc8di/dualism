using UnityEngine;

public class AnimationsArray : MonoBehaviour
{

    //При добавлении новых Emotes animation нужно пересоздать AnimatorController через EmeraldSystem -> Animations -> Кнопка снизу
    //На Start and Awake не подключает аниматор
    [SerializeField] Animator _animator;
    // Не позволяем редактирвать из инспектора
    [HideInInspector]
    public float[] AnimationsLength;

    public float TalkingRingLength { get; private set; }
    public float YellingLength { get; private set; }
    public float WorkWithPrinterLength { get; private set; }
    public float InteractWithDocumentsLength { get; private set; }
    public float SitOnChairLength { get; private set; }
    private void Start()
    {
        GetAnimationLength();

        //for (int i = 0; i < AnimationsLength.Length; i++)
        //{
        //    Debug.Log("Length" + i + ": " + AnimationsLength[i]);
        //}
    }

    // AnimationsLength Заполняем согласно списку анимаций установленых в персонаже(Emarald system -> Animations -> Emotes)
    private void GetAnimationLength()
    {
        AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;

        AnimationsLength = new float[clips.Length];

        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Yelling":
                    YellingLength = clip.length;
                    AnimationsLength[0] = YellingLength;
                    break;
                case "Talking Ring":
                    TalkingRingLength = clip.length;
                    //Debug.Log("Talking Ring: " + TalkingRingLength);
                    AnimationsLength[1] = TalkingRingLength;
                    break;
                case "WorkWithPrinter":
                    WorkWithPrinterLength = clip.length;
                    AnimationsLength[2] = WorkWithPrinterLength;
                    //Debug.Log("Printer: " + WorkWithPrinterLength);
                    break;
                case "InteractWithDocuments":
                    InteractWithDocumentsLength = clip.length;
                    AnimationsLength[3] = InteractWithDocumentsLength;
                    break;
                case "SitOnChair":
                    SitOnChairLength = clip.length;
                    AnimationsLength[4] = SitOnChairLength;
                    break;
            }
        }
    }
}
