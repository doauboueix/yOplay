# Evaluation

## Remarques générales

* Il manque le code d'au moins une procédure stockée (AchatMesMusique)
* La procédure stockée AchatFilm ne reçoit pas les bons paramètres (@Titre au lieu de @Nom)
* Votre projet est vraiment très bon. Vous avez implémenté beaucoup de fonctionnalités et globalement, tout fonctionne bien. En revanche, il faut que vous passiez du temps sur les parties "documentation". Allez chercher les points qui vous manquent !

## Objets 2 : Conception et programmation orientées objets (C#, .NET)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|-|
| Je sais concevoir un diagramme de classes qui représente mon application. | 3 | 8 | Il manque toute la logique d'implémentation. Dans votre cas, il faudrait modéliser les windows WPF qui portent la logique algorithmique. |
| Je sais réaliser un diagramme de paquetages qui illustre bien l'isolation entre les parties de mon application. | 0 | 4 | Pas de diagramme. |
| Je sais réaliser un diagramme de séquences qui décrit l'un des processus de mon application. | 0 | 2 | Pas de diagramme |
| Je sais décrire mes trois diagrammes en mettant en valeur et en justifiant les éléments essentiels. | 0 | 6 | Pas de description. |

**Note provisoire** 03/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je maîtrise les bases de la programmation C# (classes, structures, instances...) | 2 | 2 | OK |
| Je sais utiliser l'abstraction à bon escient (héritage, interface, polymorphisme). | 1 | 3 | Pourquoi la classe Media est-elle concrête ? Le découpage de la partie "Data" (appels SQL) est technique. Peut-être auriez-vous pu la découper fonctionnellement ? De plus, l'ouverture d'une connexion est l'exécution d'une procédure stockée pourrait être réécrite pour éviter de la duplication de code. |
| Je sais gérer des collections simples (tableaux, listes, ...) | 2 | 2 | OK |
| Je sais gérer des collections avancées (dictionnaires). | 0 | 2 | Vous n'utilisez pas de collections avancées. |
| Je sais contrôler l'encapsulation au sein de mon application. | 3 | 5 | La playlist pourrait être portée directement par l'utilisateur. Les méthodes qui intéragissent avec la base de données ont toutes publiques. Enfin, pourquoi avoir stocké des variables de classe (static) pour les attributs d'un Utilisateur ? |
| Je sais tester mon application. | 0 | 4 | Pas de test unitaire. La partie stockage de données mériterait d'être testée. |
| Je sais utiliser LINQ. | 1 | 1 | OK |
| Je sais gérer les évènements. | 1 | 1 | Votre métier n'émet pas d'évènement à proprement parler. Cependant, une gestion d'évènements a été implémentée dans les vues (UCTitre). |

**Note provisoire** 10/20

## IHM : Interface Homme-Machine (WAML, WPF)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais décrire le contexte de mon application pour qu'il soit compréhensible par tout le monde. | 0 | 4 | Pas de description. |
| Je sais dessiner des sketchs pour concevoir les fenêtres de mon application. | 0 | 4 | Pas de sketchs. |
| Je sais enchaîner mes sketchs au sein d'un storyboard. | 0 | 4 |  Pas de Storyboards. |
| Je sais concevoir un diagramme de cas d'utilisation qui représente les fonctionnalités de mon application. | 0 | 5 | Pas de diagramme de cas d'utilisations. |
| Je sais concevoir une application ergonomique. | 2 | 2 | OK |
| Je sais concevoir une application avec une prise en compte de l'accessibilité. | 0 | 1 | En quoi votre application prend-elle en compte l'accessibilité ? |

**Note provisoire** 02/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais choisir mes layouts à bon escient. | 1 | 1 | OK
| Je sais choisir mes composants à bon escient. | 1 | 1 | OK |
| Je sais créer mon propre composant. | 2 | 2 | OK |
| Je sais personnaliser mon application en utilisant des ressources et des styles. | 2 | 2 | OK |
| Je sais utiliser les DataTemplates (locaux et globaux). | 2 | 2 | OK |
| Je sais intercepter les évènements de la vue. | 2 | 2 | OK |
| Je sais notifier la vue depuis des évènements métier. | 0 | 2 | Il ne s'agit pas à proprement parler du **métier** qui émet un évènement. |
| Je sais gérer le DataBinding sur mon master. | 1 | 1 | OK  |
| Je sais gérer le DataBinding sur mon détail. | 1 | 1 | OK |
| Je sais gérer le DataBinding et les Dependency Property sur mes UserControls. | 2 | 2 | OK |
| Je sais développer un Master/Detail (navigation, liens entre les deux écrans, ...) | 4 | 4 | OK |

**Note provisoire** 18/20

## Projet Tuteuré S2

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais mettre en avant dans mon diagramme de classes la persistance de mon application. | 0 | 2 | La persitance n'est pas modélisée. |
| Je sais mettre en avant dans mon diagramme de classes ma partie personnelle. | 0 | 4 | Votre partie personnelle n'est pas modélisée. |
| Je sais mettre en avant dans mon diagramme de paquetages la persistance de mon application. | 0 | 4 | La persistance n'est pas modélisée. |
| Je sais réaliser une vidéo de 1 à 3 minutes qui montre la démo de mon application. | 0 | 10 | Pas de vidéo. |

**Note provisoire** 0/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais coder la persitance au sein de mon application. | 2 | 3 | Il y a pas mal de duplication de code. Il faudrait également veiller à utiliser des procédures stockées partout plus que mixer requêtes textes et procédures stockées. |
| Je sais coder une fonctionnalité qui m'est personnelle. | 3 | 3 | J'ai l'embarras du choix ! |
| Je sais documenter mon code. | 1.5 | 2 | Votre code est bien documenté mais ne respecte pas les standards .net (utilisation du ///) |
| Je sais utiliser Git. | 2 | 2 | OK |
| Je sais développer une application qui compile. | 3 | 3 | OK |
| Je sais développer une application fonctionnelle. | 3.5 | 4 | J'ai détecté quelques bugs (appel à une procédure stockée avec des paramètres inattendus) |
| Je sais mettre à disposition un outil pour déployer mon application. | 0 | 3 | Il n'y a pas d'installer. |

**Note provisoire** 15/20