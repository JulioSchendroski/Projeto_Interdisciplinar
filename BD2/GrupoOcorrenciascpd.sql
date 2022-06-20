-- BADC5, IFSP-PRC, 2022
-- Davi Trost Gouveia 		PC3010741
-- Filipe Gomes Cruvinel 	PC3008797
-- Júlio César Schendroski 	PC3010597
-- Mateus Augusto Viotto	PC3008967
-- Pedro Barriviera			PC3010155



-- Instrucoes basicas:
-- Nomear o script como GrupoX.sql (onde X e' tema do grupo)
-- Seguir rigorosamente a sintaxe do PostgreSQL
-- Este script precisa ser escrito de modo que possa ser executado completamente sem apresentar erros

-- ----------------------------
-- [1] ESQUEMAS
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
	constraint p_matricula_ck check(p_matricula > 0),
 	constraint p_status_ck check((p_status = 'ativo') or (p_status = 'inativo')),
 	constraint p_cargo_ck check((p_cargo = 'diretor') or (p_cargo = 'gerente') or (p_cargo = 'funcionário'))
 );

 create table tb.departamento(
 	d_codigo bigint,
 	d_nome varchar(100) unique not null,
 	d_descricao text,
 	constraint departamento_pk primary key(d_codigo),
	constraint d_codigo_ck check(d_codigo > 0)
 );

 create table tb.ocorrencia(
 	o_numero serial,
 	o_status_temp varchar(10) default 'aberta',
 	o_status_def varchar(10) default 'aberta',
 	o_data date,
	o_data_limite date,
 	o_descricao text,
 	o_matricula_func bigint,
 	o_depto_cod bigint,
 	constraint ocorrencia_pk primary KEY(o_numero),
 	constraint o_status_temp_ck check((o_status_temp = 'aberta') or (o_status_temp = 'encerrada')),
 	constraint o_status_def_ck check((o_status_def = 'aberta') or (o_status_def = 'encerrada')),
 	constraint o_data_ck check(o_data <= current_date)
 );

-- NOTA == ALTER TABLE esquema.nometabela1 ADD CONSTRAINT...
alter table tb.pessoa add constraint pessoa_depto_fk foreign key(p_depto_cod) references tb.departamento(d_codigo) on update cascade on delete set null;

alter table tb.ocorrencia add constraint ocorrencia_pessoa_fk foreign key(o_matricula_func) references tb.pessoa(p_matricula) on update cascade on delete set null;
alter table tb.ocorrencia add constraint ocorrencia_depto_fk foreign key(o_depto_cod) references tb.departamento(d_codigo) on update cascade on delete set null;

-- ----------------------------
-- [3] CARGA DE DADOS
-- 100 tuplas no total e identificar quem fez as insercoes

-- 20 INSERTs - Davi Trost Gouveia
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (1, 'Departamento Administrativo', 'Lidera os demais setores e coordená-los para que haja alinhamento entre eles a fim de alcançar os resultados desejados pela empresa.');

INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (1,'Kimberly Valério Barrocas','inativo','diretor');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (4,'Lilian Souto Onofre','inativo','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (8,'Aléxis Arouca Ferraz','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (12,'Ticiana Faustino Martins','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (13,'Yi Caparica Oleiro','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (14,'Lana Hipólito Estrada','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (15,'Eliza Boeira Rego','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (16,'Natacha Sacadura Gravato','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (17,'Amélia Veríssimo Sodré','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (18,'Isís Tomé Robalo','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (19,'Irís Salgueiro Almada','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (20,'Marcus Calçada Campos','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (21,'Max Vilanova Bugalho','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (22,'Rodolfo Bezerril Nascimento','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (74,'Raul Figueiroa Sintra','inativo','funcionário');

INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('11/07/2017','DD/MM/YYYY'), to_date('11/07/2017','DD/MM/YYYY'),'Problemas na rede');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('11/09/2017','DD/MM/YYYY'), to_date('11/09/2017','DD/MM/YYYY'),'Falha ao gerar folha de pagamento para todos os setores');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('10/10/2017','DD/MM/YYYY'), to_date('10/10/2017','DD/MM/YYYY'),'Falha ao gerar relatório de finanças');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('29/03/2018','DD/MM/YYYY'), to_date('29/03/2018','DD/MM/YYYY'),'Falha ao gerar relatório de finanças no ano');

-- 20 INSERTs - Filipe Gomes Cruvinel
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (2, 'Departamento Financeiro', 'O departamento financeiro é responsável por administrar todos os recursos de uma empresa. Sua função é exercer controle no fluxo de caixa, arantindo uma boa gestão sobre as despesas, receitas, repasse de recursos e demais movimentações financeiras.');

INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (2,'Kamila Aleixo Alcântara','inativo','diretor');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (5,'Alice Fialho Goulão','inativo','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (9,'Deivid Beiriz Protásio','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (23,'Zoe Quental Rolim','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (24,'Ticiana Bingre Jordão','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (25,'Petra Noleto Furtado','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (26,'Mellanie Assunção Batata','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (27,'Bianca Varela Caniça','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (28,'Quessia Malho Valente','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (29,'Nilo Baldaia Malafaia','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (30,'Damien Belchiorinho Lustosa','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (31,'Azael Letras Reis','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (32,'Dânia Cardoso Toste','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (33,'Éder Bandeira Mesquita','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (75,'Dominique Carreiro Canela','inativo','funcionário');

INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('02/06/2018','DD/MM/YYYY'), to_date('02/06/2018','DD/MM/YYYY'),'Necessidade de backup');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('29/07/2018','DD/MM/YYYY'), to_date('29/07/2018','DD/MM/YYYY'),'Problemas na rede');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('29/04/2019','DD/MM/YYYY'), to_date('29/04/2019','DD/MM/YYYY'),'Problemas na rede');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('01/06/2019','DD/MM/YYYY'), to_date('01/06/2019','DD/MM/YYYY'),'Falha ao gerar relatório de finanças no ano');

-- 20 INSERTs - Júlio César Schendroski
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (3, 'Departamento Comercial', 'Rsponsável pelas atividades de venda da empresa, desde as estratégias de divulgação dos produtos ou serviços até a prospecção e fidelização de clientes.');

INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (3,'Sienna Grande Corte-Real','diretor');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (6,'Maia Coutinho Albernaz','inativo','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (10,'Iasmin Pestana Poças','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (34,'Catalina Redondo Quadros','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (35,'Zilda Afonso Espinosa','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (36,'Pandora Pastana Custódio','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (37,'Irina Alcoforado Avelar','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (38,'Yara Brião Onofre','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (39,'Lui Meira Farias','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (40,'Milena Macieira Mondragão','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (41,'Viriato Maciel Valadim','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (42,'Melânia Teixeira Cantanhede','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (43,'Rahyssa Taveira Gouveia','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (44,'Jeremias Olaio Barroqueiro','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (76,'Santiago Castro Ventura','inativo','funcionário');

INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('13/11/2019','DD/MM/YYYY'), to_date('13/11/2019','DD/MM/YYYY'), 'Falha ao gerar relatório de lucro no semestre');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('03/05/2020','DD/MM/YYYY'), to_date('03/05/2020','DD/MM/YYYY'), 'Falha ao gerar relatório das finanças');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('31/01/2021','DD/MM/YYYY'), to_date('31/01/2021','DD/MM/YYYY'), 'Falha ao gerar relatório das finanças');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('13/04/2021','DD/MM/YYYY'), to_date('13/04/2021','DD/MM/YYYY'), 'Falha ao gerar relatório de lucro no semestre');

-- 20 INSERTs - Mateus Augusto Viotto
INSERT INTO tb.departamento (d_codigo, d_nome, d_descricao) VALUES (4, 'Departamento de Informatica','Responsável pela criação de redes e manutenção dos computadores.');

INSERT INTO tb.pessoa  (p_matricula, p_nome, p_status, p_cargo) VALUES (7,'Lorenzo Canto Cedro','inativo','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (11,'Francis Vilante Monteiro','gerente');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (45,'Ruben Cesário Colares','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (46,'Felipe Moreira Lopes','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (47,'Samuel Vasques Brião','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (48,'India Casalinho Castro','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (49,'Nélson Camilo Gomes','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (50,'Fedra Canejo Fitas','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (51,'Anthony Quirino Rebotim','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (52,'Yannick Maior Salvado','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (53,'Heitor Brochado Corte-Real','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (54,'Flor Morgado Albernaz','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (55,'Martinha Damásio Ventura','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (56,'Jóni Alcoforado Mourão','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (57,'Amanda Tinoco Pereira','funcionário');

INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('17/05/2021','DD/MM/YYYY'), to_date('17/05/2021','DD/MM/YYYY'), 'Falha ao gerar relatório das finanças no ano');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('20/06/2021','DD/MM/YYYY'), to_date('20/06/2021','DD/MM/YYYY'), 'Falha ao gerar relatório de vendas');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('12/08/2021','DD/MM/YYYY'), to_date('12/08/2021','DD/MM/YYYY'), 'Falha ao gerar relatório de vendas');
INSERT INTO tb.ocorrencia (o_data, o_data_limite, o_descricao) VALUES (to_date('08/03/2022','DD/MM/YYYY'), to_date('22/06/2022','DD/MM/YYYY'), 'Problemas na rede');

-- 20 INSERTs - Pedro Barriviera
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (58,'Oceana Goulão Tabosa','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (59,'Anselmo Rijo Morão','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (60,'Karina Medina Caparica','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (61,'Leonor Brites Reis','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (62,'Daiana Ferro Sabala','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (63,'Elisa Bulhosa Paz','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (64,'Heloísa Valverde Franca','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (65,'Michele Guedelha Padilha','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (66,'Adriel Lucas Boto','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (67,'Mickael Alpuim Tavares','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (68,'Joshua Janes Rios','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (69,'Nilson Abrantes Doutis','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (70,'Enoque Teves Infante','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (71,'Lívia Martinho Varanda','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (72,'Amina Atilano Guerreiro','funcionário');
INSERT INTO tb.pessoa  (p_matricula, p_nome, p_cargo) VALUES (73,'Evelina Barroso Alves','funcionário');

INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('06/04/2022','DD/MM/YYYY'), to_date('06/04/2022','DD/MM/YYYY'), 'Falha ao gerar relatório de salários pagos no semestre');
INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao) VALUES ('encerrada','encerrada', to_date('18/04/2022','DD/MM/YYYY'), to_date('18/04/2022','DD/MM/YYYY'), 'Falha ao gerar relatório de vendas');
INSERT INTO tb.ocorrencia (o_data, o_data_limite, o_descricao) VALUES (to_date('05/06/2022','DD/MM/YYYY'), to_date('22/06/2022','DD/MM/YYYY'),'Necessidade de atualizar máquinas');
INSERT INTO tb.ocorrencia (o_data, o_data_limite, o_descricao) VALUES (to_date('07/06/2022','DD/MM/YYYY'), to_date('22/06/2022','DD/MM/YYYY'),'Necessidade de configuração da sub-rede');

-- UPDATEs possivelmente necessarios nas linhas abaixo:
update tb.pessoa set p_depto_cod = 1 where p_matricula = 4 or p_matricula = 8 or (p_matricula >= 12 and p_matricula <= 27);
update tb.pessoa set p_depto_cod = 2 where p_matricula = 5 or p_matricula = 9 or (p_matricula >= 28 and p_matricula <= 43);
update tb.pessoa set p_depto_cod = 3 where p_matricula = 6 or p_matricula = 10 or (p_matricula >= 44 and p_matricula <= 59);
update tb.pessoa set p_depto_cod = 4 where p_matricula = 7 or p_matricula = 11 or (p_matricula >= 60 and p_matricula <= 76);

update tb.ocorrencia set o_matricula_func = 76, o_depto_cod = 4 where o_numero = 1;
update tb.ocorrencia set o_matricula_func = 68, o_depto_cod = 2 where o_numero = 2;
update tb.ocorrencia set o_matricula_func = 75, o_depto_cod = 2 where o_numero = 3;
update tb.ocorrencia set o_matricula_func = 67, o_depto_cod = 2 where o_numero = 4;

update tb.ocorrencia set o_matricula_func = 70, o_depto_cod = 1 where o_numero = 5;
update tb.ocorrencia set o_matricula_func = 74, o_depto_cod = 3 where o_numero = 6;
update tb.ocorrencia set o_matricula_func = 60, o_depto_cod = 3 where o_numero = 7;
update tb.ocorrencia set o_matricula_func = 65, o_depto_cod = 2 where o_numero = 8;

update tb.ocorrencia set o_matricula_func = 71, o_depto_cod = 2 where o_numero = 9;
update tb.ocorrencia set o_matricula_func = 69, o_depto_cod = 2 where o_numero = 10;
update tb.ocorrencia set o_matricula_func = 61, o_depto_cod = 2 where o_numero = 11;
update tb.ocorrencia set o_matricula_func = 62, o_depto_cod = 2 where o_numero = 12;

update tb.ocorrencia set o_matricula_func = 72, o_depto_cod = 2 where o_numero = 13;
update tb.ocorrencia set o_matricula_func = 66, o_depto_cod = 3 where o_numero = 14;
update tb.ocorrencia set o_matricula_func = 63, o_depto_cod = 3 where o_numero = 15;
update tb.ocorrencia set o_matricula_func = 64, o_depto_cod = 3 where o_numero = 16;

update tb.ocorrencia set o_matricula_func = 60, o_depto_cod = 2 where o_numero = 17;
update tb.ocorrencia set o_matricula_func = 73, o_depto_cod = 3 where o_numero = 18;
update tb.ocorrencia set o_matricula_func = 70, o_depto_cod = 1 where o_numero = 19;
update tb.ocorrencia set o_matricula_func = 63, o_depto_cod = 2 where o_numero = 20;

-- -----------------------
-- [4] CONSULTAS
-- Alem do comando SELECT correspondente, fornecer o que se pede

-- [4.1] Listagem
-- Usar jun''o('es) (JOINs), filtro(s) (WHERE), ordena''o (ORDER BY)

-- Enunciado: seleciona os funcionários do tepartamento de código 1 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' 
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os funcionários do tepartamento de código 1 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' and d_codigo = 1
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os funcionários do tepartamento de código 2 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' and d_codigo = 2
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os funcionários do tepartamento de código 3 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' and d_codigo = 3
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os funcionários do tepartamento de código 4 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' and d_codigo = 4
order by p_status desc, d_nome asc;

-- Enunciado: seleciona todos os funcionários ativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' and p_status = 'ativo'
order by p_status desc, d_nome asc;

-- Enunciado: seleciona todos os funcionários inativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' and p_status = 'inativo'
order by p_status desc, d_nome asc;



-- Enunciado: seleciona todos os gerentes ordenandos pelo status e departamento
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial / cadastro de gerente)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' 
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os gerentes do tepartamento de código 1 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' and d_codigo = 1
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os gerentes do tepartamento de código 2 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' and d_codigo = 2
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os gerentes do tepartamento de código 3 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' and d_codigo = 3
order by p_status desc, d_nome asc;

-- Enunciado: seleciona os gerentes do tepartamento de código 4 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' and d_codigo = 4
order by p_status desc, d_nome asc;

-- Enunciado: seleciona todos os gerentes ativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' and p_status = 'ativo'
order by p_status desc, d_nome asc;

-- Enunciado: seleciona todos os gerentes inativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' and p_status = 'inativo'
order by p_status desc, d_nome asc;



-- Enunciado: seleciona todas as ocorrências ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento
-- Usuario(s) atendido(s): gerente, funcionário
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
order by o_numero;

-- Enunciado: seleciona as ocorrências do departamento de código 1 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_depto_cod = 1
order by o_status_def desc, o_status_temp desc, o_data asc;

-- Enunciado: seleciona as ocorrências do departamento de código 2 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_depto_cod = 2
order by o_status_def desc, o_status_temp desc, o_data asc;

-- Enunciado: seleciona as ocorrências do departamento de código 3 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_depto_cod = 3
order by o_status_def desc, o_status_temp desc, o_data asc;

-- Enunciado: seleciona as ocorrências do departamento de código 4 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_depto_cod = 4
order by o_status_def desc, o_status_temp desc, o_data asc;

-- Enunciado: seleciona as ocorrências ativas ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente, funcionário
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_status_temp = 'ativa' and o_status_def = 'ativa'
order by o_status_def desc, o_status_temp desc, o_data asc;

-- Enunciado: seleciona as ocorrências parcialmente encerradas ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente, funcionário
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_status_temp = 'encerrada' and o_status_def = 'ativa'
order by o_status_def desc, o_status_temp desc, o_data asc;

-- Enunciado: seleciona as ocorrências encerradas ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente, funcionário
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, 
o_status_def as status_definitivo, o_descricao as descricao, p_nome as funcionario, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
where o_status_temp = 'encerrada' and o_status_def = 'encerrada'
order by o_status_def desc, o_status_temp desc, o_data asc;



-- Enunciado: seleciona todos os diretores ordenados pelo status e nome
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (cadastro de diretor)
-- Usuario(s) atendido(s): diretor  
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo
from tb.pessoa
where p_cargo = 'diretor'
order by p_status desc, p_nome asc;



-- [4.2] Relatorio
-- Usar jun''o('es) (JOINs), filtro(s) (WHERE), agrupamento (GROUP BY) e fun''o de agregacao (count, sum, avg, etc)

-- Enunciado: seleciona todos os departamentos com a quantidade de funcionários
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial / cadastro de departamento)
-- Usuario(s) atendido(s): diretor
select d_codigo as codigo, d_nome as nome, d_descricao as descricao, sum(case when d_codigo = p_depto_cod then 1 else 0 end) as qtd_funcionarios
from tb.departamento, tb.pessoa
where p_cargo = 'funcionário' and p_status = 'ativo'
group by d_codigo
order by d_codigo asc;


-- -------------------------
-- [5] VISOES


-- [5.1] Visao
-- A visao deve ter, no minimo, as caracteristicas de 4.1

-- Enunciado: seleciona todos os funcionários ordenandos pelo status e departamento
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento
-- Usuario(s) atendido(s): gerente 
create view vw.v_funcionario as
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, p_depto_cod as codigo_depto, d_nome as departamento
from tb.pessoa  inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'funcionário' 
order by p_status desc, d_nome asc;

-- Enunciado: seleciona todos os gerentes ordenandos pelo status e departamento
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial / cadastro de gerente)
-- Usuario(s) atendido(s): diretor
create view vw.v_gerente as
select p_matricula as matricula, p_nome as nome, p_status as status, p_cargo as cargo, p_depto_cod as codigo_depto, d_nome as departamento
from tb.pessoa inner join tb.departamento on p_depto_cod = d_codigo 
where p_cargo = 'gerente' 
order by p_status desc, d_nome asc;

-- Enunciado: seleciona todas as ocorrências ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento
-- Usuario(s) atendido(s): gerente, funcionário
create view vw.v_ocorrencia as
select o_numero as ID, o_data as data_ocorrencia, o_data_limite as data_limite, o_status_temp as status_temporario, o_status_def as status_definitivo, 
o_descricao as descricao, o_matricula_func as matricula_func, p_nome as funcionario, o_depto_cod as depto_cod, d_nome as departamento 
from tb.ocorrencia inner join tb.departamento on o_depto_cod = d_codigo inner join tb.pessoa on p_matricula = o_matricula_func 
order by o_status_def desc, o_status_temp desc, o_data asc;

-- [5.2] Consulta na visao
-- Consultar a visao criada em 5.1 realizando filtro(s) (WHERE)

-- Enunciado: seleciona os funcionários do tepartamento de código 1 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select * from vw.v_funcionario where codigo_depto = 1;

-- Enunciado: seleciona os funcionários do tepartamento de código 2 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select * from vw.v_funcionario where codigo_depto = 2;

-- Enunciado: seleciona os funcionários do tepartamento de código 3 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente
select * from vw.v_funcionario where codigo_depto = 3;

-- Enunciado: seleciona os funcionários do tepartamento de código 4 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de funcionário)
-- Usuario(s) atendido(s): gerente 
select * from vw.v_funcionario where codigo_depto = 4;

-- Enunciado: seleciona todos os funcionários ativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente
select * from vw.v_funcionario where status = 'ativo';

-- Enunciado: seleciona todos os funcionários inativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente
select * from vw.v_funcionario where status = 'inativo';



-- Enunciado: seleciona os gerentes do tepartamento de código 1 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.v_gerente where codigo_depto = 1;

-- Enunciado: seleciona os gerentes do tepartamento de código 2 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.v_gerente where codigo_depto = 2;

-- Enunciado: seleciona os gerentes do tepartamento de código 3 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.v_gerente where codigo_depto = 3;

-- Enunciado: seleciona os gerentes do tepartamento de código 4 ordenandos pelo status
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.v_gerente where codigo_depto = 4;

-- Enunciado: seleciona todos os gerentes ativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.v_gerente where status = 'ativo';

-- Enunciado: seleciona todos os gerentes inativos ordenandos pelo departamento
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.v_gerente where status = 'inativo';



-- Enunciado: seleciona as ocorrências do departamento de código 1 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select * from vw.v_ocorrencia where depto_cod = 1;

-- Enunciado: seleciona as ocorrências do departamento de código 2 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select * from vw.v_ocorrencia where depto_cod = 2;

-- Enunciado: seleciona as ocorrências do departamento de código 3 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente 
select * from vw.v_ocorrencia where depto_cod = 3;

-- Enunciado: seleciona as ocorrências do departamento de código 4 ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente para permitir gerenciamento (tela inicial / cadastro de ocorrência)
-- Usuario(s) atendido(s): gerente
select * from vw.v_ocorrencia where depto_cod = 4;

-- Enunciado: seleciona as ocorrências ativas ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente, funcionário
select * from vw.v_ocorrencia where status_temporario = 'ativa' and status_definitivo = 'ativa';

-- Enunciado: seleciona as ocorrências parcialmente encerradas ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente, funcionário
select * from vw.v_ocorrencia where status_temporario = 'encerrada' and status_definitivo = 'ativa';

-- Enunciado: seleciona as ocorrências encerradas ordenandas pelo número
-- Importancia na aplicacao: mostrar informações ao gerente e ao funcionário para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): gerente, funcionário
select * from vw.v_ocorrencia where status_temporario = 'encerrada' and status_definitivo = 'encerrada';

-- [5.3] Visao materializada
-- A visao deve ter, no minimo, as caracteristicas de 4.2

-- Enunciado: seleciona todos os departamentos com a quantidade de funcionários
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial / cadastro de departamento)
-- Usuario(s) atendido(s): diretor
create materialized view vw.mv_departamento_qtd_pessoas as
select d_codigo as codigo, d_nome as nome, d_descricao as descricao, sum(case when d_codigo = p_depto_cod then 1 else 0 end) as qtd_funcionarios
from tb.departamento, tb.pessoa
where p_cargo = 'funcionário' and p_status = 'ativo'
group by d_codigo
order by d_codigo asc;

-- [5.4] Consulta na visao materializada
-- Consultar a visao criada em 4.2 realizando filtro(s) (WHERE)

-- Enunciado: seleciona departamento de código 1
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.mv_departamento_qtd_pessoas where codigo = 1;

-- Enunciado: seleciona departamento de código 2
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.mv_departamento_qtd_pessoas where codigo = 2;

-- Enunciado: seleciona departamento de código 3
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor 
select * from vw.mv_departamento_qtd_pessoas where codigo = 3;

-- Enunciado: seleciona departamento de código 4
-- Importancia na aplicacao: mostrar informações ao diretor para permitir gerenciamento (tela inicial)
-- Usuario(s) atendido(s): diretor
select * from vw.mv_departamento_qtd_pessoas where codigo = 4;

-- [5.5] Atualizacao da visao materializada
-- Comente brevemente sobre a necessidade de atualizacao e qual seria a frequencia/periodicidade

-- Considerou-se que ambas as tabelas - departamento, especialmente, e funcionário - não sofreriam atualizações com frequência. Após qualquer atualização na 
-- tabela departamento, realizar-se-á uma refresh na view materializada - função engatilhada.

-- Redija o comando REFRESH correspondente
refresh materialized view vw.mv_departamento_qtd_pessoas;

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

-- Ao analizar a o custo de indexar utilizando a primary key de departamento no exemplo anterior, podemos ver que
-- Houve um custo considerável, apesar do banco de dados ser de uma escala menor, foi custoso para utilizar o SELECT
-- Através de um indice padrão que o próprio SGBD definiu.


-- [6.4] CREATE INDEX e PARAMETROS (Set)
-- Crie o indice, verifique se o indice ja esta sendo usado no processamento da consulta e, caso nao esteja, ajuste os parametros
	CREATE INDEX index_hash_pessoa ON tb.pessoa USING HASH (p_matricula);
	
	

-- ---------------------------------------------
-- [7] FUNCOES INTERNAS
-- Usar funcoes internas nas operacoes em tabelas do banco de dados

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Seleciona o id, status - temporário e definitivo - e descrição da ocorrências de data igual à data atual 
	SELECT o_numero, o_status_temp, o_status_def, o_descricao FROM tb.ocorrencia WHERE o_data = CURRENT_DATE;

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Insere nova ocorrência formatando entrada - dada em maiúsculo - no status definitivo
    INSERT INTO tb.ocorrencia (o_status_temp, o_status_def, o_data, o_data_limite, o_descricao, o_matricula_func, o_depto_cod)
    VALUES ('encerrada', LOWER('ENCERRADA'), to_date('08/06/2022','DD/MM/YYYY'), to_date('08/06/2022','DD/MM/YYYY'), 'Backup setor de informática', 69, 4);

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Atualiza o nome do funcionário com id 1 para o mesmo com letras maiusculas
    UPDATE tb.pessoa SET p_nome = UPPER('Sienna Grande Corte-Real') WHERE p_matricula = 1;

-- Explicar aqui o que o comando abaixo faz e sua utilidade na aplicacao
-- Inabilita o funcionário que possui a matricula que seja 2 elevado a 4 (16)
    UPDATE tb.pessoa SET p_status = 'inativo' WHERE p_matricula = POWER(2,4);
	
	

-- ---------------------------------------------
-- [8] USER-DEFINED FUNCTION (UDF)
-- Vislumbrar a cria''o de uma fun''o (UDF) para o banco de dados.
-- Comentar a utilidade da funcao na aplicacao.
-- Redigir o comando CREATE OR REPLACE FUNCTION correspondente usando PL/pgSQL.
-- Redigir um comando SQL que chame a funcao, explicando o que sua chamada faz.
-- A funcao devera' ter parametro(s).


-- Comentar aqui a utilidade da funcao na aplicacao
-- A função faz com que a data de uma ocorrência seja alterada conforme um input por parâmetro.
    CREATE OR REPLACE FUNCTION f_adiciona_data_limite (id_ocorrencia BIGINT, nova_data_limite DATE) 
	RETURNS BOOLEAN AS $$
    DECLARE 
    var_data_limite tb.ocorrencia.o_data_limite%TYPE;
    BEGIN
		SELECT o_data_limite INTO var_data_limite 
		FROM tb.ocorrencia
		WHERE o_numero = id_ocorrencia;
		
		IF var_data_limite IS NULL THEN	
			UPDATE tb.ocorrencia SET o_data_limite = nova_data_limite WHERE o_numero = id_ocorrencia;
			RETURN TRUE;
		END IF;

		RETURN FALSE;
    END;
    $$ LANGUAGE 'plpgsql';

-- Explicar aqui o que a chamada abaixo faz
-- Atualiza, caso seja null, a data limite da ocorrência 21, retornando true; retorna false caso não tenha atualizado
    SELECT * FROM f_adiciona_data_limite (21, to_date('22/06/2022','DD/MM/YYYY'));



-- ---------------------------------------------
-- [9] STORED PROCEDURE
-- Vislumbrar a cria''o de um procedimento armazenado para o banco de dados.
-- Comentar a utilidade do procedimento na aplicacao.
-- Redigir o comando CREATE OR REPLACE PROCEDURE correspondente usando PL/pgSQL.
-- Redigir um comando SQL que chame o procedimento, explicando o que sua chamada faz.
-- O procedimento devera' ter parametro(s).

-- Comentar a utilidade do procedimento na aplicacao aqui
    CREATE OR REPLACE PROCEDURE p_insercao_ocorrencia(data_ocorrencia DATE, data_limite DATE, descricao VARCHAR, matricula INT, depto INT) 
	AS $$
    BEGIN
        INSERT INTO tb.ocorrencia (o_data, o_data_limite, o_descricao, o_matricula_func, o_depto_cod) 
		VALUES (data_ocorrencia, data_limite, descricao, matricula, depto);
            
	    RAISE NOTICE 'A nova ocorrência do departamento % foi inserida', depto;
    END;
    $$ LANGUAGE 'plpgsql';

-- Explicar aqui o que a chamada abaixo faz
-- Através de uma PROCEDURE, insere uma nova ocorrência em determinado departamento
	CALL p_insercao_ocorrencia(to_date('09/06/2022','DD/MM/YYYY'), to_date('22/06/2022','DD/MM/YYYY'), 'Configurar sub-rede do departamento financairo', 73, 2);



-- ---------------------------------------------
-- [10] TRIGGER
-- Revisar as aplica''es em potencial para bancos de dados ativos (e gatilhos).
-- Vislumbrar a cria''o de um gatilho e de uma fun''o engatilhada para o banco de dados.
-- Se necessario redigir logo abaixo outros comandos SQL necessarios (criacao de coluna, atualizacao de tuplas etc):


-- [10.1] ROW
-- Comentar aqui a utilidade, para a aplicacao, do gatilho em nivel de tupla e da sua funcao engatilhada.

-- Redigir o comando CREATE OR REPLACE FUNCTION correspondente usando PL/pgSQL
create or replace function f_verifica_descricao_insert_depto()
returns trigger as $$
declare
	var_descricao tb.departamento.d_descricao%type;
begin
	for var_descricao in
	select d_descricao from tb.departamento
	loop
	
		if var_descricao = new.d_descricao then
			RAISE NOTICE 'Descrição igual a de departamento existente!!!!';
		end if;
		
	end loop;

	return null;
end;
$$ language 'plpgsql';

-- Redigir o comando CREATE TRIGGER correspondente ao gatilho em nivel de tupla usando PL/pgSQL
create trigger tg_verifica_descricao_insert_depto
after insert on tb.departamento
for each row execute function f_verifica_descricao_insert_depto();

-- Redigir pelo menos 1 comando SQL que dispare o gatilho em nivel de tupla
insert into tb.departamento (d_codigo, d_nome, d_descricao) values (5, 'Departamento 5', 'Lidera os demais setores e coordená-los para que haja alinhamento entre eles a fim de alcançar os resultados desejados pela empresa.');

-- Descrever o que acontece no banco de dados quando e' disparado

-- Caso a descrição do departamento que está sendo inserido seja igual à descrição de um departamento já cadastrado, é dada uma mensagem de aviso expondo tal situação.

-- Se necessario para executar os comandos seguintes, remover o gatilho de 10.1 abaixo:
drop trigger tg_verifica_descricao_insert_depto on tb.departamento;
drop function f_verifica_descricao_insert_depto;



-- [10.2] STATEMENT
-- Comentar aqui a utilidade, para a aplicacao, do gatilho em nivel de sentenca e da sua funcao engatilhada.

-- Redigir o comando CREATE OR REPLACE FUNCTION correspondente usando PL/pgSQL
create or replace function f_atualiza_mv_departamento_qtd_pessoas()
returns trigger as $$
begin
	refresh materialized view vw.mv_departamento_qtd_pessoas;
	return null;
end;
$$ language 'plpgsql';

-- Redigir o comando CREATE TRIGGER correspondente ao gatilho em nivel de sentenca usando PL/pgSQL
create trigger tg_atualiza_mv_departamento_qtd_pessoas
after insert or update or delete on tb.departamento
execute function f_atualiza_mv_departamento_qtd_pessoas();

-- Redigir pelo menos 1 comando SQL que dispare o gatilho em nivel de sentenca
delete from tb.departamento where d_codigo = 5;

-- Descrever o que acontece no banco de dados quando e' disparado

-- Ao disparar o gatilho - inserção, alteração ou deleção de departamento -, a view materializada mv_departamento_qtd_pessoas é atualizada; considerou-se o fato de que tais 
-- operações na tabela departamento ocorreriam com baixa freqência, fazendo com que a atualização seja pouco realizada.



-- ---------------------------------------------
-- [11] SEGURANCA
-- Nao sera incluida aqui
-- Usar/entregar o modelo especifico


-- [11.1] ACESSO REMOTO (pg_hba.conf)

-- # TYPE  DATABASE        USER            ADDRESS                 METHOD

-- # "local" is for Unix domain socket connections only
-- local   all             all                                     scram-sha-256
-- # IPv4 local connections:
-- host    all             postgres        10.128.70.0/24        scram-sha-256
-- host    ocorrenciascpd  diretor         10.128.70.0/24         scram-sha-256
-- host    ocorrenciascpd  gerente         10.128.70.0/24        scram-sha-256
-- host    ocorrenciascpd  funcionario     10.128.70.0/24        scram-sha-256
	
-- host    ocorrenciascpd  adm             10.128.70.0/24         scram-sha-256
-- host    ocorrenciascpd  adm             10.128.70.0/24        scram-sha-256
-- host    ocorrenciascpd  adm             10.128.70.0/24        scram-sha-256	

-- # IPv6 local connections:
-- host    all             all             ::1/128                 scram-sha-256
-- # Allow replication connections from localhost, by a user with the
-- # replication privilege.
-- local   replication     all                                     scram-sha-256
-- host    replication     all             127.0.0.1/32            scram-sha-256
-- host    replication     all             ::1/128                 scram-sha-256



-- [11.2] PAPEIS (Roles)
-- Criar papeis de usuarios e de grupos
-- Nessa criacao, considerar tanto papeis da equipe (administracao/desenvolvimento) quanto papeis de usuarios da aplicacao
-- Para cada papel criado adicionar um comentario antes explicando qual e' a utilidade dele na aplicacao

CREATE ROLE superadm WITH SUPERUSER;
CREATE ROLE adm WITH LOGIN PASSWORD 'ifspadm' CREATEROLE;
CREATE ROLE funcionario WITH LOGIN PASSWORD 'ifspfuncionario';
CREATE ROLE gerente WITH LOGIN PASSWORD 'ifspgerente';
CREATE ROLE diretor WITH LOGIN PASSWORD 'ifspdiretor';

-- [11.3] PRIVILEGIOS DE ACESSO (Grant)

GRANT CONNECT ON DATABASE ocorrenciascpd TO funcionario, gerente, diretor;
GRANT CONNECT ON DATABASE ocorrenciascpd TO adm WITH GRANT OPTION;

-- [11.3.1]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) criar o(s) esquema(s) da Secao 1
-- Usuario(s) podem conceder esse acesso alem do superusuario: adm

GRANT CREATE ON DATABASE ocorrenciascpd TO diretor;
GRANT CREATE ON DATABASE ocorrenciascpd TO adm WITH GRANT OPTION;

-- [11.3.2]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) criar a(s) tabela(s), as sequencias e as restricoes da Secao 2 e as visoes da Secao 5
-- Usuario(s) podem conceder esse acesso alem do superusuario: adm

GRANT CREATE ON SCHEMA tb TO diretor;
GRANT CREATE ON SCHEMA tb, vw TO adm WITH GRANT OPTION;

-- [11.3.3]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) inserir e atualizar tuplas, conforme a Secao 3
-- Usuario(s) podem conceder esse acesso alem do superusuario: diretor, gerente, funcionario, adm

GRANT USAGE ON SCHEMA tb TO gerente, diretor, funcionario;
GRANT USAGE ON SCHEMA tb TO adm WITH GRANT OPTION;

GRANT UPDATE ON TABLE tb.ocorrencia TO funcionario;

GRANT INSERT, UPDATE ON TABLE tb.pessoa, tb.ocorrencia TO gerente;
GRANT DELETE ON TABLE tb.ocorrencia TO gerente;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA tb TO gerente;
GRANT REFERENCES ON TABLE tb.pessoa, tb.departamento TO gerente;

GRANT INSERT, UPDATE ON TABLE tb.pessoa, tb.departamento TO diretor;
GRANT DELETE ON TABLE tb.departamento TO diretor;

GRANT INSERT, UPDATE, DELETE ON TABLE tb.pessoa, tb.ocorrencia, tb.departamento TO adm WITH GRANT OPTION;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA tb, vw TO adm WITH GRANT OPTION;

-- [11.3.4]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) executar as consultas das Secoes 4 e 5
-- Usuario(s) podem conceder esse acesso alem do superusuario: diretor, gerente, funcionario, adm

GRANT USAGE ON SCHEMA vw TO gerente, diretor, funcionario;
GRANT USAGE ON SCHEMA vw TO adm WITH GRANT OPTION;

GRANT SELECT ON TABLE tb.ocorrencia, tb.pessoa, tb.departamento TO funcionario, gerente, diretor;
GRANT SELECT ON TABLE tb.ocorrencia, tb.pessoa, tb.departamento TO adm WITH GRANT OPTION;

GRANT SELECT ON ALL SEQUENCES IN SCHEMA tb, vw TO funcionario, gerente, diretor;
GRANT SELECT ON ALL SEQUENCES IN SCHEMA tb, vw TO adm WITH GRANT OPTION;

GRANT SELECT ON TABLE vw.v_funcionario, vw.v_ocorrencia TO funcionario, gerente, diretor;
GRANT SELECT ON TABLE vw.v_gerente TO diretor;
GRANT SELECT ON TABLE vw.v_funcionario, vw.v_ocorrencia, vw.v_gerente TO adm WITH GRANT OPTION;

GRANT SELECT ON TABLE vw.mv_departamento_qtd_pessoas TO gerente, diretor;
GRANT SELECT ON TABLE vw.mv_departamento_qtd_pessoas TO adm WITH GRANT OPTION;
ALTER MATERIALIZED VIEW vw.mv_departamento_qtd_pessoas OWNER TO diretor;

-- [11.3.5]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) executar os comandos da Secao 7
-- Usuario(s) podem conceder esse acesso alem do superusuario: gerente, adm

GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO adm WITH GRANT OPTION;

-- [11.3.6]
-- Assegurar os privilegios necessarios para o(s) papel(is) poder(em) executar as subrotinas das Secoes 8, 9 e 10
-- Assegurar tambem os privilegios para executar os comandos que realizam as chamadas (ou disparos) daquelas subrotinas
-- Usuario(s) podem conceder esse acesso alem do superusuario: diretor, gerente, adm

GRANT EXECUTE ON FUNCTION f_adiciona_data_limite TO gerente;
GRANT EXECUTE ON FUNCTION f_adiciona_data_limite TO adm WITH GRANT OPTION;

GRANT EXECUTE ON PROCEDURE p_insercao_ocorrencia TO gerente;
GRANT EXECUTE ON PROCEDURE p_insercao_ocorrencia TO adm WITH GRANT OPTION;

GRANT TRIGGER ON TABLE tb.departamento TO diretor;
GRANT TRIGGER ON TABLE tb.departamento TO adm WITH GRANT OPTION;

-- [11.4] PRIVILEGIOS DE ACESSO (Revoke)

-- [11.4.1]
-- Revogar o acesso em 11.3.1 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm

REVOKE CREATE ON DATABASE ocorrenciascpd FROM diretor;

-- [11.4.2]
-- Revogar o acesso em 11.3.2 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm

REVOKE CREATE ON SCHEMA tb FROM diretor;

-- [11.4.3]
-- Revogar o acesso em 11.3.3 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm

REVOKE UPDATE ON TABLE tb.ocorrencia FROM funcionario;

-- [11.4.4]
-- Revogar o acesso em 11.3.4 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm

REVOKE SELECT ON TABLE tb.ocorrencia FROM funcionario;

-- [11.4.5]
-- Revogar o acesso em 11.3.5 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm

REVOKE EXECUTE ON ALL FUNCTIONS IN SCHEMA public FROM gerente;

-- [11.4.6]
-- Revogar o acesso em 11.3.6 de pelo menos 1 papel
-- Usuario(s) podem revogar esse acesso alem do superusuario: adm

REVOKE TRIGGER ON TABLE tb.departamento FROM diretor;


-- Se for necessario para executar os comandos seguintes, assegure novamente os privilegios de acesso revogados acima

GRANT UPDATE ON TABLE tb.ocorrencia TO funcionario;
GRANT SELECT ON TABLE tb.ocorrencia TO funcionario;
GRANT EXECUTE ON ALL FUNCTIONS IN SCHEMA public TO gerente;
GRANT TRIGGER ON TABLE tb.departamento TO diretor;



-- ---------------------------------------------
-- [12] TRANSACOES
-- Nao incluir aqui
-- Usar/entregar o modelo proprio para esse topico