IF (EXISTS (SELECT * FROM sys.databases WHERE name = 'Estacionamento'))
BEGIN
   	USE [Estacionamento];
	IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cliente'))
	BEGIN
	    CREATE TABLE [Cliente] 
	    (
		    [Id] INT  IDENTITY(1,1) NOT NULL
	       ,[NomeCompleto] VARCHAR(250) NOT NULL
	       ,[CpfCnpj] VARCHAR(16) NOT NULL
	       ,[TipoPessoa] CHAR(2) NOT NULL
	       ,[Telefone] VARCHAR(14) NOT NULL
	       ,[Email] VARCHAR(250) NOT NULL
	       ,[Ativo] CHAR(2) NOT NULL
	       ,[DataCadastro] DATETIME  NOT NULL
	       ,[DataAtualizacao] DATETIME NULL
	       ,CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Id])
	       ,CONSTRAINT [CHK_TipoPessoa_Cliente] CHECK ([TipoPessoa] IN ('PF', 'PJ'))
	       ,CONSTRAINT [CHK_Ativo_Cliente] CHECK ([Ativo] IN ('AT', 'IN'))
	    );
	END
	
	IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Veiculo'))
	BEGIN
	        CREATE TABLE [Veiculo]
	        (
		        [Id] INT IDENTITY(1,1) NOT NULL
	           ,[Marca] VARCHAR(100) NULL
	           ,[Modelo] VARCHAR(100) NULL 
	           ,[Ano] VARCHAR(9) NULL 
	           ,[Placa] VARCHAR(20) NOT NULL
	           ,[Cidade] VARCHAR(200) NOT NULL
	           ,[Uf] CHAR(2) NOT NULL
	           ,[ClienteId] INT NOT NULL
	           ,[Ativo] CHAR(2) NOT NULL
	           ,[DataCadastro] DATETIME NOT NULL
	           ,[DataAtualizacao] DATETIME NULL
	           ,CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED ([Id])
	           ,CONSTRAINT [FK_Veiculo_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente]([Id])
	           ,CONSTRAINT [CHK_Ativo_Veiculo] CHECK ([Ativo] IN ('AT', 'IN'))
	        );
	END
	
	IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RegistroEstacionamento'))
	BEGIN
	    CREATE TABLE [RegistroEstacionamento]
	    (
	        [Id] INT IDENTITY(1,1) NOT NULL,
	        [ClienteId] INT NOT NULL,
	        [VeiculoId] INT NOT NULL,
	        [DataEntrada] DATETIME NOT NULL,
	        [DataSaida] DATETIME NULL,
	        [TotalPermanencia] TIME NULL,
	        [Valor] NUMERIC(11,2) NULL,
	        CONSTRAINT [PK_RegistroEstacionamento] PRIMARY KEY CLUSTERED ([Id]),
	        CONSTRAINT [FK_RegistroEstacionamento_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente]([Id]),
	        CONSTRAINT [FK_RegistroEstacionamento_Veiculo] FOREIGN KEY ([VeiculoId]) REFERENCES [dbo].[Veiculo]([Id])
	    );
	END
	
	IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TabelaPreco'))
	BEGIN
	
	    CREATE TABLE [TabelaPreco]
	    (
	        [DescricaoHora] NVARCHAR(50) NOT NULL,
	        [Preco] NUMERIC(11,2) NOT NULL
	    );
	
	    INSERT INTO [TabelaPreco] ([DescricaoHora], [Preco])
	    VALUES  ('Uma_Hora', 15.00),
	            ('Duas_Horas', 20.00),
	            ('Tres_Horas', 25.00),
	            ('Excedente_Fracionada', 5.00),
	            ('Doze_Horas', 30.00),
	            ('Horas_Adicionais', 1.00);
	END

END