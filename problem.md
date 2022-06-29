## **ENUNCIADO**
Diseñar e implementar un gestor de inventarios.
-	Diseña e implementa una API REST con .NET y c# que modele y soporte los siguientes requisitos.
-	Proporciona un fichero README con:
    - Instrucciones para ejecutar la aplicación
    - Breve documentación sobre el diseño, estructura de código y cualquier anotación que se quiera añadir sobre extensibilidad, mantenimiento, seguridad, rendimiento, etc, que no haya dado tiempo a implementar.
    - Breve documentación sobre asunciones, razonamientos, requisitos modificados y sus motivos
-	Escribe código con calidad de producción y proporciona una solución funcional (al menos con tests como punto de entrada)
-	Es suficiente con que los datos estén en memoria (no es necesario código de base de datos)
-	Documenta todos los “atajos” que estés utilizando. El ejercicio se revisará como si estuviera escrito para producción. Si no se menciona un atajo o simplificación, entenderemos que se debe a tu nivel de experiencia.
	Por ejemplo: “Así es como se gestionaría la seguridad. No lo incluyo en el código porque hubiera sido demasiado costoso en tiempo”
-	Escribe tests
-	Por favor pregúntanos cualquier duda que tengas sobre el ejercicio.
-	OPCIONAL: Sube tu solución a un repositorio en Github para facilitarnos la revisión.
- OPCIONAL: Implementa una interfaz web con ASP.NET MVC 5 y el framework de front-end MaterializeCss, que comparta código de servidor con la API Web

## **REQUISITOS**
1. AÑADIR UN ELEMENTO AL INVENTARIO
Cuando añado un elemento al inventario, éste contiene información sobre el elemento que se acaba de añadir, tal como Nombre, Fecha de caducidad, Tipo, etc
2. SACAR UN ELEMENTO DEL INVENTARIO POR NOMBRE
Cuando saco un elemento del inventario, el elemento deja de estar disponible en el inventario
3. NOTIFICAR QUE UN ELEMENTO SE HA SACADO DEL INVENTARIO
Cuando saco un elemento del inventario, entonces hay una notificación de que el elemento se ha sacado
4. NOTIFICAR CUANDO UN ELEMENTO CADUCA
Cuando un elemento del inventario caduca, entonces hay una notificación sobre el elemento caducado.
