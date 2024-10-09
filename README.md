# TP2 GODOT : Faire un save_manager et un level_manager

## Auteurs
- [Tom DUNET](https://github.com/Oridoshi) (DUNT18030400)
- [Axel BUREAUX](https://github.com/axelbrx) (BURA08050400)

## Objectif
Le but de ce TP est de créer un système de sauvegarde et de chargement de partie, ainsi qu'un système de gestion de niveaux. Pour cela, il faudra créer une classe `SaveManager` et une classe `LevelManager`. Un singleton, héritant de `SceneTree`, sera également mis en place pour permettre d'avoir une boucle de jeu personnalisée et d'accéder aux différents gestionnaires (`SaveManager` et `LevelManager`).

## Sprites utilisés
Pour ce TP, ont a utilisé les sprites suivants qui vienne de l'asset [Tiny Swords](https://pixelfrog-assets.itch.io/tiny-swords) sur itch.io :
- Personnage : <br>
![Personnage](./Tiny%20Swords%20(Update%20010)/Factions/Goblins/Troops/TNT/Red/TNT_Red.png)
![Personnage](./Tiny%20Swords%20(Update%20010)/Factions/Goblins/Troops/Barrel/Red/Barrel_Red.png)
![Personnage](./Tiny%20Swords%20(Update%20010)/Factions/Goblins/Troops/Torch/Red/Torch_Red.png)
![Personnage](./Tiny%20Swords%20(Update%20010)/Factions/Knights/Troops/Archer/Blue/Archer_Blue.png)
![Personnage](./Tiny%20Swords%20(Update%20010)/Factions/Knights/Troops/Pawn/Blue/Pawn_Blue.png)
![Personnage](./Tiny%20Swords%20(Update%20010)/Factions/Knights/Troops/Warrior/Blue/Warrior_Blue.png)

- Arbre : <br>
![Arbre](./Tiny%20Swords%20(Update%20010)/Resources/Trees/Tree.png)

- Tour : <br>
![Tower](./Tiny%20Swords%20(Update%20010)/Factions/Goblins/Buildings/Wood_Tower/Wood_Tower_Red.png)

## Tiles Map utilisé
Les tiles map utilisés viennent également de l'asset [Tiny Swords](https://pixelfrog-assets.itch.io/tiny-swords) sur itch.io :
- Eau : <br>
![Eau](./Tiny%20Swords%20(Update%20010)/Terrain/Water/Water.png)

- Eau avec des vagues : 
![Eau avec des vagues](./Tiny%20Swords%20(Update%20010)/Terrain/Water/Foam/Foam.png)

- Sol : <br>
![Sol](./Tiny%20Swords%20(Update%20010)/Terrain/Ground/Tilemap_Flat.png)

- Surélévation : <br>
![Surélévation](./Tiny%20Swords%20(Update%20010)/Terrain/Ground/Tilemap_Elevation.png)

- Ombrage : <br>
![Ombrage](./Tiny%20Swords%20(Update%20010)/Terrain/Ground/Shadows.png)

- Pont : <br>
![Pont](./Tiny%20Swords%20(Update%20010)/Terrain/Bridge/Bridge_All.png)

- Divers : <br>
![Divers_01](./Tiny%20Swords%20(Update%20010)/Deco/01.png) 
![Divers_02](./Tiny%20Swords%20(Update%20010)/Deco/02.png) 
![Divers_03](./Tiny%20Swords%20(Update%20010)/Deco/03.png) 
![Divers_04](./Tiny%20Swords%20(Update%20010)/Deco/04.png) 
![Divers_05](./Tiny%20Swords%20(Update%20010)/Deco/05.png) 
![Divers_06](./Tiny%20Swords%20(Update%20010)/Deco/06.png) 
![Divers_07](./Tiny%20Swords%20(Update%20010)/Deco/07.png) 
![Divers_08](./Tiny%20Swords%20(Update%20010)/Deco/08.png) 
![Divers_09](./Tiny%20Swords%20(Update%20010)/Deco/09.png) 
![Divers_10](./Tiny%20Swords%20(Update%20010)/Deco/10.png) 
![Divers_11](./Tiny%20Swords%20(Update%20010)/Deco/11.png) 
![Divers_12](./Tiny%20Swords%20(Update%20010)/Deco/12.png) 
![Divers_13](./Tiny%20Swords%20(Update%20010)/Deco/13.png) 
![Divers_14](./Tiny%20Swords%20(Update%20010)/Deco/14.png) 
![Divers_15](./Tiny%20Swords%20(Update%20010)/Deco/15.png) 
![Divers_16](./Tiny%20Swords%20(Update%20010)/Deco/16.png) 
![Divers_17](./Tiny%20Swords%20(Update%20010)/Deco/17.png) 
![Divers_18](./Tiny%20Swords%20(Update%20010)/Deco/18.png) 
![Divers_19](./Tiny%20Swords%20(Update%20010)/Resources/Gold%20Mine/GoldMine_Active.png)
![Divers_20](./Tiny%20Swords%20(Update%20010)/Factions/Knights/Buildings/Castle/Castle_Blue.png)
![Divers_21](./Tiny%20Swords%20(Update%20010)/Factions/Knights/Buildings/Tower/Tower_Blue.png)