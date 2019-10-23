-- SENTENCIAS SQL (Structur Query Language)
-- Agregar registros (Insert Into)
Insert Into producto
Values('P001','Laptop',2500,10,1)
Insert Into producto
Values('P002','Mouse',50,100,1)

Insert Into cliente 
Values('123','Juan','Perez','Rojas','10/05/1990',1)
Insert Into cliente 
Values('456','Ana','Sosa','Lopez','20/07/2000',0)

Insert Into venta
Values('V001','28/11/18',800,'123')

-- Listado de registros
Select *from producto
Select *from cliente 
Select *from venta

Update producto set stock = stock + 4 where id= 'P001'