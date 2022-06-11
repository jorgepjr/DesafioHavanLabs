Resumo:
O teste consiste em desenvolver uma API para gerar pré-vendas, nela é possível realizar todas as operações 
persistências (CRUD) relacionadas as entidades Produtos e Clientes, além de gerar uma pré-venda para 
um determinado cliente contendo os produtos que ele deseja comprar.

Desafio:
No projeto base da API você encontrará funcionando as tabelas Produto e Cliente e realizando os cadastros 
essenciais, porém deverá melhorar o processo conforme os pontos abaixo: 

1. Criar um modelo de conversão das informações que a API irá receber e nela colocar as validações 
dos campos, o famoso DTO.

2. Adicionar uma controller que receberá os dados do cliente e uma lista de produtos que o cliente está 
comprando.

3. Validar se o cliente informado está cadastrado. Se não estiver, retornar uma mensagem solicitando o 
cadastro. 

4. Validar se os produtos informados existem no banco. Se não existirem, retornar uma mensagem 
informando que o produto não existe.

5. Validar se a quantidade do (s) produto (s) é maior ou igual a informada na compra, se sim, realizar a 
baixa desta quantidade, se não, retornar uma mensagem informado que não há saldo disponível.

6. Após as validações, realize a gravação da pré-venda e retorne um objeto que contenha o valor total 
da venda e a quantidade de itens.

Observações:
Importante salientar que não é necessária concluir o desenvolvimento da API, entretanto, quanto mais 
completo conseguir e não se preocupe com a forma de desenvolvimento. Pedimos para desenvolva da sua 
maneira como faria no seu dia a dia.

Diferencial: 
No cadastro do cliente quando for informado o CEP, consultar em alguma API pública, por exemplo, 
viacep, os dados do endereço do cliente e no modelo alterar para apenas receber o CEP.
Criar uma camada de testes unitário para os serviços do Produto, Cliente e Pré-venda