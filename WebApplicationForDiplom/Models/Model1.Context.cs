﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationForDiplom.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class diplomEntities1 : DbContext
    {
        public diplomEntities1()
            : base("name=diplomEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        public virtual DbSet<КодыИдентификацииОтходов> КодыИдентификацииОтходов { get; set; }
        public virtual DbSet<Контейнеры> Контейнеры { get; set; }
        public virtual DbSet<ОтходыПоКоду> ОтходыПоКоду { get; set; }
        public virtual DbSet<ПартииОтходов> ПартииОтходов { get; set; }
    }
}
