# Conceito de registros

O registro de componentes com Autofac é feito criando um `ContainerBuilder` e informando a ele qual componentes expõe qual serviço.

Os componentes podem ser registrados de algumas maneiras:

1. Reflection, fornecendo uma instância pronta;
2. Lambda Expression, usando uma função anônima que é executa para instanciar;

Para o registro dos componentes, o `ContainerBuild` possui vários métodos `Register()`.

Cada componente expõe um ou mais **serviços,** que são conectados usando os métodos `As()` do `ContainerBuilder`.

## Componentes por Reflection:

Como dito anteriormente, o registro de componentes por Reflection retorna uma instância, mas há alguns tipos de registros que podem ser feitos.

### **Registro por tipo:**

Componentes gerados por reflexão são normalmente registrados por tipo:

```csharp
var builder = new ContainerBuilder();
builder.RegisterType<Class1>(); // Maneira 1
builder.RegisterType(typeof(Class2)); // Maneira 2
```

**Nota importante:** Qualquer tipo de componente que for registrado por meio e `RegisterType`deve ser um tipo concreto. Embora os componentes possam expor classes abstratas ou interfaces como serviços , você não pode registrar um componente abstrato/interface.

Ao usar componentes baseados em reflexão, o Autofac usa automaticamente o construtor que possui a maioria dos parâmetros que podem ser obtidos do contêiner para instanciar sua classe.

Para entender um pouco mais sobre essa escolha, assista o seguinte vídeo: [**Aqui**](https://youtu.be/i8ZKv-XjI5w)

Porém, mesmo com a escolha automática feita pelo Autofac,  é possível selecionar o construtor manualmente, utilizando o método `UsingConstructor` e passando os tipos dos parâmetros do construtor.

Existem outras maneiras de selecionar o construtor, mas são um pouco avançadas para o momento atual.

### Registro por instância:

O registro por instância trata-se de instanciar um objeto, da maneira que desejar, e logo após adicionar essa instância ao contêiner para utilização. Isso é feito usando o `RegisterInstance`.


**Implementação no projeto "RegistroDependencias"**