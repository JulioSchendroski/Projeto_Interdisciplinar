-- BADC5, IFSP-PRC, 2022
-- Davi Trost Gouveia 		PC3010741
-- Mateus Augusto Viotto	PC3008967
-- Filipe Gomes Cruvinel 	PC3008797
-- Júlio César Schendroski 	PC3010597
-- Pedro Barriviera		PC3010155



-- Instrucoes basicas:
-- Nomear o script como GrupoX.sql (onde X e' tema do grupo)
-- Seguir rigorosamente a sintaxe do PostgreSQL
-- Este script precisa ser escrito de modo que possa ser executado completamente sem apresentar erros

-- ----------------------------
-- ✔[1] ESQUEMAS
-- Criacao de pelo menos 1 esquema
-- Nesse(s) esquema(s) serao criados: tabelas, visoes, funcoes, procedimentos, gatilhos, sequencias etc (vide secoes seguintes)
create schema tb;
create schema vw;

-- ----------------------------

-- [2] TABELAS
-- Criacao das tabelas e de suas restricoes (chaves primarias, unicidades, valores padrao, checagem e nao nulos)
-- Pelo menos 1 UNIQUE, 1 DEFAULT, 1 CHECK
-- Definicao das chaves estrangeiras das tabelas com acoes referenciais engatilhadas
-- As restricoes criadas com ALTER TABLE devem aparecer logo apos a tabela correspondente

create table tb.pessoa(
 	p_matricula bigint,
 	p_nome varchar(100) unique not null,
 	p_depto_cod bigint,
 	p_status varchar(10) default 'ativo',
 	p_cargo varchar(15),
 	constraint pessoa_pk primary key(p_matricula),
 	constraint p_status_ck check((p_status = 'ativo') or (p_status = 'inativo')),
 	constraint p_cargo_ck check((p_cargo = 'diretor') or (p_cargo = 'gerente') or (p_cargo = 'funcionário'))
 );

 create table tb.departamento(
 	d_codigo bigint,
 	d_nome varchar(100) not null,
 	d_descricao text,
 	constraint departamento_pk primary key(d_codigo)
 );

 create table tb.ocorrencia(
 	o_numero serial,
 	o_status_temp varchar(10) default 'aberta',
 	o_status_def varchar(10) default 'aberta',
 	o_data date,
 	o_descricao text,
 	o_matricula_func bigint,
 	o_depto_cod bigint,
 	constraint ocorrencia_pk primary KEY(o_numero),
 	constraint o_status_temp_ck check((o_status_temp = 'aberta') or (o_status_temp = 'encerrada')),
 	constraint o_status_def_ck check((o_status_def = 'aberta') or (o_status_def = 'encerrada')),
 	constraint o_data_ck check(o_data <= current_date)
 );

-- NOTA == ALTER TABLE esquema.nometabela1 ADD CONSTRAINT...



-- ----------------------------
-- [3] CARGA DE DADOS
-- 100 tuplas no total e identificar quem fez as insercoes

-- 20 INSERTs - Davi Trost Gouveia
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (1,'Sienna Grande Corte-Real','diretor');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (2,'Kimberly Valério Barrocas','inativo','diretor');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (3,'Kamila Aleixo Alcântara','inativo','diretor');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (4,'Aléxis Arouca Ferraz',1,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (5,'Deivid Beiriz Protásio',2,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (6,'Iasmin Pestana Poças',3,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (7,'Francis Vilante Monteiro',4,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (8,'Lilian Souto Onofre','inativo',2,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (9,'Alice Fialho Goulão','inativo',1,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (10,'Maia Coutinho Albernaz','inativo',4,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (11,'Lorenzo Canto Cedro','inativo',3,'gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (12,'Ticiana Faustino Martins',1,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (13,'Yi Caparica Oleiro',1,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (14,'Lana Hipólito Estrada',1,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (15,'Eliza Boeira Rego',1,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (74,'Raul Figueiroa Sintra','inativo',4,'funcionário');
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (2, 'Departamento Financeiro', 'O departamento financeiro é responsável por administrar todos os recursos de uma empresa. Sua função é exercer controle no fluxo de caixa, arantindo uma boa gestão sobre as despesas, receitas, repasse de recursos e demais movimentações financeiras.');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('15/05/2017','DD/MM/YYYY'),'Backup setor de informática',69,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('02/07/2017','DD/MM/YYYY'),'Averiguar falta de internet no setor financeiro',76,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('11/08/2017','DD/MM/YYYY'),'Gerar folha de pagamento para todos os setores',32,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('11/09/2017','DD/MM/YYYY'),'Gerar folha de pagamento para todos os setores',32,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('09/10/2017','DD/MM/YYYY'),'Gerar relatório das finanças no setor comercial',18,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('11/10/2017','DD/MM/YYYY'),'Gerar folha de pagamento para todos os setores',32,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('06/11/2017','DD/MM/YYYY'),'Gerar relatório de salários pagos no semestre',19,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('11/11/2017','DD/MM/YYYY'),'Gerar folha de pagamento para todos os setores',32,1);

-- 20 INSERTs - Mateus Augusto Viotto
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (16,'Natacha Sacadura Gravato',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (17,'Amélia Veríssimo Sodré',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (18,'Isís Tomé Robalo',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (19,'Irís Salgueiro Almada',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (20,'Marcus Calçada Campos',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (21,'Max Vilanova Bugalho',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (22,'Rodolfo Bezerril Nascimento',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (23,'Zoe Quental Rolim',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (24,'Ticiana Bingre Jordão',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (25,'Petra Noleto Furtado',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (26,'Mellanie Assunção Batata',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (27,'Bianca Varela Caniça',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (28,'Quessia Malho Valente',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (29,'Nilo Baldaia Malafaia',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (30,'Damien Belchiorinho Lustosa',2,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (75,'Dominique Carreiro Canela','inativo',4,'funcionário');
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (3, 'Departamento Comercial', 'Rsponsável pelas atividades de venda da empresa, desde as estratégias de divulgação dos produtos ou serviços até a prospecção e fidelização de clientes.');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('11/11/2017','DD/MM/YYYY'),'Resolver problemas de rede no setor financeiro',59,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('11/12/2017','DD/MM/YYYY'),'Gerar folha de pagamento para todos os setores',32,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('10/01/2018','DD/MM/YYYY'),'Gerar relatório das finanças no setor comercial',21,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('29/03/2018','DD/MM/YYYY'),'Gerar relatório das finanças no ano',29,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('02/06/2018','DD/MM/YYYY'),'Backup setor administrativo',70,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('05/06/2018','DD/MM/YYYY'),'Backup setor financeiro',71,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('08/06/2018','DD/MM/YYYY'),'Backup setor comercial',72,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('15/06/2018','DD/MM/YYYY'),'Backup setor de informática',73,4);

-- 20 INSERTs - Filipe Gomes Cruvinel
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (31,'Azael Letras Reis',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (32,'Dânia Cardoso Toste',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (33,'Éder Bandeira Mesquita',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (34,'Catalina Redondo Quadros',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (35,'Zilda Afonso Espinosa',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (36,'Pandora Pastana Custódio',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (37,'Irina Alcoforado Avelar',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (38,'Yara Brião Onofre',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (39,'Lui Meira Farias',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (40,'Milena Macieira Mondragão',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (41,'Viriato Maciel Valadim',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (42,'Melânia Teixeira Cantanhede',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (43,'Rahyssa Taveira Gouveia',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (44,'Jeremias Olaio Barroqueiro',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (76,'Santiago Castro Ventura','inativo',4,'funcionário');
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (4, 'Departamento de Informatica','Responsável pela criação de redes e manutenção dos computadores.');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('08/05/2017','DD/MM/YYYY'),'Backup setor comercial',67,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('aberta','aberta' ,to_date('13/11/2018','DD/MM/YYYY'),'Gerar folha de pagamento para todos os setores',28,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('28/11/2018','DD/MM/YYYY'),'Gerar relatório de salários pagos no semestre',21,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('15/04/2019','DD/MM/YYYY'),'Gerar relatório de lucro no semestre',18,3);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('29/05/2019','DD/MM/YYYY'),'Resolver problemas de rede no setor administrativo',60,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('29/06/2019','DD/MM/YYYY'),'Resolver problemas de rede no setor administrativo',60,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('01/11/2019','DD/MM/YYYY'),'Gerar relatório das finanças no ano',18,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('13/11/2019','DD/MM/YYYY'),'Gerar relatório de lucro no semestre',23,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('03/02/2020','DD/MM/YYYY'),'Gerar relatório das finanças no setor comercial',19,2);

-- 20 INSERTs - Júlio César Schendroski
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (45,'Ruben Cesário Colares',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (46,'Felipe Moreira Lopes',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (47,'Samuel Vasques Brião',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (48,'India Casalinho Castro',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (49,'Nélson Camilo Gomes',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (50,'Fedra Canejo Fitas',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (51,'Anthony Quirino Rebotim',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (52,'Yannick Maior Salvado',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (53,'Heitor Brochado Corte-Real',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (54,'Flor Morgado Albernaz',3,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (55,'Martinha Damásio Ventura',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (56,'Jóni Alcoforado Mourão',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (57,'Amanda Tinoco Pereira',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (58,'Oceana Goulão Tabosa',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (59,'Anselmo Rijo Morão',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_depto_cod, p_cargo) VALUES (77,'Helena Chainho Leão','inativo',4,'funcionário');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('02/05/2017','DD/MM/YYYY'),'Backup setor administrativo',65,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('aberta','aberta' ,to_date('09/07/2020','DD/MM/YYYY'),'Gerar relatórios de compras ssd',21,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('07/11/2020','DD/MM/YYYY'),'Gerar relatório de salários pagos no semestre',17,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('28/11/2020','DD/MM/YYYY'),'Gerar relatório de salários pagos no semestre',21,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('31/01/2021','DD/MM/YYYY'),'Gerar relatório das finanças no setor comercial',22,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('13/04/2021','DD/MM/YYYY'),'Gerar relatório de lucro no semestre',16,3);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('17/05/2021','DD/MM/YYYY'),'Gerar relatório das finanças no ano',29,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('20/06/2021','DD/MM/YYYY'),'Relatório de vendas',39,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('12/08/2021','DD/MM/YYYY'),'Relatório de vendas',40,4);

-- 20 INSERTs - Pedro Barriviera
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (60,'Karina Medina Caparica',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (61,'Leonor Brites Reis',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (62,'Daiana Ferro Sabala',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (63,'Elisa Bulhosa Paz',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (64,'Heloísa Valverde Franca',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (65,'Michele Guedelha Padilha',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (66,'Adriel Lucas Boto',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (67,'Mickael Alpuim Tavares',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (68,'Joshua Janes Rios',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (69,'Nilson Abrantes Doutis',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (70,'Enoque Teves Infante',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (71,'Lívia Martinho Varanda',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (72,'Amina Atilano Guerreiro',4,'funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_depto_cod, p_cargo) VALUES (73,'Evelina Barroso Alves',4,'funcionário');
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (1, 'Departamento Administrativo', 'Lidera os demais setores e coordená-los para que haja alinhamento entre eles a fim de alcançar os resultados desejados pela empresa.');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('02/05/2017','DD/MM/YYYY'),'Backup setor administrativo',65,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('05/05/2017','DD/MM/YYYY'),'Backup setor financeiro',66,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('01/12/2021','DD/MM/YYYY'),'Gerar relatório das finanças no ano',17,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('22/12/2021','DD/MM/YYYY'),'Gerar relatório das finanças no setor comercial',20,2);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('08/02/2022','DD/MM/YYYY'),'Relatório de vendas',37,3);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('aberta','aberta' ,to_date('08/03/2022','DD/MM/YYYY'),'Resolver problemas de rede no setor comercial',55,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('06/04/2022','DD/MM/YYYY'),'Gerar relatório de salários pagos no semestre',20,1);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('encerrada','encerrada' ,to_date('18/04/2022','DD/MM/YYYY'),'Relatório de vendas',38,3);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('aberta','aberta' ,to_date('05/06/2022','DD/MM/YYYY'),'Colocar ssd em todas a maquinas do setor adiministrativo',57,4);
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_descricao, o_matricula_func, o_depto_cod) VALUES ('aberta','aberta' ,to_date('07/06/2022','DD/MM/YYYY'),'Configurar sub-rede do departamento financairo',73,4);

-- UPDATEs possivelmente necessarios nas linhas abaixo:


-- -----------------------
-- [4] CONSULTAS
-- Alem do comando SELECT correspondente, fornecer o que se pede

-- Seleciona todos os funcionários ordenando pelo status e departamento
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_cargo =
'funcionário' ORDER BY
p_status DESC, d_nome ASC;

-- Seleciona todos as pessoas inativas por departamento
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'inativo' ORDER BY
 p_cargo DESC;

-- Seleciona todos as pessoas ativas por departamento
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'ativo' ORDER BY
 p_cargo DESC, d_nome;

-- Seleciona todos os gerentes ordenando pelo status e departamento
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_cargo = 'gerente' ORDER BY
p_status DESC, d_nome ASC;

-- Seleciona todos os diretores
select p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa 
where p_cargo = 'diretor' ORDER BY
p_status DESC;

-- Seleciona todos os diretores ativos
select p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa 
where p_cargo = 'diretor' and p_status = 'ativo' ORDER BY
p_status DESC;

-- Seleciona todos os diretores inativos
select p_nome as Nome, p_status as Status, p_cargo as Cargo from tb.pessoa 
where p_cargo = 'diretor' and p_status = 'inativo' ORDER BY p_status DESC;

-- Seleciona todos as pessoas ativas no departamento Administrativo
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'ativo' and d_codigo = 1 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas ativas no departamento Financeiro
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'ativo' and d_codigo = 2 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas ativas no departamento Comercial
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'ativo' and d_codigo = 3 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas ativas no departamento de informática
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'ativo' and d_codigo = 4 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas inativas no departamento Administrativo
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'inativo' and d_codigo = 1 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas inativas no departamento Financeiro
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'inativo' and d_codigo = 2 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas inativas no departamento Comercial
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'inativo' and d_codigo = 3 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos as pessoas inativas no departamento de informática
select p_nome as Nome, p_status as Status, p_cargo as Cargo, d_nome as Departamento from tb.pessoa 
inner join tb.departamento on (p_depto_cod = d_codigo) where p_status = 'inativo' and d_codigo = 4 ORDER BY
 p_cargo DESC, d_nome;
 
 -- Seleciona todos os departamentos
select d_codigo as codigo, d_nome as nome, d_descricao as descrição from tb.departamento order by d_codigo ASC;
 
--Seleciona todas as ocorrencias
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
order by o_status_def DESC, o_status_temp DESC, o_data ASC, d_nome ASC;

--Seleciona todas as ocorrencias definitivamente encerradas
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where o_status_def = 'encerrada'
order by o_data ASC, d_nome ASC;

--Seleciona todas as ocorrencias temporariamente encerradas para encerrar definitivamente
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo 
inner join tb.pessoa on p_matricula = o_matricula_func where o_status_def = 'aberta' and o_status_temp = 'encerrada'
order by o_data ASC, d_nome ASC;

--Seleciona todas as ocorrencias abertas
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo 
inner join tb.pessoa on p_matricula = o_matricula_func where o_status_def = 'aberta' 
order by o_data ASC, d_nome ASC;

--Seleciona todas as ocorrencias do departamento Administrativo
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where o_depto_cod = 1
order by o_status_def DESC, o_status_temp DESC, o_data ASC;

--Seleciona todas as ocorrencias do departamento Financeiro
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where o_depto_cod = 2
order by o_status_def DESC, o_status_temp DESC, o_data ASC;

--Seleciona todas as ocorrencias do departamento Comercial
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where o_depto_cod = 3
order by o_status_def DESC, o_status_temp DESC, o_data ASC;

--Seleciona todas as ocorrencias do departamento de informática
select o_numero as ID, o_data as data, o_status_temp 
as status_temporário, o_status_def as status_definitivo, o_descricao 
as descrição,p_nome as funcionário,d_nome as departamento from tb.ocorrencia 
inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func where o_depto_cod = 4
order by o_status_def DESC, o_status_temp DESC, o_data ASC;


-- [4.1] Listagem
-- Usar jun''o('es) (JOINs), filtro(s) (WHERE), ordena''o (ORDER BY)
-- Enunciado: 
-- Importancia na aplicacao: 
-- Usuario(s) atendido(s): 
-- Apague esta linha e redija a consulta SQL aqui


-- [4.2] Relatorio
-- Usar jun''o('es) (JOINs), filtro(s) (WHERE), agrupamento (GROUP BY) e fun''o de agregacao (count, sum, avg, etc)
-- Enunciado: 
-- Importancia na aplicacao: 
-- Usuario(s) atendido(s): 
-- Apague esta linha e redija a consulta SQL aqui



-- -------------------------
-- [5] VISOES


-- [5.1] Visao
-- A visao deve ter, no minimo, as caracteristicas de 4.1
-- Enunciado: 
-- Importancia na aplicacao: 
-- Usuario(s) atendido(s): 


-- [5.2] Consulta na visao
-- Consultar a visao criada em 5.1 realizando filtro(s) (WHERE)
-- Enunciado: 
-- Importancia na aplicacao: 
-- Usuario(s) atendido(s): 


-- [5.3] Visao materializada
-- A visao deve ter, no minimo, as caracteristicas de 4.2
-- Enunciado: 
-- Importancia na aplicacao: 
-- Usuario(s) atendido(s): 


-- [5.4] Consulta na visao materializada
-- Consultar a visao criada em 4.2 realizando filtro(s) (WHERE)
-- Enunciado: 
-- Importancia na aplicacao: 
-- Usuario(s) atendido(s): 


-- [5.5] Atualizacao da visao materializada
-- Comente brevemente sobre a necessidade de atualizacao e qual seria a frequencia/periodicidade
-- Redija o comando REFRESH correspondente





-- ---------------------------------------------
-- [6] DESEMPENHO DO PROCESSAMENTO DAS CONSULTAS
-- Primeiro analise o desempenho das suas consultas 4.1., 4.2, 5.2 e 5.4, verificando custo e tempo das operacoes
-- Depois de analisa-las, comente a necessidade da criacao ou nao de um indice e justifique a escolha pelo tipo de indice.
-- Selecione uma dentre essas consultas (a mais importante delas) e apresente aquilo que se pede abaixo.

-- [6.1] EXPLAIN 

 /*Sort  (cost=25.37..25.38 rows=1 width=356)
   Sort Key: ocorrencia.o_data, departamento.d_nome
   ->  Nested Loop  (cost=16.56..25.36 rows=1 width=356)
         ->  Hash Join  (cost=16.41..18.48 rows=1 width=146)
               Hash Cond: (pessoa.p_matricula = ocorrencia.o_matricula_func)
               ->  Seq Scan on pessoa  (cost=0.00..1.77 rows=77 width=30)
               ->  Hash  (cost=16.38..16.38 rows=3 width=132)
                     ->  Seq Scan on ocorrencia  (cost=0.00..16.38 rows=3 width=132)
                           Filter: ((o_status_def)::text = 'aberta'::text)
         ->  Index Scan using departamento_pk on departamento  (cost=0.15..6.83 rows=1 width=226)
               Index Cond: (d_codigo = ocorrencia.o_depto_cod)*/



-- [6.2] EXPLAIN ANALYZE

 /*Sort  (cost=25.37..25.38 rows=1 width=356) (actual time=0.073..0.074 rows=5 loops=1)
   Sort Key: ocorrencia.o_data, departamento.d_nome
   Sort Method: quicksort  Memory: 26kB
   ->  Nested Loop  (cost=16.56..25.36 rows=1 width=356) (actual time=0.034..0.043 rows=5 loops=1)
         ->  Hash Join  (cost=16.41..18.48 rows=1 width=146) (actual time=0.028..0.034 rows=5 loops=1)
               Hash Cond: (pessoa.p_matricula = ocorrencia.o_matricula_func)
               ->  Seq Scan on pessoa  (cost=0.00..1.77 rows=77 width=30) (actual time=0.004..0.007 rows=77 loops=1)
               ->  Hash  (cost=16.38..16.38 rows=3 width=132) (actual time=0.016..0.017 rows=5 loops=1)
                     Buckets: 1024  Batches: 1  Memory Usage: 9kB
                     ->  Seq Scan on ocorrencia  (cost=0.00..16.38 rows=3 width=132) (actual time=0.011..0.012 rows=5 loops=1)
                           Filter: ((o_status_def)::text = 'aberta'::text)
                           Rows Removed by Filter: 39
         ->  Index Scan using departamento_pk on departamento  (cost=0.15..6.83 rows=1 width=226) (actual time=0.001..0.001 rows=1 l
oops=5)
               Index Cond: (d_codigo = ocorrencia.o_depto_cod)
 Planning Time: 0.103 ms
 Execution Time: 0.092 ms*/



-- [6.3] Comentarios e justificativas para o indice 
-- Considerar custo e tempo das operacoes, por exemplo
-- comente e justifique nesta linha


-- [6.4] CREATE INDEX e PARAMETROS (Set)
-- Crie o indice, verifique se o indice ja esta sendo usado no processamento da consulta e, caso nao esteja, ajuste os parametros
-- apague esta linha e redija os comandos




-- ---------------------------------------------
-- [7] FUNCOES INTERNAS
-- Usar funcoes internas nas operacoes em tabelas do banco de dados

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Redigir abaixo o SELECT (apagar esta linha)

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Redigir abaixo o INSERT (apagar esta linha)

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Redigir abaixo o UPDATE (apagar esta linha)

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Redigir abaixo o DELETE (apagar esta linha)





-- ---------------------------------------------
-- [8] USER-DEFINED FUNCTION (UDF)
-- Vislumbrar a cria''o de uma fun''o (UDF) para o banco de dados.
-- Comentar a utilidade da funcao na aplicacao.
-- Redigir o comando CREATE OR REPLACE FUNCTION correspondente usando PL/pgSQL.
-- Redigir um comando SQL que chame a funcao, explicando o que sua chamada faz.
-- A funcao devera' ter parametro(s).


-- Comentar aqui a utilidade da funcao na aplicacao 
-- CREATE OR REPLACE FUNCTION abaixo (apagar esta linha)

-- Explicar aqui o que a chamada abaixo faz
-- SELECT ou INSERT ou UPDATE ou DELETE abaixo para chamar a funcao (apagar esta linha)



-- ---------------------------------------------
-- [9] STORED PROCEDURE
-- Vislumbrar a cria''o de um procedimento armazenado para o banco de dados.
-- Comentar a utilidade do procedimento na aplicacao.
-- Redigir o comando CREATE OR REPLACE PROCEDURE correspondente usando PL/pgSQL.
-- Redigir um comando SQL que chame o procedimento, explicando o que sua chamada faz.
-- O procedimento devera' ter parametro(s).

-- Comentar a utilidade do procedimento na aplicacao aqui
-- CREATE OR REPLACE PROCEDURE abaixo (apagar esta linha)


-- Explicar aqui o que a chamada abaixo faz
-- chamar aqui o procedimento (apagar essa linha)



-- ---------------------------------------------
-- [10] TRIGGER
-- Revisar as aplica''es em potencial para bancos de dados ativos (e gatilhos).
-- Vislumbrar a cria''o de um gatilho e de uma fun''o engatilhada para o banco de dados.
-- Se necessario redigir logo abaixo outros comandos SQL necessarios (criacao de coluna, atualizacao de tuplas etc):


-- [10.1] ROW
-- Comentar aqui a utilidade, para a aplicacao, do gatilho em nivel de tupla e da sua funcao engatilhada.

-- Redigir o comando CREATE OR REPLACE FUNCTION correspondente usando PL/pgSQL


-- Redigir o comando CREATE TRIGGER correspondente ao gatilho em nivel de tupla usando PL/pgSQL


-- Redigir pelo menos 1 comando SQL que dispare o gatilho em nivel de tupla
-- Descrever o que acontece no banco de dados quando e' disparado


-- Se necessario para executar os comandos seguintes, remover o gatilho de 10.1 abaixo:



-- [10.2] STATEMENT
-- Comentar aqui a utilidade, para a aplicacao, do gatilho em nivel de sentenca e da sua funcao engatilhada.
-- Redigir o comando CREATE OR REPLACE FUNCTION correspondente usando PL/pgSQL


-- Redigir o comando CREATE TRIGGER correspondente ao gatilho em nivel de sentenca usando PL/pgSQL


-- Redigir pelo menos 1 comando SQL que dispare o gatilho em nivel de sentenca
-- Descrever o que acontece no banco de dados quando e' disparado






-- ---------------------------------------------
-- [11] SEGURANCA
-- Nao sera incluida aqui
-- Usar/entregar o modelo especifico


-- [11.1] ACESSO REMOTO (pg_hba.conf)
-- Cole nas linhas abaixo o conteudo do arquivo pg_hba.conf que o servidor deve conter, iniciando cada linha com comentario '--' (para nao impedir a execucao desse script); apague esta linha


-- [11.2] PAPEIS (Roles)
-- Criar papeis de usuarios e de grupos
-- Nessa criacao, considerar tanto papeis da equipe (administracao/desenvolvimento) quanto papeis de usuarios da aplicacao
-- Para cada papel criado adicionar um comentario antes explicando qual e' a utilidade dele na aplicacao

CREATE ROLE superadm WITH SUPERUSER;
CREATE ROLE adm WITH LOGIN PASSWORD 'ifspadm';
CREATE ROLE funcionario WITH LOGIN PASSWORD 'ifspfuncionario';
CREATE ROLE gerente WITH LOGIN PASSWORD 'ifspgerente';
CREATE ROLE diretor WITH LOGIN PASSWORD 'ifspdiretor';


-- [11.3] PRIVILEGIOS DE ACESSO (Grant)

GRANT CONNECT ON DATABASE ocorrenciascpd TO funcionario, gerente, diretor;

-- [11.3.1]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) criar o(s) esquema(s) da Secao 1
-- Usuario(s) podem conceder esse acesso alem do superusuario:adm

GRANT CREATE ON DATABASE ocorrenciascpd TO adm;

-- [11.3.2]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) criar a(s) tabela(s), as sequencias e as restricoes da Secao 2 e as visoes da Secao 5
-- Usuario(s) podem conceder esse acesso alem do superusuario: adm
GRANT USAGE ON SCHEMA tb, vw TO adm;
GRANT SELECT, INSERT, UPDATE ON TABLE tb.pessoa, tb.ocorrencia, tb.departamento TO adm;

-- [11.3.3]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) inserir e atualizar tuplas, conforme a Secao 3
-- Usuario(s) podem conceder esse acesso alem do superusuario: diretor, gerente

GRANT USAGE ON SCHEMA tb TO gerente,diretor,funcionario;

GRANT SELECT, INSERT, UPDATE ON TABLE tb.pessoa, tb.ocorrencia TO gerente;
GRANT SELECT, INSERT, UPDATE ON TABLE tb.departamento TO diretor;



-- [11.3.4]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) executar as consultas das Secoes 4 e 5
-- Usuario(s) podem conceder esse acesso alem do superusuario:funcionario
-- Apagar essa linha e adicionar os comandos necessarios


GRANT SELECT, UPDATE ON TABLE tb.ocorrencia TO funcionario;


-- [11.3.5]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) executar os comandos da Secao 7
-- Usuario(s) podem conceder esse acesso alem do superusuario: citar aqui
-- Apagar essa linha e adicionar os comandos necessarios


-- [11.3.6]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) executar as subrotinas das Secoes 8, 9 e 10
-- Assegurar tambem os privilegios para executar os comandos que realizam as chamadas (ou disparos) daquelas subrotinas
-- Usuario(s) podem conceder esse acesso alem do superusuario: citar aqui
-- Apagar essa linha e adicionar os comandos necessarios




-- [11.4] PRIVILEGIOS DE ACESSO (Revoke)

-- [11.4.1]
-- Revogar o acesso em 11.3.1 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm
REVOKE CREATE ON DATABASE ocorrenciascpd FROM adm;

-- [11.4.2]
-- Revogar o acesso em 11.3.2 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm
REVOKE USAGE ON SCHEMA tb FROM adm;

-- [11.4.3]
-- Revogar o acesso em 11.3.3 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: diretor
REVOKE SELECT, INSERT, UPDATE ON TABLE tb.departamento FROM diretor;

-- [11.4.4]
-- Revogar o acesso em 11.3.4 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: funcionario
REVOKE SELECT, UPDATE ON TABLE tb.ocorrencia FROM funcionario;

-- [11.4.5]
-- Revogar o acesso em 11.3.5 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm
-- Apague esta linha e redija o comando aqui

-- [11.4.6]
-- Revogar o acesso em 11.3.6 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm
-- Apague esta linha e redija o comando aqui


-- Se for necessario para executar os comandos seguintes, assegure novamente os privilegios de acesso revogados acima
GRANT CREATE ON DATABASE ocorrenciascpd TO adm;
GRANT USAGE ON SCHEMA tb TO adm;
GRANT SELECT, INSERT, UPDATE ON TABLE tb.departamento TO diretor;
GRANT SELECT, UPDATE ON TABLE tb.ocorrencia TO funcionario;


-- ---------------------------------------------
-- [12] TRANSACOES
-- Nao incluir aqui
-- Usar/entregar o modelo proprio para esse topico








