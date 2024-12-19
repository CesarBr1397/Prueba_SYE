-- FUNCTION: schemasye.agregar_enfermedad(character varying, character varying, date, date, boolean, date)

-- DROP FUNCTION IF EXISTS schemasye.agregar_enfermedad(character varying, character varying, date, date, boolean, date);

CREATE OR REPLACE FUNCTION schemasye.agregar_enfermedad(
	p_nombre character varying,
	p_descripcion character varying,
	p_fecha_registro date,
	p_fecha_inicio date,
	p_estado boolean,
	p_fecha_actualizacion date)
    RETURNS TABLE(id_enf_cronica integer, nombre character varying, descripcion character varying, fecha_registro date, fecha_inicio date, estado boolean, fecha_actualizacion date) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
    INSERT INTO schemasye."tc_enfermedad_cronica" 
        (nombre, descripcion, fecha_registro, fecha_inicio, estado, fecha_actualizacion)
    VALUES
        (p_nombre, p_descripcion, p_fecha_registro, p_fecha_inicio, p_estado, p_fecha_actualizacion);
END;
$BODY$;

ALTER FUNCTION schemasye.agregar_enfermedad(character varying, character varying, date, date, boolean, date)
    OWNER TO postgres;
