# GamePadToKeyboard

## Quoi ?
Programme basique qui simule l'appui sur une touche du clavier lorsque l'on appuie sur une touche de manette.

## Techno utilisée
C# avec le framework .Net 4.7 

## Todo
- Nettoyage du code 
- ajouter la possibilité de paramètrer les touches.
- Comprendre pourquoi la touche Return (0x0D) ne marche pas selon les applications : Par exemple, marche sur notepad, mais pas sur Visual Studio Code : Semble corrigé par InputSimulator

## Dépendances
- Utilise OpenTk pour la gestion de la manette https://github.com/opentk  et particulièrement GLControl.
Il semble y'avoir un problème de dépendances avec les paquets nuggets, Pour installer la bonne version, lancer la commande Install-Package OpenTK.GLControl
- Utilise également le projet https://github.com/michaelnoonan/inputsimulator à partir de la 0.03

Liste des touches : http://www.kbdedit.com/manual/low_level_vk_list.html
