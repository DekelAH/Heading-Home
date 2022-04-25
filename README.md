
![bg](https://user-images.githubusercontent.com/54857125/165123213-5c4c0e35-76fd-464b-8d83-e8ef53a686b2.png)

Heading-Home is a 3D casual mobile game where the player has to get from point A to B using his spaceship while avoiding different types of obstacles and collecting fuel items. In this game, I've tried to achieve cautious gameplay where the player can't just put on the gas all the way to the finish line.
While developing the game I aimed for a scalable development while using the following tools and patterns ~>

* Factory pattern for the creation of different types of obstacles and projectiles without repeating the same code.
* MVC Pattern for data-view relations between view scripts and ScriptableObject in a way that they are not dependent one on another.
* Aimed for single responsibility to each class to keep the code organized and clean.
* EventSystem interfaces to detect buttons touch and release for player movement.
* Kept on loose relations between classes using Events and mediators.

### Installing

A quick zip download, copy the Assets folder and paste it and replace the existing one in your Unity clean project. (5 min~)

## Built With
Unity Editor v2020.3.30f1

## Author
Dekel Aharon
