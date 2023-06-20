using Login.Domain.Entity;
using Login.Infrastructure.Interface;
using Login.Infrastructure.Logger;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace Login.Infrastructure.DbContextData
{
    public partial class FacturacionDbContext : DbContext, IFacturacionDbContext
    {
        private readonly string _connectionString;

        #region Constructores

        public FacturacionDbContext(DbContextOptions<FacturacionDbContext> options)
          : base(options)
        {

        }

        public FacturacionDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Propiedades

        public DbSet<UserBase> Enterprise { get; set; }

        #endregion

        #region Sobrecargas

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { //Para uso de Migrations y Testing              
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Para uso de Migrations
            modelBuilder.Entity<UserBase>(entity =>
            {
                entity.Property(e => e.Id);

                entity.ToTable("enterprise");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion

        #region Implementaciones

        public UserBase GetEnterpriseWithTokens(User enterprise, ILogAzure log)
        {
            Stopwatch timeT = new Stopwatch();
            timeT.Start();

            try
            {
                SqlParameter userParameter = new SqlParameter
                {
                    ParameterName = "@username",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = enterprise.Username
                };

                SqlParameter passwordParameter = new SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = enterprise.Password
                };

                //Arreglo de todos los parametros
                SqlParameter[] parameters = new SqlParameter[]
                {
                    userParameter,
                    passwordParameter
                };

                IEnumerable<UserBase> result = this.Enterprise
                          .FromSqlRaw("EXEC dbo.uspUserApplicationInternalValidateUser @username, @password; ",
                                   parameters)
                          .AsEnumerable();

                UserBase? row = result.FirstOrDefault();

                timeT.Stop();

                log.WriteComment(MethodBase.GetCurrentMethod().Name, "Login", LevelMsn.Info, timeT.ElapsedMilliseconds);

                return row;
            }
            catch (Exception ex)
            {
                timeT.Stop();

                log.WriteComment(MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(ex), LevelMsn.Error, timeT.ElapsedMilliseconds);

                return null;
            }
        }

        #endregion
    }
}
