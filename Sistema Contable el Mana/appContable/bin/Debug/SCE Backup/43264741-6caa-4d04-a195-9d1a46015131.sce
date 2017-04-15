----Reset Database----
DELETE FROM UserAccount
GO
DELETE FROM Cuenta
GO
DELETE FROM ComprobanteDiario
GO
DELETE FROM ComprobanteDiarioDetalle
GO

----UsersAccounts----
INSERT INTO UserAccount (IDUser, Reg, FMod, Name, SurnName, UserName, UserPass, Activo ) VALUES ( 'e77e8242-1a4a-48a0-8eda-eeeb3942304c', '2016/11/27 20:51:21','2016/11/27 20:51:21','MICHEL ROBERTO', 'TRAÑA TABLADA', 'admin', 'a2JCEBVkxqfSe7M38L99jRXHmiGPo5xPdLFd0kNu1hR3kE0Ur8ZWNW+sTycWoZZewhqqJZTb4PLp2fEB0JXuo97I8NSs0VxnzcuZWNjUuu0jR10k2sh1eEcWfXuYd9R64YWK4f4gPk2DfQojMhyvnrUW6pqbEt5K/jJtAJuQ/PE=', 1)
GO

----Cuenta----

----ComprobanteDiario----

----ComprobanteDiarioDetalle----
