# Unity3d Homework1

��ǩ���ո�ָ����� GUI ��Ϸ

---

## ���� ��Ϸ����GameObjects�� �� ��Դ��Assets������������ϵ��
* ��Ϸ������Ϸ�е����ж�������Ϸ������Ϸ���� (GameObject)������������� (Component) �������������ˡ����ӵ���Ϸ�е�ʵ�
* ��Դ����Ϸ��Ŀ�л��õ��������زġ�
* ��ϵ����Щ��Դ����Ϊģ�壬����ʵ��������Ϸ�о���Ķ���
* ���𣺶���һ��ֱ�ӳ�������Ϸ�ĳ����У�����Դ���ϵľ�����֣�����Դ��Ϊ��������ʹ�õģ������ͬ�Ķ���������ù�ͬ����Դ��

## ���ؼ�����Ϸ�������ֱ��ܽ���Դ��������֯�Ľṹ��ָ��Դ��Ŀ¼��֯�ṹ����Ϸ�������Ĳ�νṹ��
* ��Դ�ṹ: ����ò�ͬ��Ŀ¼��Ų�ͬ����Դ,ÿ����Ŀ¼����������Ŀ¼����Դ
* ������һ������ҡ����ˡ�����������������ֵ����⸸�࣬��Щ���౾��û��ʵ�壬�����ǵ������������Ϸ�л���ֵĶ���

## ��дһ�����룬ʹ�� debug �������֤ MonoBehaviour ������Ϊ���¼�����������
```c#
using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class NewBehaviourScript : MonoBehaviour {
        //Call when loaded script
        void Awake()
        {
            Debug.Log("Awake");
        }
        // Use this for initialization
        void Start ()
        {
            Debug.Log("Start");
        }
        // Update is called once per frame
        void Update ()
        {
            Debug.Log("Update");
        }
        private void FixedUpdate()
        {
            Debug.Log("FixedUpdate");
        }
        private void LateUpdate()
        {
            Debug.Log("LateUpdate");
        }
        private void OnGUI()
        {
            if (GUILayout.Button("Press Me"))
                Debug.Log("Hello!");
        }
        private void OnDisable()
        {
            Debug.Log("OnDisable");
        }
        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }
    }
```
## ���ҽű��ֲᣬ�˽� GameObject��Transform��Component ����
### 1)�ֱ���ٷ������������������Description
GameObject�� 
�ӽ�ɫ���ղ�Ʒ�����ߡ�����ͷ����������Ʒ����Ϸ�е�ÿ�����嶼��һ����Ϸ����

Transform�� 
Transform��������ͼ��ÿһ�������λ�á���ת�����š�ÿ����Ϸ������һ��Transform��

Component�� 
Component��һ����Ϸ�ж������Ϊ�������������ÿ����Ϸ����Ļ���Ԫ�ء�
### 2)������ͼ�� table ����ʵ�壩�����ԡ�table �� Transform �����ԡ� table �Ĳ���
ʵ�����ԣ�chair1~4

Transform���ԣ�λ��(0,0,0),��ת(0,0,0),����(1,1,1)

������Box Colider����ײ���ԣ����������Ϊ����ԭ�㣬��ײ��ΧΪһ���߳�Ϊ��λ���ȵ������壻Mesh RendererΪ����������������Ա�ʾ��Ϸ�����������Ⱦ��

### 3���� UML ͼ���� ���ߵĹ�ϵ����ʹ�� UMLet 14.1.1 stand-alone�汾��ͼ��
![�˴�����ͼƬ������][1]


  [1]: https://wx2.sinaimg.cn/mw690/005K0VGwly1fprphnntf1j30l409qaab.jpg
  
## �������ѧϰ���ϣ���д�򵥴�����֤���¼�����ʵ�֣�
 - ���Ҷ���
```c#
var obj = GameObject.Find("ObjectName");
var obj = GameObject.FindGameObjectsWithTag("ObjectTagName");
var obj = GameObject.FindWithTag("ObjectTagName");
if(obj != null)
    Debug.Log("Find seccessed!");
else
    Debug.Log("Find failed!");
```
 - ����Ӷ���
```c#
GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
plane.name = "plane";
plane.transform.position = new Vector3(0, Random.Range(0, 5), 0);
plane.transform.parent = this.transform;
```
 - ����������
```c#
void Start () {
    object[] gameObjects;
    gameObjects = GameObject.FindObjectsOfType(typeof(Transform));
    foreach (Transform iter in gameObjects)
        Debug.Log(iter.name);
}
```
 - ��������Ӷ���
```c#
for (int i = 0; i < transform.childCount; i++)
    Destroy(transform.GetChild(i).gameObject);
```
## ��ԴԤ�裨Prefabs���� �����¡ (clone)
### 1����ԴԤ����ʲô�ô�
Ԥ��ĺô��� 
 - ����Ҫ����һ���ڳ�����Ҫ�����ʹ�õĶ���ʱ������Ҫ�޸ĵ�ʱ����Ҫһ��һ�������༭������ɺܴ�Ĳ����㡣ʹ��Ԥ����Կ��١�����Ĵ������������ظ�ʹ�õ���Դ�� 
 - �����ڳ�������ʱ��ִ��ʵ����������������߳�������Ч�ʺͽ�ʡ�ڴ�ռ䡣
### 2��Ԥ��������¡ (clone or copy or Instantiate of Unity Object) ��ϵ��
�����¡���Ƕ�һ����Ϸ����ļ򵥸��ƣ����ƹ�����Ȼ����ѡ���Ը��������ԡ���¡����ı䣬��¡���󲻻���֮�ı䡣
### 3������ table Ԥ�ƣ�дһ�δ��뽫 table Ԥ����Դʵ��������Ϸ����
```c#
void Start () {
    GameObject contain = GameObject.Find("init");
    GameObject obj = (GameObject)Resources.Load("tb");
    GameObject pre_table = Instantiate(obj);
    pre_table.transform.position = new Vector3(0, Random.Range(5, 7), 0);
    pre_table.transform.parent = contain.transform;
}
```
## ���Խ������ģʽ��Composite Pattern / һ�����ģʽ����ʹ�� BroadcastMessage() ����
���ģʽָ��������ϳ����νṹ�Ա�ʾ������-���塱�Ĳ�νṹ�����������û���ʹ�õ����������϶���ʱ����һ���ԡ�
BroadcastMessage() �������Ӷ�������Ϣ�� 
��������룺
```
this.BroadcastMessage("sendFr
 - �б���

omInit", "The mission is finished!");
```
�Ӷ�����룺
```
public void sendFromInit(string s){
    Debug.Log(s);
}
```
������Ϊ("The mission is finished!")