SELECT -- TOP 1
	ComprobanteDiario.N AS NDoc,
	ComprobanteDiarioDetalle.N,
	Cuenta.Nivel,
	Cuenta.Grupo + ' ' + Cuenta.SubGrupo + ' ' + Cuenta.Mayor + ' ' + Cuenta.SubMayor + ' ' + Cuenta.SubSubMayor + ' ' + Cuenta.UltimoNivel,
	Cuenta.Descripcion,
	ComprobanteDiario.Fecha,
	ComprobanteDiarioDetalle.DeberGrupo,
	ComprobanteDiarioDetalle.HaberGrupo,
	ComprobanteDiarioDetalle.SaldoGrupo,
	ComprobanteDiarioDetalle.DeberSubGrupo,
	ComprobanteDiarioDetalle.HaberSubGrupo,
	ComprobanteDiarioDetalle.SaldoSubGrupo,
	ComprobanteDiarioDetalle.DeberMayor,
	ComprobanteDiarioDetalle.HaberMayor,
	ComprobanteDiarioDetalle.SaldoMayor,
	ComprobanteDiarioDetalle.DeberSubMayor,
	ComprobanteDiarioDetalle.HaberSubMayor,
	ComprobanteDiarioDetalle.SaldoSubMayor,
	ComprobanteDiarioDetalle.DeberSubSubMayor,
	ComprobanteDiarioDetalle.HaberSubSubMayor,
	ComprobanteDiarioDetalle.SaldoSubSubMayor,
	ComprobanteDiarioDetalle.DeberUltimoNivel,
	ComprobanteDiarioDetalle.HaberUltimoNivel,
	ComprobanteDiarioDetalle.SaldoUltimoNivel,
	ComprobanteDiarioDetalle.Deber,
	ComprobanteDiarioDetalle.Haber
FROM
	Cuenta
	INNER JOIN ComprobanteDiarioDetalle ON Cuenta.IdCuenta = ComprobanteDiarioDetalle.IdCuenta
	INNER JOIN ComprobanteDiario ON ComprobanteDiario.IDComprobante = ComprobanteDiarioDetalle.IDComprobante
WHERE
	--ComprobanteDiarioDetalle.IDCuentaMayor = '8b0ef7fd-c425-45d7-a8cc-553179f27864' AND
	--ComprobanteDiario.Fecha <= '2016-05-09' AND
	ComprobanteDiario.Activo = 1
ORDER BY ComprobanteDiarioDetalle.N DESC
GO