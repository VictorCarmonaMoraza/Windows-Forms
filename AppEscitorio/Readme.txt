## 20 -  Utilizando Transaction para administrar procedimientos de insertar datos a la db

 BeginTransactionAsync();   ----->Le decimos que vamos a utilizar transacciones


 CommitTransaction();   ----->Si todo es satisfactorio aceptamos las transacciones


 RollbackTransaction(); ------>Caso no satisfactorio eliminamos la transacion hecha parcialmente