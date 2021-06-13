### Aclaraciones
**S**i desea replicar el proyecto desde cero deberá crear una solución con las siguientes características:

Proyecto del tipo ASP.NET Core Web Api con .NET 5. (realizado en visual studio 2019)
Configurado para HTTPS, Docker no habilitado, no habilitado con compatibilidad OpenApi (se agregó manualmente Swagger)
El proyecto utiliza NLOG para mantener un control de los eventos internos. Este control se realiza mediante ficheros .txt que se encuentran en C:/logs. De no existir el directorio, este se creará al momento de hacer su primer registro.

**Otras librerías instaladas:**

- Newtonsoft.Json 13.0.1
- Swashbuckle.AspNetCore 6.1.4
- System.Data.SQLClient 4.8.2

**E**n el directorio raíz del proyecto encontrará un fichero llamado **bkpDBFlockITChallenge.sql** El mismo replicará la base de datos con su store procedure y tabla users incluyendo sus datos internos. **(Necesario para correr el proyecto)**

**EndPoints Disponibles: **
1. https://SERVER:PORT/api/georef/getGeoRef
2. https://SERVER:PORT/api/Auth/getAuth

Estructura necesaria para consumo de EndPoint **getAuth**:
En postman:  POST -> Body -> Raw  -> del tipo JSON

{
    "User": "admin",
    "Password": "root"
}

User necesario para realizar la consulta al endpoint **getAuth**:
USER: admin
PASSWORD: root

Estructura necesaria para consumo de EndPoint **getGeoRef**:
En postman:  POST -> Body -> Raw  -> del tipo JSON

{
    "state": "cordoba"
}

**Información de la versión SQL Developer:**
- Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64) Sep 24 2019 13:48:23 Copyright (C) 2019 Microsoft Corporation Developer Edition (64-bit) on Windows 10 Pro 10.0 (Build 19042: ) (Hypervisor)
- SQL Server Management Studio 15.0.18384.0
- Objetos de administración de SQL Server (SMO) 16.100.46367.54
- Herramientas cliente de Microsoft Analysis Services 15.0.19535.0
- Microsoft Data Access Components (MDAC) 10.0.19041.1
- Microsoft MSXML 3.0 6.0
- Microsoft .NET Framework 4.0.30319.42000
- Sistema operativo 10.0.19042

### Consideraciones:
**A** fines prácticos se ha cifrado la contraseña utilizando MD5. Recomendaría cifrar en Argon2, más específicamente Argon2id.

**D**ada la naturaleza del proyecto se ha optado por incluir las interfaces, es decir los contratos en el directorio Service quedando el servicio junto con su interfaz de servicio. En caso de escalar la solución se recomienda utilizar un directorio ***contract*** para una mejor organización del código.
