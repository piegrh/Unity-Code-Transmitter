# CodeTransmitter
![alt text](https://i.imgur.com/PqU9sRA.gif)  
This is a Unity package for creating stuff like this:  A man signaling SOS in morsecode by blinking.  
It can easily be extended to support other codes as well by creating a subclass the CodeTransmitter component.  
[Youtube example](https://www.youtube.com/watch?v=CN8wYa_Jrjs).

## CodeTransmitter
Abstract component.

## CodeTransmitterController  
Sample component that shows how a CodeTransmitter can be controlled.  
This component will keep transmitting a message with a delay between every transmission.  
![alt text](https://i.imgur.com/1JZCD3K.png)  
The component requires a CodeTransmitter component.  

## MorseCodeTransmitter  
A component that transmits morsecode.  

## CodeTransmitterReceiver
This components listens for OnActive and OnDeactivate events from a CodeTransmitter  
and fires and corresponding UnityEvent.  
![alt text](https://i.imgur.com/iBwT15F.png)  
OnActive:  
1. Set material to the "on" material.
2. Set audiosource clip to "beep"
3. Play audiosource.

OnDeactive:  
1. Set material to the "off" material.
2. Stop audiosource.
