--1. Query: 5 clientes mais recentes
SELECT TOP 5 *
FROM Clientes
ORDER BY DataCadastro DESC;

--2. Stored Procedure: Pedidos por cliente
CREATE PROCEDURE sp_ObterPedidosPorCliente
    @ClienteId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT *
    FROM Pedidos
    WHERE Id = @ClienteId
    ORDER BY DataPedido DESC;
END;

--3. Atualizar e-mail de um cliente por ID
UPDATE Clientes
SET Email = 'email@email.com'
WHERE Id = 'bdd82b49-0085-41e4-8df0-f7c034f9f99a';

--4. View: Nome do cliente, total de pedidos e total gasto
CREATE VIEW vw_ResumoClientes AS
SELECT 
    c.Nome AS NomeCliente,
    COUNT(p.Id) AS TotalPedidos,
    COALESCE(SUM(p.ValorTotal), 0) AS ValorTotalGasto
FROM Clientes c
LEFT JOIN Pedidos p ON c.Id = p.ClienteId
GROUP BY c.Nome;
