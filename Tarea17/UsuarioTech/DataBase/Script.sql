create table Usuarios(Id int primary key identity(1,1), 
nombreUsuario varchar (50),
PassUsuario varchar(70) ,
Tipo varchar(70) 
);

create table Permisos(PermisosId int identity(1,1) primary key, Descripcon varchar(80));

create table PermisosDetalles( PermisosDetallesId int identity(1,1) primary key, Id int, PermisosId int );