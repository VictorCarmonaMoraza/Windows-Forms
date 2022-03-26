## 16 - Creando la base de datos de SQL Server

En SQL server hemos creado un database llamada EstudianteProyecto2022 y le hemos creado una tabla con el nombre de
EstudiantePr2022 con los siguientes campos:

			Nombre Columna		Tipo de datos		Permitir valores NULL
		PK		id					int					NO					------>Es una PK incremental de un en uno por lo cul nunca podra ser nulo	
				nid					nvarchar(50)		SI
				nombre				nvarchar(50)		SI
				apellido			nvarchar(50)		SI
				email				nvarchar(50)		SI