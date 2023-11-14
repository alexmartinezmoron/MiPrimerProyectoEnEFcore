# VideoClubEFCore

Se trata de un proyecto de autoformacion para interactuar con C# y EF core7


Este es un proyecto en entity framework core donde actualmente se inserta el driver para sql server se crean entidades, migraciones, se utiliza el api fluente para establecer varias propiedades a los datos y por ultimo se persiste sobre la base de datos.

Configuramos las relaciones basicas  en las entidades 1:n n:n y n:n con entidad intermedia, creamos un api controller para postear datos, insertamos datos con Postman y probamos Swagger. 

Creamos DTOs y añadimos automapper salvo que no es una clase abtracta sino que lo descargamos desde el NuGet.

Creamos nuevo post en el cual vamos a mappear y postear colleciones.

Creamos post con relaciones intermedias.
Creamos un Seeding inicial para la carga de datos en la bbdd.

Creamos gets para realizar querys, las cuales vamos poco a poco haciendolas mas complejas y utilizando criterios de ordenacion.
Cremos gets con querys incluyendo joins de tablas y ademas controlamos las relaciones circulares. Utilizamos select y proyeciones
