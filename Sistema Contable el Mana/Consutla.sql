select * from comprobantediario
go


update ComprobanteDiario set Fecha = '2016-05-30 10:26:40' where IDComprobante = '4226D666-2E2F-4036-91C5-EE81FFBE35D6'
go

update Cuenta set deber = 0, haber = 0, saldo = 0
go

delete from ComprobanteDiarioDetalle
go

delete from ComprobanteDiario
go

select * from cuenta
go