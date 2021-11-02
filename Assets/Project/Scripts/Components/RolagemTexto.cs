using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RolagemTexto : MonoBehaviour
{
    [SerializeField] private Button jogar;
    private string mapaInicial = "Fase1";

    private void Start()
    {
        jogar.onClick.AddListener(() => Jogar());
    }

    private void Update()
    {
        transform.GetComponent<RectTransform>().position = new Vector3(0, transform.GetComponent<RectTransform>().position.y + (2 * Time.deltaTime), transform.GetComponent<RectTransform>().position.z + (2 * Time.deltaTime));
    
        if (transform.GetComponent<RectTransform>().position.y > 30)
        {
            jogar.gameObject.SetActive(true);
        } 
    }

    private void Jogar() => SceneManager.LoadScene(mapaInicial);
}
