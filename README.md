![](JMCMediaPLayer/hnet.com-image.ico)
# JMCMediaPLayer 

	PROJECT SCOPE
The aim of the JMC Media Player is to create a convenient and easy-to-use application for the staff members to login and manage media files with the software. The staff data will be stored in a database server. The application needs to be as light as possible so that it will have faster load time.
The music player allows a user to play various media file formats. It can be used to play audio as well as video files. The music player is a software project supporting all known media files and has the ability to play them with ease.
The project features are as follows:

•	User may add multiple various media files within it.

•	User may see track lists and play desired ones accordingly.

•	Supports various music formats including .mp3, WMA, WAV etc.

•	Interactive GUI

•	Consists of Pause/Play/Stop Features

•	Consists of a Volume controller

•	The system also consists of a sound Equalizer

•	It displays the media playing time with Track Bar so that user may drag the media play as needed.

•	The playlist can be edited and saved

Readable GUI format with all clients have individual and secure log on to their account information.


	OVERALL DESCRIPTION


  PRODUCT PERSPECTIVE
  
The software will have a login function for clients to login with username and password. Clients will be able to play media files and add them to playlist. The login information will be saved in a database.

	PRODUCT FUNCTIONS/FEATURES
All Features are already outlined on the Project Scope section. Refer back to 1.2 in order to fully compensate the Product features that needed to be implemented on this program. Brief context summary:

•	Login feature

•	Simple navigation and management

•	Playback of music files in MP3, mp4, and more.

•	Playlist for managing the media files(adding, removing and saving the media files) 

•	Database connection for managing user data


	CLASS DIAGRAM
	
The Class Diagram of the project illustrates all the classes used in the project with the related properties and methods.

There are 6 main classes consisting of: 

Login Register: This class is for the Login form.

JMC Audio Player: This class is for the media player form.

Database: Has the properties and methods to connect to the database, add a user and search and validate username and password.

Hash Computer: Has the properties and methods to encrypt the password, and validate the given password.

Media file: Class containing properties for media files.

User: class containing properties for users.


	USER INTERFACE DESIGN
	

The design has excellent features such as a dark modern theme and high-quality background pictures for a better presentation and visually appealing application. All the features are clearly visible and easy to find.

The application is consist of two windows forms. When the application starts, it will connect to a database then a login form will be shown. Users can create a new account or use their username and password to login. The second form will appear after the login is approved and from there the client will be able to navigate through the media player and use the different features of the application.

![LoginGUI](https://user-images.githubusercontent.com/19610431/70666566-de215a80-1ca9-11ea-8896-e43fe31bf9b4.JPG)
![MediaPlayerGUI](https://user-images.githubusercontent.com/19610431/70666574-e083b480-1ca9-11ea-9def-2df01393533d.JPG)
