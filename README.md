# DescontroladaAPI

Trata-se de um CRUD de Catálogo de Produtos de uma varejista chamada Descontrolada®.
O projeto utiliza: 
  * .NET Core com C# na versão 6.0 
  * EntityFrameworkCore na versão 6.0.4
  * EntityFrameworkCore.InMemory na versão 6.0.4 para armazenamento dos dados em memória. 
O projeto contém o BackEnd da aplicação, enquanto o FrontEnd está no repositório DescontroladaFrontend (https://github.com/onequeiroz/DescontroladaFrontEnd).

# Demanda

1. Página para o cadastro dos produtos, que deve apresentar os campos: nome, preço de venda, descrição, quantidade, tipo* e data de cadastro.
  * *A varejista comercializa dois tipos de produto:
    * Orgânico e;
    * Não orgânico.

2. Página para exibição dos produtos cadastrados, que deverá mostrar apenas 5 itens por página (de uma grid/tabela).
3. O sistema também deve possuir um menu que permita a navegação entre as duas páginas.

# Rodando a aplicação

Para que a aplicação seja executada, é preciso que tanto o FrontEnd quanto o BackEnd estejam rodando. 
Como a aplicação utiliza armazenamento em memória, alguns pontos precisam ser levados em consideração:
  * Não há dados cadastrados inicialmente, ou seja, é necessário cadastrar dados para visualizar a tabela;
  * Sempre que a aplicação for reiniciada, os dados serão perdidos.
