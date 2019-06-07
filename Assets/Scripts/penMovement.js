#pragma strict

var isDown : boolean = false;
var tip : GameObject;

function Start (){
	Cursor.visible = false;
}

function Update (){
	if(Input.GetMouseButton(0) && GameObject.Find("Person(Clone)/PaperIn") != null){
		tip.transform.position.y = 0.2;
		isDown = true;
		name = "PenDown";
		transform.position.y = 1.8;
	}else{
		tip.transform.position.y = -10;
		isDown = false;
		name = "Pen";
		transform.position.y = 2.5;
	}
	var w : int = Screen.width;
	var h : int = Screen.height;
	var xpos : float = (w - Input.mousePosition.x)/w;
	var ypos : float = (h - Input.mousePosition.y)/h;
	transform.position.z = ypos*-10;
	transform.position.x = xpos*(-9);
}