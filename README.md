Speed v1.0
===========

## MultiThreading made easy
Speed ​​is a multithreading Class Library that will help Windows Forms developers to make quick and fluent interfaces.

## How to get started

##Examples

```Visual Basic
Dim multi As New Speed.MultiThreading(Me)

multi.Run(Sub()
	For i As Integer = 0 To 100000
		'Sending data to the interface thread
		multi.ThreadSafe(i, Sub(n As Integer)
			'Display the number on the interface
			Label1.Text = n
		End Sub)
	Next
End Sub)
```