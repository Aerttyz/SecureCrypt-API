# SecureCrypt-API

API de criptografia e descriptografia RSA

## Documentação da API

#### Retorna mensagem criptografada

```http
  POST /RSA/encrypt
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `message` | `string` | **Obrigatório**. Mensagem a ser criptografada |

#### Retorna a mensagem descriptografada

```http
  POST /RSA/decrypt
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Valor criptografado  `      | `List<int>` | **Obrigatório**. Mensagem a ser descriptografada |


