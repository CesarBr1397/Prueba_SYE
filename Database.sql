create database "prueba_sye"
    with
    template = template0
    encoding = 'UTF8'
    lc_collate = 'es_MX.UTF-8'
    lc_ctype = 'es_MX.UTF-8'
    connection limit = -1
    is_template = False;

   -- \c "prueba_sye";

create schema if not exists schemasye;

-- Tablas de catálogos
--Tabla de enfermedades crónicas (catálogo)
create table if not exists schemasye.tc_enfermedad_cronica
(
    id_enf_cronica serial,
    nombre varchar(255) not null,
    descripcion varchar(255) default '' not null,
    fecha_registro date default current_date,
    fecha_inicio date default current_date,
    estado boolean not null default true,
    fecha_actualizacion date default null,
    primary key (id_enf_cronica)
);