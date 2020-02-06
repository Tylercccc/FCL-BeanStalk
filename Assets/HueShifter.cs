using UnityEngine;

public class HueShifter : MonoBehaviour
{
    public float rotateTime = 0;
    public float rotateAmt;
    public float Speed = 1;
    private Renderer rend;

    private void OnEnable()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        iTween.PunchScale(gameObject, new Vector3(1f, 1f, 1f), 3f);
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        iTween.RotateTo(gameObject, iTween.Hash(
            "rotation", new Vector3(0, 180, rotateAmt),
            "time", rotateTime,
            "loopType", iTween.LoopType.pingPong,
            "easeType", iTween.EaseType.easeInOutSine
        ));
    }

    void Update()
    {
        rend.material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed, 1), 1, 1)));
    }
}
