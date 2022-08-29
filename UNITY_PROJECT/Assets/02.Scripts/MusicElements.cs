using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicElements : MonoBehaviour
{
    [Header("[Scripts]")]
    GameManager _GameManager;

    GameObject selectedElement;

    public void Select()
    {
        GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject; // ��� Ŭ���� ���� ������Ʈ�� �����ͼ� ����
        selectedElement = currentSelectedGameObject;
        print($"������ ������ �̸� : {selectedElement.name}"); // ��� Ŭ���� ���� ������Ʈ�� �̸� ���
        print($"�ٹ� �̹��� : {selectedElement.transform.GetChild(0)}");
        print($"Ÿ��Ʋ : {selectedElement.transform.GetChild(1)}");
        print($"�÷��� Ÿ�� : {selectedElement.transform.GetChild(2)}");
        print($"�뷡 ���� :  {selectedElement.transform.GetChild(3)}");
        print("���� �ǳ�?" + selectedElement.transform.GetChild(3).GetComponent<AudioSource>().clip); // ��� Ŭ���� ���� ������Ʈ�� Audio Clip ���
        print(_GameManager.musicSelected.GetComponent<AudioSource>().clip);


        //_GameManager.musicSelected.GetComponent<AudioSource>().clip = selectedElement.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip;
        //print("�̰͵� �ȴٰ�?" + _GameManager.musicSelected.GetComponent<AudioSource>().clip.name);
        //_GameManager.musicSelected.Play();
    }

    //public void SelectElement()
    //{
    //    //// ��� ������ ��ư�� ������ �޾ƿɴϴ�.
    //    //GameObject _selectedElement = EventSystem.current.currentSelectedGameObject;
    //    selectedElement = _selectedElement;
    //}

    //public IEnumerator SelectElementInfo()
    //{
    //    selectedElement.transform.GetChild(3).gameObject.GetComponent<AudioSource>().Stop(); // Off 'Play On Awake'
    //    // Onclick�̺�Ʈ�� �߻��� ������Ʈ ������ ����� �ҽ� Ŭ���� �̸��� Ÿ��Ʋ �̸��� ��Ī�Ѵ�.
    //    selectedElement.transform.GetChild(1).gameObject.GetComponent<Text>().text = selectedElement.transform.GetChild(3).GetComponent<AudioSource>().clip.name;

    //    _GameManager.musicSelected.clip = selectedElement.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip;
    //    _GameManager.musicSelected.Play();
    //    yield return null;
    //}

    //// [Button] Element Selected
    //public void BtnElementSelected()
    //{
    //    // Original Element
    //    if (isOriginal == true && isCustom == false)
    //    {
    //        for (int i = 0; i < originalElementPrefab.Length; i++)
    //        {
    //            musicSelected.clip = originalElementPrefab[i].transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip;
    //            musicSelected.Play();
    //        }
    //    }
    //    // Custom Element
    //    else if (isOriginal == false && isCustom == true)
    //    {
    //        for (int i = 0; i < customElementPrefab.Length; i++)
    //        {
    //            musicSelected.clip = customElementPrefab[i].transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip;
    //            musicSelected.Play();
    //        }
    //    }
    //    return;
    //}
}
