DELETE FROM CUENTA
GO

INSERT INTO CUENTA(
	   [IDCuenta]
      ,[Reg]
      ,[FMod]
      ,[Nivel]
      ,[IDCuentaGrupo]
      ,[CodigoSuperior]
      ,[IdGrupo]
      ,[Grupo]
      ,[IdSubGrupo]
      ,[SubGrupo]
      ,[IdMayor]
      ,[Mayor]
      ,[IdSubMayor]
      ,[SubMayor]
      ,[IdSubSubMayor]
      ,[SubSubMayor]
      ,[IdUltimoNivel]
      ,[UltimoNivel]
      ,[Descripcion]
      ,[Naturaleza]
      ,[Operacion]
      ,[Deber]
      ,[Haber]
      ,[Saldo]
	  ,[IsProduct]
	  ,[Entrada]
	  ,[Salida]
	  ,[Existencia]
	  ,[Costo]
      ,[Activo]
)
SELECT [IDCuenta]
      ,[Reg]
      ,[FMod]
      ,[Nivel]
      ,[IDCuentaGrupo]
      ,[CodigoSuperior]
      ,[IdGrupo]
      ,[Grupo]
      ,[IdSubGrupo]
      ,[SubGrupo]
      ,[IdMayor]
      ,[Mayor]
      ,[IdSubMayor]
      ,[SubMayor]
      ,[IdSubSubMayor]
      ,[SubSubMayor]
      ,[IdUltimoNivel]
      ,[UltimoNivel]
      ,[Descripcion]
      ,[Naturaleza]
      ,[Operacion]
      ,0.0
      ,0.0
      ,0.0
	  ,0
	  ,0.0
	  ,0.0
	  ,0.0
	  ,0.0
      ,[Activo]
FROM
	[dbContable_10-09-2016].[dbo].[Cuenta]
ORDER BY N
GO

UPDATE
	CUENTA
SET
	Deber = 0,
	Haber = 0,
	Saldo = 0
GO