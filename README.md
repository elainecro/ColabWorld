# ColabWorld
Construção do Mini Mundo Globalsys

## Mini-Mundo

As Empresas XPTO e ABCD tem a necessidade de controlar os colaboradores onde as empresa poderão controlar o cadastramento, alteração, exclusão e demissão desse colaborador no sistema.
O sistema tem que efetuar todos os tipos de validação como CPF e CNPJ, ainda deve obter máscara nos campos para facilitar o preenchimento dos dados no formulário.
Obs.: Caso o colaborador seja demitido, ele pode retorna para empresa novamente, tem que gerar histórico dessas informações para saber por quais empresas esse funcionário passou.


## Escopo do Software

Preciso que você elabore a analise dos dados do sistema atendendo os principais requisitos abaixo:

### UML – Linguagem de modelagem unificadas

- Um diagrama de Caso de Uso:
-- 3 casos de usos.
-- Descrição dos casos de uso.

- Diagrama de Classes

### Execução/Desenvolvimento do Software:
- Nome do projeto
-- Seu nome + data hoje;

- O sistema deverá ser desenvolvido
-- C#;
-- Arquitetura WEB.


- Você deve efetuar a persistência
- O sistema tem que ser modularizado

- Empresa
-- Nome da empresa;
-- CNPJ;
-- Validar CNPJ.
-- Data de cadastro;
-- Razão social.

- Pessoa
-- Nome da Pessoa;
-- CPF;
-- Validar o CPF.
-- Data de Nascimento;
-- Data de cadastro.

- Colaborador
-- Pessoa;
-- Empresa;
-- Salario;
-- Status;
-- Data de cadastro;
-- Data de demissão;
-- Cargo/Função;
