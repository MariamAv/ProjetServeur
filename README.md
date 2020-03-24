# ProjetServeur : Revues

## On souhaite construire une base de données gérant des revues et les articles de ces revues.

Une **revue** est caractérisée par un nom et une périodicité. Chaque revue parait sous la forme de
numéros, chaque **numéro** étant identifié par un nombre relatif à la revue et à l'année en cours (ex. le
numéro 12 de Linux Magazine en 2003 est différent du numéro 12 de Linux Magazine en 2004). Un
numéro est également caractérisé par un nombre de pages. Chaque numéro contient des articles
écrits par un ou plusieurs auteurs. Un **auteur** est caractérisé par un nom, un prénom, ainsi qu'un
email. Chaque **article** possède un titre et un contenu. Un même article peut apparaître dans plusieurs
numéros d'une même revue ou de différentes revues. Lorsqu'un article apparaît dans un numéro
d'une revue, il a une page de début et une page de fin. Un article peut faire référence à d'autres
articles.

La base de données doit permettre de répondre à des requêtes telles que 
* "Combien de numéros de Linux Magazine sont parus en 2004 ?" 
* "Quels sont les titres des articles parus dans au moins deux revues différentes ?" 
* "Quels sont les auteurs ayant publiés dans le numéro 3 de la revue L'Histoire en 2004 ?" 
* etc.

L'ensemble d'entités Numéro est un ensemble d'entités faibles de Revue au format Merise (ou une
association qualifiée en UML). En effet, ce choix de modélisation a été fait pour représenter le fait
que l'identificateur d'un numéro est relatif à la revue à laquelle le numéro appartient. Un numéro
d'une revue donnée étant identifié par un nombre et une année, ces deux attributs (ID et Année)
sont soulignés.

Les cardinalités de l'association entre les ensembles d'entités Numéro et Article sont 1:N-1:M, car un
article peut apparaître dans plusieurs numéros et un numéro contient plusieurs articles. Le principe
est le même pour les cardinalités de l'association entre Auteur et Article.

Les attributs PageDébut et PageFin caractérisent l'association entre Article et Numéro (un numéro
étant relatif à une revue, il est inutile de faire une association avec Revue). En effet, la page de début
et la page de fin peuvent varier, pour un même article, lorsqu'il paraît dans plusieurs numéros
différents.

![Schema]()


