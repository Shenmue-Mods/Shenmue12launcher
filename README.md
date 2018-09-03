# Shenmue 1 &amp; 2 launcher
This is a customized version of the Shenmue I &amp; II Steam launcher that has been modified to accept sm1 and sm2 as command line arguments. It was created to allow end users to be able to create desktop shortcuts for Shenmue 1 and Shenmue 2 that launch directly into the game instead of the launcher.

After the 1.01 patch to the Steam version of the game it was no longer possible to just launch Shenmue.exe and Shenmue2.exe to start the game.

To use:
Rename the existing launcher and put the custom launcher in its place. Then create a shortcut to steam that launches the app with one of those arguments.

`Steam.exe -applaunch 758330 sm1`

or

`Steam.exe -applaunch 758330 sm2`

This requires the original game to work. It depends on files located in the installed game directory, it will not function anywhere else. The only purpose of this application is to allow the user to start one of the games.
