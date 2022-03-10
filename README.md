# quadrinhos

API desenvolvida para um loja de venda de quadrinhos

- 2 tipos de usuários
  - adm: permissão de cadastrar e alterar um quadrinho
  - cliente: permissão de comprar quadrinhos
  
- Restrição de endpoints
  - Se não houver token de autenticação, se o token for inválido ou se o usuário não tiver a função necessária, a api retornará 401 (Unauthorized) ou 403 (Forbidden)
  
- Autenticação no Swagger
  - Bearer + token gerado no login
 
 OBS:
 - no cadastro do usuário passar 'adm' ou 'cliente' no campo Role
