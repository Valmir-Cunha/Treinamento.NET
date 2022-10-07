﻿using RegistroDependencias.Servicos;

namespace RegistroDependencias.Componentes
{
    public class Class2 : IService2
    {
        public Guid Id { get; set; }

        public Class2()
        {
            Console.WriteLine(this.GetType());
            Id = Guid.NewGuid();
        }
        public void Dados2()
        {
            Console.WriteLine(Id);
        }
    }
}
