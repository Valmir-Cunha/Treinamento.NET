## Componentes por Lambda Expression

O Autofac também aceita um delegate ou uma expressão lambda como criador de componentes:

```csharp
builder.Register(c => new A(c.Resolve<B>()));
```

O parâmetro `c` fornecido para a expressão é o contexto do componente, um objeto `IComponentContext`, no qual o  componentes está sendo criado. 

Dependências adicionais podem ser satisfeitas usando este parâmetro de contexto, no exemplo, `A`requer um parâmetro construtor do tipo `B`que pode ter dependências adicionais.

Além de usar o  `IComponentContext` para resolver dependências na expressão, também é possível o `Register` para especificar dependências como um número variável de argumentos para a expressão e o Autofac irá resolve-los.

```csharp
builder.Register((IDependency1 dep1, IDependency2 dep2) => **new** Component(dep1, dep2));
```

Abaixo estão alguns exemplos de requisitos mal atendidos pela criação de componentes por reflection, mas bem abordados por expressões lambda.

**Parâmetros complexos:**

Os parâmetros do construtor nem sempre podem ser declarados com valores constantes simples.

```csharp
builder.Register(c => new UserSession(DateTime.Now.AddMinutes(25)));
```

**Injeção de propriedades:**

Também o possível utilizar expressões e inicializadores de propriedades para preencher propriedades:

```csharp
builder.Register(c => new A(){ MyB = c.ResolveOptional<B>() });
```

O `ResolveOptional`método tentará resolver o valor, mas não lançará uma exceção se o serviço não estiver registrado.

**Importante:** **A injeção de propriedade não é recomendada na maioria dos casos.** Alternativas como o padrão Null Object , construtores sobrecarregados ou valores padrão de parâmetro do construtor tornam possível criar componentes mais limpos e “imutáveis” com dependências opcionais usando injeção de construtor.

**Seleção de uma implementação por valor de parâmetro:**

Um dos grandes benefícios de isolar a criação de componentes é que o tipo de concreto pode ser variado. Isso geralmente é feito em tempo de execução, não apenas em tempo de configuração:

```csharp
builder.Register<CreditCard>(
  (c, p) =>
    {
      var accountId = p.Named<string>("accountId");
      if (accountId.StartsWith("9"))
      {
        return new GoldCard(accountId);
      }
      else
      {
        return new StandardCard(accountId);
      }
    });
```

Neste exemplo, `CreditCard`é implementado por duas classes `GoldCard`e `StandardCard`- qual classe é instanciada depende do ID da conta fornecido em tempo de execução.

Os parâmetros são fornecidos à função de criação por meio de um segundo parâmetro opcional chamado`p` neste exemplo.

A utilização seria assim:

```csharp
var card = container.Resolve<CreditCard>(new NamedParameter("accountId", "12345"));
```

`NamedParameter`- É utilizado para corresponder aos parâmetros de destino por nome.