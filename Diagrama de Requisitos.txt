Visão Geral do Sistema: O sistema deve registrar as chamadas (ocorrências) feitas ao departamento de informática da empresa. Às ocorrências são atribuídas informações relacionadas ao departamento que reportou a ocorrência e, também, do funcionário alocado para resolver a ocorrência registrada. A visualização das ocorrências é atribuída aos gerentes e funcionários relacionados a ocorrências. A visualização dos departamentos somente é atribuída ao diretor.
Requisitos Funcionais

R1 - O sistema deve manter o cadastro de departamentos, realizado pelo diretor, assim como sua edição e exclusão. As informações a serem guardadas são: código, nome e descrição.

R2 - O sistema deve manter o cadastro de funcionários; e as informações a serem guardadas são: matrícula, nome, departamento ao qual pertence, status (campo texto informando se o funcionário está ativo ou inativo).

R3 - O sistema deve manter o cadastro de gerente de departamento; e as informações a serem guardadas são: matrícula, nome, departamento o qual gere, status (campo texto informando se o gerente está ativo ou inativo). O gerente será responsável por registrar e editar cadastros de funcionários.

R4 - O sistema deve manter o cadastro de diretor; e as informações a serem guardadas são: matrícula, nome, status (campo texto informando se o diretor está ou não em exercício).

R5 - O sistema deve manter o registro, edição e exclusão de ocorrências, realizado pelo gerente do departamento reportante; e cada ocorrência deve conter: número, descrição, data da ocorrência, departamento reportante (código), funcionário alocado (matrícula), data limite para solução, status temporário (campo texto, alterável pelo funcionário alocado, informando se a ocorrência está aberta ou encerrada), status definitivo (campo texto, alterável pelo gerente do departamento reportante, informando se a ocorrência está aberta ou encerrada).

R6 - Validação: Ao registrar uma ocorrência, é necessário validar a data da ocorrência para que não seja possível informar uma data futura; já com relação a data limite para solução da ocorrência, deve ser obrigatoriamente uma data futura; além disso, o funcionário alocado deve necessariamente ser do departamento de informática.
