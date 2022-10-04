### **Passando Parâmetros para Resolver**

Quando chegar a hora de resolver os serviços , talvez seja necessário passar parâmetros para a resolução.

Os métodos `Resolve()`aceitam os mesmos tipos de parâmetros disponíveis no momento do registro usando uma lista de argumentos de comprimento variável.

Existem outras maneira utilizando `Delegate` e `Func<>`, mas serão vista somente mais a frente.

**Tipos:**

- `NamedParameter` relaciona aos parâmetros de destino por nome;
- `TypedParameter` relaciona aos parâmetros de destino por tipo;
- `ResolvedParameter` correspondência de parâmetros flexível

`NamedParameter`e `TypedParameter` podem fornecer apenas valores constantes.

`ResolvedParameter` pode ser usado como uma forma de fornecer valores recuperados dinamicamente do contêiner, por exemplo, resolvendo um serviço pelo nome.

### **Parâmetros com componentes de reflexão**

Quando você resolve um componente baseado em reflexão, o construtor do tipo pode exigir um parâmetro que você precisa especificar com base em um valor de tempo de execução, algo que não está disponível no momento do registro. Você pode usar um parâmetro no `Resolve()` para fornecer esse valor.

```csharp
public class Cliente: IPessoa
{
	Guid _id;
	string _nome;

	public Cliente(string nome)
	{
		_nome = nome;
	}

	public Cliente(string nome,Guid id)
	{
		_nome = nome;
		_id = id;
	}
}
```

Você poderia passar um parâmetro para a `Resolve()`chamada assim:

```csharp
var cliente = scope.Resolve<IPessoa>(**new** NamedParameter("nome", "Fulano"));
```

Assim como os parâmetros em tempo de registro , o `NamedParameter`no exemplo será mapeado para o parâmetro do construtor nomeado correspondente.

A estrutura do `NamedParameter` é a seguinte: `NamedParameter("nome_parametro_no_contrutor", valor);` 

Se você tiver mais de um parâmetro, basta passá-los por meio do `Resolve()`método:

```csharp
var service = scope.Resolve<AnotherService>(
                **new** NamedParameter("nome", "Fulano"),
                **new** TypedParameter(**typeof**(Guid), Guid.NewGuid()));
```

### **Parâmetros com componentes de expressão lambda**

Com os registros de componentes de expressão lambda, é necessário adicionar o tratamento de parâmetros dentro de sua expressão lambda.

Na expressão de registro do componente, você pode usar os parâmetros de entrada alterando a assinatura de delegado usada para registro. Em vez de apenas pegar um `IComponentContext`parâmetro, pegue um `IComponentContext`e um `IEnumerable<Parameter>`:

```csharp

```

Agora, quando você resolver o `IConfigReader`, seu lambda usará os parâmetros passados:

```csharp

```

### **Passando parâmetros sem chamar explicitamente o Resolve()**

O Autofac suporta dois recursos que permitem gerar automaticamente “fábricas” de serviço que podem receber listas de parâmetros fortemente tipadas que serão usadas durante a resolução. Essa é uma maneira um pouco mais limpa de criar instâncias de componentes que exigem parâmetros.

- [As Fábricas Delegadas](https://autofac.readthedocs.io/en/latest/advanced/delegate-factories.html) permitem que você defina métodos delegados de fábrica.
- O [tipo de relacionamento implícito](https://autofac.readthedocs.io/en/latest/resolve/relationships.html) `Func<T>` pode fornecer uma função de fábrica gerada automaticamente.