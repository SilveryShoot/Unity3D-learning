# Unity3D Homework2

游戏 unity3D

---

## 1、游戏对象运动的本质是什么？
游戏对象运动的本质就是游戏对象Transform的改变

## 2、请用三种方法以上方法，实现物体的抛物线运动。（如，修改Transform属性，使用向量Vector3的方法…）
1）改变transform.position
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
2)使用Vector3
```
	void Update () {
        Vector3 target = this.transform.position + Vector3.up * (Time.deltaTime*10+1)*(Time.deltaTime*10 + 1)/5 + 10*Vector3.left * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime);
    }
```
3)使用transform.Translate
```
void Update () {
        Vector3 speed = new Vector3(1, 1, 0);
        Vector3 Gravity = Vector3.zero;
        this.transform.Translate(speed * Time.fixedDeltaTime);
        this.transform.Translate(Gravity * Time.fixedDeltaTime);
    }
```
## 3、写一个程序，实现一个完整的太阳系，其他星球围绕太阳的转速必须不一样，且不在一个法平面上。
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
emmm,由于不知道具体法向量夹角，所以只捏造了两个，一个是地球一个是月亮的，剩下的就都直接绕y轴转了。





