### CP5 - 2TDSPK - ADVANCED BUSINESS DEVELOPMENT WITH .NET - 2024

<div align="center">
<img src="https://drive.google.com/uc?export=view&id=1te3dDY7rx354MWPYPlTiwBQxJFF1YN_A" alt="Descrição da Imagem">
</div>

## Objetivo
Desenvolver uma WebAPI em .NET que realize um CRUD no MongoDB para uma entidade de sua escolha, aplicando boas práticas de arquitetura e implementação.

## Integrantes do Grupo
•⁠  ⁠**Luiz Fellipe Soares de Sousa Lucena** - RM: 551365

•⁠  ⁠**Nina Rebello Francisco** - RM: 99509

## Entidade
A entidade principal utilizada para este projeto é *Cachorro*, com os seguintes atributos:
- **Id**: Identificador único.
- **Nome**: Nome do cachorro.
- **Raça**: Raça ou "SRD" (sem raça definida).
- **Idade**: Idade em anos ou meses.
- **Tamanho**: Pequeno, Médio, ou Grande.
- **Peso**: Peso do cachorro.
- **Sexo**: Macho ou Fêmea.
- **Castrado**: Indicador se o cachorro é castrado (booleano).
- **Vacinado**: Indicador se o cachorro está vacinado (booleano).
- **Descrição**: Descrição breve sobre o cachorro.
- **Data de Chegada**: Data em que o cachorro chegou ao abrigo.
- **Status de Adoção**: Disponível, Reservado ou Adotado.
- **Foto**: URL da foto do cachorro.
- **Histórico Médico**: Informações médicas relevantes.

## Documentação da API - Swagger
A documentação interativa da API é gerada automaticamente pelo Swagger e estará disponível ao rodar o projeto. Basta acessar o navegador no endereço: `http://localhost:<porta>/swagger` para visualizar e testar os endpoints da API.

## Arquitetura
### Escolha da Arquitetura: Monolítica
#### Justificativa:
Optamos por uma arquitetura monolítica por sua simplicidade e menor complexidade, o que a torna adequada para um projeto acadêmico com uma equipe reduzida. A arquitetura monolítica facilita a integração entre os componentes, reduzindo a necessidade de comunicação entre serviços separados e proporcionando um desenvolvimento mais rápido.
Embora não seja a solução mais escalável para projetos maiores, ela oferece vantagens como uma visão unificada da aplicação, simplificando o monitoramento e a depuração.

## Design Patterns Utilizados
- **Padrão Repository**: Facilita a abstração do acesso a dados, separando a lógica de negócios da camada de persistência.
- **Padrão MVC**: Segrega as responsabilidades da aplicação em Model, View e Controller, permitindo uma organização clara entre a lógica de negócios e a interface de usuário.
- **Padrão Singleton**: Usado para garantir que apenas uma instância de certos serviços centrais seja criada, como o serviço de banco de dados.

## Instruções para Rodar a API
### Pré-requisitos
- **.NET SDK**: Certifique-se de ter o .NET SDK instalado. Você pode baixar a versão mais recente no [site oficial do .NET](https://dotnet.microsoft.com/download).
- **MongoDB**: O projeto utiliza MongoDB como banco de dados NoSQL. Certifique-se de ter uma instância do MongoDB rodando localmente ou em um serviço de nuvem (como MongoDB Atlas) e configure a string de conexão no arquivo `appsettings.json` conforme a necessidade.

1.⁠ ⁠*Clone o Repositório*
```bash
git clone https://github.com/2TDSPK-2024/CP5/tree/RM551365
```
2.⁠ ⁠*Navegue até o diretório do projeto*
```sh
 cd RM551365
```
3.⁠ ⁠*Restaure as dependências*
Execute o seguinte comando para restaurar os pacotes NuGet:
```sh
 dotnet restore
```
4.⁠ ⁠*Execute a aplicação*
Use o seguinte comando para rodar a aplicação:
```sh
 dotnet run
```
5.⁠ ⁠*Acesse o Swagger*
No navegador, abra o endereço ⁠ ```http://localhost:<porta>/swagger``` para acessar a documentação da API e realizar testes.

## Propósito
“Faça o teu melhor, na condição que você tem, enquanto você não tem condições
melhores, para fazer melhor ainda”
Mario Sergio Cortela
