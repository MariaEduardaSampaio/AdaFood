# AdaFood 🍔

Este projeto é um gerenciador simples de dados de entregadores desenvolvido como Web API em C#. A API utiliza Controllers, Filters e faz a validação de dados por meio de Data Annotations personalizadas.

## Funcionalidades Principais 🚀

- **Rotas HTTP:** Foram implementadas rotas HTTP de Get, Post, Put e Delete para manipulação dos dados de entregadores.
- **Integração com API Externa:** A rota de adicionar um pedido a um entregador faz uso da API https://brasilapi.com.br/docs para coletar o CEP do local de entrega do pedido e retornar o endereço completo para o entregador.
- **Autorização:** Certas rotas possuem filtros de autorização, sendo necessário incluir no Header uma chave "Role" com valor "Admin" para acesso.
- **Persistência de Dados:** As alterações nos dados dos entregadores são salvas em um arquivo JSON, contendo 30 dados aleatórios gerados previamente pelo https://generatedata.com/generator.
- **Tratamento de Exceções:** O projeto possui um filtro que trata as exceções lançadas, retornando uma mensagem mais amigável para o usuário.

## Como Utilizar 🛠️

Ao clonar o repositório, basta rodar o projeto para poder submeter as requisições pelo Swagger (que abre automaticamente) ou por outras ferramentas, como Postman ou Insomnia.

## Contato 👩‍💻

[Email](mailto:mariaeduardamrs0@gmail.com)

[Github](https://github.com/MariaEduardaSampaio)       

[LinkedIn](https://www.linkedin.com/in/maria-eduarda-sampaio-955087213/)
