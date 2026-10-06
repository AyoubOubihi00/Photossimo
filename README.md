\# 📸 Photossimo – Gestion et recherche d'images par tags



Photossimo est une application desktop Windows développée en \*\*C# / .NET 9 avec Windows Forms\*\*, permettant d'archiver, organiser et rechercher des images grâce à un système de tags.



Les informations associées aux images et aux tags sont stockées dans une base de données \*\*MySQL\*\*.



Ce projet a été réalisé dans le cadre de ma formation en \*\*Master Génie Informatique à l'Université de Lorraine\*\*.



\## 🚀 Fonctionnalités



\### 🖼️ Gestion des images



\- Importation d'images dans l'application

\- Affichage des images sous forme de miniatures

\- Consultation détaillée d'une image

\- Renommage des images

\- Modification des informations associées à une image

\- Suppression d'images



\### 🏷️ Gestion des tags



Photossimo permet d'associer des tags aux images afin de faciliter leur organisation et leur recherche.



Il est notamment possible de :



\- créer de nouveaux tags ;

\- modifier des tags existants ;

\- supprimer des tags ;

\- associer plusieurs tags à une image ;

\- modifier les tags associés à une image ;

\- organiser les tags de manière hiérarchique.



\### 🔎 Recherche d'images



L'application permet de retrouver des images à partir de leurs tags.



Les tags peuvent être sélectionnés depuis la hiérarchie afin de filtrer les images correspondantes.



Une barre de recherche permet également de rechercher rapidement un tag et d'afficher les images associées.



\### 🌳 Organisation hiérarchique



Les tags peuvent être organisés sous forme d'arborescence.



Cette organisation facilite la navigation dans les différentes catégories et permet de sélectionner les tags utilisés pour filtrer les images.



\## 🛠️ Technologies utilisées



\- \*\*C#\*\*

\- \*\*.NET 9\*\*

\- \*\*Windows Forms (WinForms)\*\*

\- \*\*MySQL\*\*

\- \*\*MySql.Data 9.2.0\*\*

\- \*\*phpMyAdmin\*\* pour l'administration de la base de données

\- \*\*Git / GitHub\*\*



\## 🏗️ Structure du projet



```text

Photossimo/

├── PhotossimoV9/

│   ├── App/

│   │   ├── CreateTag.cs

│   │   ├── GestionTag.cs

│   │   ├── ImageDetailView.cs

│   │   ├── ImageImportView.cs

│   │   ├── MainView.cs

│   │   ├── ModificationImage\_Tag.cs

│   │   ├── ModificationTag.cs

│   │   └── NomImageModif.cs

│   │

│   ├── DB/

│   ├── Object/

│   ├── Properties/

│   ├── Ressources/

│   ├── Utils/

│   ├── Program.cs

│   └── PhotossimoV9.csproj

│

└── PhotossimoV9.sln

```



L'application sépare notamment :



\- `App/` : interfaces et écrans Windows Forms ;

\- `DB/` : éléments liés à l'accès aux données ;

\- `Object/` : objets métier ;

\- `Utils/` : fonctionnalités utilitaires ;

\- `Ressources/` : ressources utilisées par l'application.



\## 💾 Base de données



Photossimo utilise \*\*MySQL\*\* pour stocker les informations nécessaires à la gestion des images et des tags.



L'accès à MySQL depuis l'application .NET repose sur :



```text

MySql.Data 9.2.0

```



La base peut être administrée avec \*\*phpMyAdmin\*\*.



> Les paramètres de connexion à la base de données doivent être adaptés à l'environnement local avant le lancement de l'application.



\## ▶️ Lancement du projet



\### Prérequis



\- Windows

\- .NET 9 SDK

\- MySQL

\- Visual Studio avec le support du développement .NET Desktop



\### Depuis Visual Studio



Ouvrir :



```text

PhotossimoV9.sln

```



Restaurer les dépendances NuGet si nécessaire, configurer la connexion à la base MySQL puis lancer le projet.



\### En ligne de commande



```bash

dotnet restore

dotnet build

dotnet run --project PhotossimoV9/PhotossimoV9.csproj

```



\## 🎯 Compétences mises en pratique



Ce projet m'a notamment permis de travailler sur :



\- le développement d'une application desktop en C#/.NET ;

\- la conception d'interfaces avec Windows Forms ;

\- la communication entre une application .NET et une base MySQL ;

\- la manipulation et l'organisation d'images ;

\- la conception d'un système de tags ;

\- la recherche et le filtrage de données ;

\- la gestion d'une structure hiérarchique de tags ;

\- l'organisation d'une application en plusieurs composants fonctionnels ;

\- le travail collaboratif avec Git et GitHub.



\## 👤 Auteur



\*\*Ayoub OUBIHI\*\*  

Master Génie Informatique – Université de Lorraine



\## 🤝 Projet collaboratif



Photossimo a été réalisé dans le cadre d'un projet universitaire en équipe.  



