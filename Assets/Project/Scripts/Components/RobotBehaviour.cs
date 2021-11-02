using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviour : MonoBehaviour
{
    [SerializeField] public bool isTentaPegarLixo;
    [SerializeField] public bool isSoltaLixo;
    [SerializeField] public Transform lixoPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject playerModel;

    public IEnumerator Start()
    {
        if (GameManager.Instance().IsPlaying())
        {
            foreach (Command c in CommandData.Instance().GetBuild())
            {
                yield return new WaitForSeconds(5);
                if (c.id.Contains("Mover")) Mover(c.position, c.direcao);
                if (c.id.Equals("Pegar")) PegarLixo();
                if (c.id.Equals("Soltar")) SoltarLixo();

            }
        }
    }

    private void Mover(Vector3 pos, Quaternion rot)
    {
        isTentaPegarLixo = false;
        transform.position += pos;
        playerModel.transform.localRotation = new Quaternion(playerModel.transform.localRotation.x, rot.y, playerModel.transform.localRotation.z, rot.w);
        Debug.Log("Mover");
        animator.SetBool("walking", true);
    }

    private void MoverPersonagem(Vector3 pos)
    {

    }

    private void PegarLixo()
    {
        Debug.Log("PegarLixo");
        isTentaPegarLixo = true;
        animator.SetBool("walking", false);
    }

    private void SoltarLixo()
    {
        isTentaPegarLixo = false;
        Debug.Log("SoltarLixo");
        isSoltaLixo = true;
        animator.SetBool("walking", false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Lixo") && isTentaPegarLixo)
        {
            Destroy(other.gameObject);
            isTentaPegarLixo = false;
            lixoPrefab.gameObject.SetActive(true);
        }
        if (other.tag.Equals("Lixeira") && lixoPrefab.gameObject.activeSelf && isSoltaLixo)
        {
            lixoPrefab.gameObject.SetActive(false);
            isSoltaLixo = false;
        }
    }

}
