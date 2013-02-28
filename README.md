StatePattern
============

A simple example of DrawPad demo-ing the state pattern.

State pattern applied to the mouse class when handling different drawing operations.

Requirements
============
* Draw rectangle.
	2 clicks.
	First click for top left, second click for bottom right.
* Draw circle. 
	2 clicks.
	First click for center, second click for radius.
* Draw ellipse.
	2 clicks. 
	To specify out-bound rectangle, first click for top left, second click for bottom right.
* Draw triangle.
	3 clicks. 
	Three clicks for each top.
* Draw arc. 
	3 clicks.
	First click for center, second click for begin, third click for end.
* Draw polygon. 
	N clicks.
	Double click or click on the start point to finish.
* Draw polygon.
	For 2 click, create a rectangle instance instead of a polygon instance.
	For 3 click, create a triangle instance instead of a polygon instance.
	