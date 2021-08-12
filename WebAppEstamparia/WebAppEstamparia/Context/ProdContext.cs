using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppEstamparia.Models;

namespace WebAppEstamparia.Context
{   // Install-Package EntityFramework
    // Criar connectionString no web.config
    // Enable-Migration
    // Adicionar uma prop tipo DbSet neste arquivo de Contexto
    // Add-Migration (Para cada novo model)
    // Update-Database - Alterar o banco
    public class ProdContext : DbContext
    {
        public DbSet<Producao> Producao { get; set; }
        public DbSet<Operador> Operador { get; set; }
        public ProdContext() : base("ProdConnection")
        {

        }
    }
}