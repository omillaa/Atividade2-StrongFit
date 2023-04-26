using Microsoft.EntityFrameworkCore;
namespace Atividade2.Models
{
    public class SeedData
    {
        public static void popularBancoDeDados(IApplicationBuilder app)
        {
            Contexto contexto = app.ApplicationServices.GetRequiredService<Contexto>();
            contexto.Database.Migrate();
            //if (!contexto.Alunos.Any())
            //{
            //    var personal = new Personal
            //    {
            //        Nome = "Ana",
            //        Especialidade = "Hipertrofia"
            //    };
            //    contexto.Personais.Add(personal);
            //    contexto.SaveChanges();
            //    var idPersonalId = personal.PersonalId;
            //    contexto.Alunos.AddRange(
            //       new Aluno
            //       {
            //           Nome = "Larissa",
            //           DataNasc = new DateTime(2002, 11, 25),
            //           Instagram = "laripsilva16",
            //           Telefone = "35999999999",
            //           PersonalId = idPersonalId,
            //           Observações = "Treino de Musculação",
            //       });
            //    contexto.Exercicio.AddRange(
            //        new Exercicio
            //        {
            //            NomeExer = "Agachamento Livre",
            //            Categoria = "Inferiores",
            //            Descricao = "Agachamento com a barra livre"
            //        }); 
            //    contexto.Treinos.AddRange(
            //        new Treino
            //        {
            //            AlunoId = 1,
            //            Data = new DateTime(2023, 07, 04),
            //            Hora = new DateTime().AddHours(12),
            //        });
                
                contexto.SaveChanges();
            }
        }
    }
