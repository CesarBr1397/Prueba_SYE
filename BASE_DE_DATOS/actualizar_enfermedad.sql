-- FUNCTION: schemasye.actualizar_enfermedad(integer, character varying, character varying, date, date, boolean, date)

-- DROP FUNCTION IF EXISTS schemasye.actualizar_enfermedad(integer, character varying, character varying, date, date, boolean, date);

CREATE OR REPLACE FUNCTION schemasye.actualizar_enfermedad(
	p_id_enf_cronica integer,
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
    UPDATE schemasye."tc_enfermedad_cronica" AS ec
    SET 
        nombre = p_nombre,
        descripcion = p_descripcion,
        fecha_inicio = p_fecha_inicio,
        fecha_registro = p_fecha_registro,
        estado = p_estado,
        fecha_actualizacion = p_fecha_actualizacion
    WHERE ec.id_enf_cronica = p_id_enf_cronica;
END;
$BODY$;

ALTER FUNCTION schemasye.actualizar_enfermedad(integer, character varying, character varying, date, date, boolean, date)
    OWNER TO postgres;
