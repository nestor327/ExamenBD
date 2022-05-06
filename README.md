# ExamenBD
Este proyecto administra las compras y las ventas de un local el cual concede permisos 
según el usuario que se logue en el proyecto, algunos solo pueden ver, 
otros pueden modificar y otros pueden hacer ambos.

**Intalacion: **
Para la abrir el proyecto debes instalar la base de datos de SQL-Server que se encuentra 
en la carpeta "Base de datos" del proyecto y luego crear un login llamado "UserExam" con la contraseña "201299" 
(puedes modificar la contraseña, pero asegurate de cambiarla tambien en la clase "Conexion" del proyecto)
despues al usuario "UserExam" con mebrecia db_owner debes asignarle el usuario creado, analogante crea un login 
para cada "usuario" que posee la base de datos "BDExamen".

**Introduccion: **
Este proyecto permite a usuarios ver los estados de las ventas asi como ingresar productos y compras de forma
que cada usuario que tiene permitido entrar lo hace con algunos permisos que otros no tienen.
