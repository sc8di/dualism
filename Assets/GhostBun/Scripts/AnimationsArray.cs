using UnityEngine;

public class AnimationsArray : MonoBehaviour
{

    //При добавлении новых Emotes animation нужно пересоздать AnimatorController через EmeraldSystem -> Animations -> Кнопка снизу
    //На Start and Awake не подключает аниматор
    [SerializeField] Animator _animator;
    //Не позволяем редактирвать из инспектора
    //public string[] AnimationsClipLength;
    [HideInInspector]
    public float[] AnimationsLength;

    public float WorkOnComputerLength { get; private set; }
    public float InteractWithDocumentsLength { get; private set; }
    public float InteractWithPrinterLength { get; private set; }
    public float DocumentsLength { get; private set; }
    public float RingLength { get; private set; }
    public float SitAndWorkOnComputerLength { get; private set; }
    public float TalkingLength { get; private set; }
    public float LookingLength { get; private set; }
    public float TalkingSitLength { get; private set; }

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
                case "WorkOnComputer":
                    WorkOnComputerLength = clip.length;
                    AnimationsLength[0] = WorkOnComputerLength;
                    break;
                case "InteractWithDocuments":
                    InteractWithDocumentsLength = clip.length;
                    //Debug.Log("Talking Ring: " + TalkingRingLength);
                    AnimationsLength[1] = InteractWithDocumentsLength;
                    break;
                case "InteractWithPrinter":
                    InteractWithPrinterLength = clip.length;
                    AnimationsLength[2] = InteractWithPrinterLength;
                    //Debug.Log("Printer: " + WorkWithPrinterLength);
                    break;
                case "Documents":
                    DocumentsLength = clip.length;
                    AnimationsLength[3] = DocumentsLength;
                    break;
                case "Talking Ring":
                    RingLength = clip.length;
                    AnimationsLength[4] = RingLength;
                    break;
                case "SitOnChairWithComputer":
                    SitAndWorkOnComputerLength = clip.length;
                    AnimationsLength[5] = SitAndWorkOnComputerLength;
                    break;
                case "Talking":
                    TalkingLength = clip.length;
                    AnimationsLength[6] = TalkingLength;
                    break;
                case "Looking Around":
                    LookingLength = clip.length;
                    AnimationsLength[7] = LookingLength;
                    break;
                case "Talking Sit":
                    TalkingSitLength = clip.length;
                    AnimationsLength[8] = TalkingSitLength;
                    break;
            }
        }
    }
}
