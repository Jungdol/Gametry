using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    [Header("나무 UI")]
    public Image treeImage;

    [Header("나무 이미지")]
    public Sprite[] treeSprites;

    [Header("편지 텍스트")]
    public new Text name;
    public Text sentence;
    public Text guestName;

    string names = "여우님께";
    List <string> sentences;
    List <string> guestNames;

    

    void Start()
    {
        AFewDaysText();
        LetterTexts();
    }

    private void Update()
    {
        treeImage.sprite = treeSprites[GameManager.instance.treeLevel];
    }

    void LetterTexts()
    {
        name.text = names;
        sentence.text = sentences[DataManager.instance.a_Few_Days - 1];
        guestName.text = guestNames[DataManager.instance.a_Few_Days - 1];
    }

    void AFewDaysText()
    {
        sentences = new List<string>();
        guestNames = new List<string>();

        sentences.Add ("저랑 놀아줘서 좋았어여! 같이 언제 만나서 꼭 성게잡으러가여 아저씨! 아, 물론 찔리지 않게 조심하시는게 좋을겁니다..(진지)");
        guestNames.Add("해달이");

        sentences.Add("다시 한번 감사합니다... 많이 힐링했어요.  선생님 생각이 많이 날 거예요. 어쩌면 오늘밤에 많은 생각이 날거 같기도 하네요..꼭 다음에 다시 들를게요. 좋은 밤 보내세요.");
        guestNames.Add("고양이가");

        sentences.Add("감사합니다... 선생님 덕분에  오늘 많이 힐링했네요.  좋은 밤 보내세요.");
        guestNames.Add("To. 토끼");
    }

    public void PlusHappyIndex()
    {
        DataManager.instance.happy_Index += 10;
    }

    public void NextDay()
    {
        if (DataManager.instance.a_Few_Days >= 3)
        {
            LoadingSceneController.LoadScene("CutScene");
        }
        else
        {
            LoadingSceneController.LoadScene("GameScene");
        }
    }
}
