# Unity3d Homework1

标签（空格分隔）： GUI 游戏

---

## 解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。
* 游戏对象：游戏中的所有对象都是游戏对象，游戏对象 (GameObject)是所有其他组件 (Component) 的容器，比如人、桌子等游戏中的实物。
* 资源：游戏项目中会用到的所有素材。
* 联系：有些资源可作为模板，可以实例化成游戏中具体的对象。
* 区别：对象一般直接出现在游戏的场景中，是资源整合的具体表现；而资源是为对象服务而使用的，多个不同的对象可以享用共同的资源。

## 下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）
* 资源结构: 多采用不同的目录存放不同的资源,每个子目录下面有其子目录或资源
* 对象中一般有玩家、敌人、环境、摄像机和音乐等虚拟父类，这些父类本身没有实体，但他们的子类包含了游戏中会出现的对象。

## 编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件
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
## 查找脚本手册，了解 GameObject，Transform，Component 对象
### 1)分别翻译官方对三个对象的描述（Description
GameObject： 
从角色和收藏品到光线、摄像头和其他的物品，游戏中的每个物体都是一个游戏对象。

Transform： 
Transform决定了视图中每一个物体的位置、旋转和缩放。每个游戏对象都有一个Transform。

Component： 
Component是一个游戏中对象和行为的组件，它们是每个游戏对象的基本元素。
### 2)描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
实体属性：chair1~4

Transform属性：位置(0,0,0),旋转(0,0,0),缩放(1,1,1)

部件：Box Colider是碰撞属性，物体的中心为坐标原点，碰撞范围为一个边长为单位长度的正方体；Mesh Renderer为网格过滤器，他可以表示游戏对象的网格渲染。

### 3）用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本出图）
![此处输入图片的描述][1]


  [1]: https://wx2.sinaimg.cn/mw690/005K0VGwly1fprphnntf1j30l409qaab.jpg
  
## 整理相关学习资料，编写简单代码验证以下技术的实现：
 - 查找对象
```c#
var obj = GameObject.Find("ObjectName");
var obj = GameObject.FindGameObjectsWithTag("ObjectTagName");
var obj = GameObject.FindWithTag("ObjectTagName");
if(obj != null)
    Debug.Log("Find seccessed!");
else
    Debug.Log("Find failed!");
```
 - 添加子对象
```c#
GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
plane.name = "plane";
plane.transform.position = new Vector3(0, Random.Range(0, 5), 0);
plane.transform.parent = this.transform;
```
 - 遍历对象树
```c#
void Start () {
    object[] gameObjects;
    gameObjects = GameObject.FindObjectsOfType(typeof(Transform));
    foreach (Transform iter in gameObjects)
        Debug.Log(iter.name);
}
```
 - 清除所有子对象
```c#
for (int i = 0; i < transform.childCount; i++)
    Destroy(transform.GetChild(i).gameObject);
```
## 资源预设（Prefabs）与 对象克隆 (clone)
### 1）资源预设有什么好处
预设的好处： 
 - 当需要创建一个在场景中要被多次使用的对象时，在需要修改的时候，需要一个一个单独编辑，会造成很大的不方便。使用预设可以快速、方便的创建大量可以重复使用的资源。 
 - 可以在程序运行时来执行实例化操作，可以提高程序运行效率和节省内存空间。
### 2）预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
对象克隆就是对一个游戏对象的简单复制，复制过后依然可以选择性更改其属性。克隆本体改变，克隆对象不会随之改变。
### 3）制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象
```c#
void Start () {
    GameObject contain = GameObject.Find("init");
    GameObject obj = (GameObject)Resources.Load("tb");
    GameObject pre_table = Instantiate(obj);
    pre_table.transform.position = new Vector3(0, Random.Range(5, 7), 0);
    pre_table.transform.parent = contain.transform;
}
```
## 尝试解释组合模式（Composite Pattern / 一种设计模式）。使用 BroadcastMessage() 方法
组合模式指将对象组合成树形结构以表示“部分-整体”的层次结构，它可以让用户在使用单个对象或组合对象时保持一致性。
BroadcastMessage() 方法向子对象发送信息： 
父对象代码：
```
this.BroadcastMessage("sendFr
 - 列表项

omInit", "The mission is finished!");
```
子对象代码：
```
public void sendFromInit(string s){
    Debug.Log(s);
}
```
输出结果为("The mission is finished!")