# Unity3D Homework2

��Ϸ unity3D

---

## 1����Ϸ�����˶��ı�����ʲô��
��Ϸ�����˶��ı��ʾ�����Ϸ����Transform�ĸı�

## 2���������ַ������Ϸ�����ʵ��������������˶������磬�޸�Transform���ԣ�ʹ������Vector3�ķ�������
1���ı�transform.position
```
public class Movable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime;
        this.transform.position += Vector3.up * (1 + Time.deltaTime) * (Time.deltaTime + 1)/50;
	}
}
```
2)ʹ��Vector3
```
	void Update () {
        Vector3 target = this.transform.position + Vector3.up * (Time.deltaTime*10+1)*(Time.deltaTime*10 + 1)/5 + 10*Vector3.left * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime);
    }
```
3)ʹ��transform.Translate
```
void Update () {
        Vector3 speed = new Vector3(1, 1, 0);
        Vector3 Gravity = Vector3.zero;
        this.transform.Translate(speed * Time.fixedDeltaTime);
        this.transform.Translate(Gravity * Time.fixedDeltaTime);
    }
```
## 3��дһ������ʵ��һ��������̫��ϵ����������Χ��̫����ת�ٱ��벻һ�����Ҳ���һ����ƽ���ϡ�
```
void Update()
{
        Vector3 ver1 = new Vector3(1, 1, 1);
        moon.transform.RotateAround(earth.transform.position, ver1, 2);
        Vector3 ver2 = new Vector3(-1, 0, 1);
        earth.transform.RotateAround(sun.transform.position, ver2, 3);
        Mercury.transform.RotateAround(sun.transform.position, Vector3.up, 3);
        Mars.transform.RotateAround(sun.transform.position, Vector3.up, 3);
        Jupiter.transform.RotateAround(sun.transform.position, Vector3.up, 3);
        Saturn.transform.RotateAround(sun.transform.position, Vector3.up, 3);
        Uranus.transform.RotateAround(sun.transform.position, Vector3.up, 3);
        Neptune.transform.RotateAround(sun.transform.position, Vector3.up, 3);
}
```
emmm,���ڲ�֪�����巨�����нǣ�����ֻ������������һ���ǵ���һ���������ģ�ʣ�µľͶ�ֱ����y��ת�ˡ�





