create database myfinance

use myfinance 

create table planoconta(
    id int identity(1,1) not null,
    nome varchar(50) not null,
    tipo char(1) not null,
    primary key (id)
);

create table transacao(
    id int identity(1,1) not null,
    historico varchar(100) null,
    data datetime null,
    valor decimal(9,2),
    planocontaid int not null,
    primary key (id),
    foreign key (planocontaid) references planoconta(id)
);

INSERT INTO planoconta (nome, tipo) VALUES ('Combustível', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Alimentação', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Saúde', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Manutenção Carro', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Viagens', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Salário', 'R');
INSERT INTO planoconta (nome, tipo) VALUES ('Juros Recebidos', 'R');
INSERT INTO planoconta (nome, tipo) VALUES ('Créditos de Dividendos', 'R');
INSERT INTO planoconta (nome, tipo) VALUES ('Restituição de IR', 'R');

select * from planoconta

SET DATEFORMAT dmy;
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Combustível Blazer', getdate(), 487,11);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Almoço de Domingo', '18-05-2025 12:00', 150, 2);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Peças da Blazer', '10-05-2025 03:00', 18000, 4);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Salário', '12-05-2025 10:00', 10000, 6);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('ITAUSA', '14-05-2025 18:00', 678, 8);

SELECT * FROM transacao;