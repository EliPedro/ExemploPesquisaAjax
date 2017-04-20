using System;
using System.Collections.Generic;
using PesquisaComAjax.Domain.Entities;
using PesquisaComAjax.Domain.Interfaces.Repositories;
using System.Linq;
using System.Data.SqlClient;

namespace PesquisaComAjax.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        
        public IEnumerable<Produto> PesquisarPorNome(string nome)
        {
            return _Db.Produtos.Where(p => p.Nome == nome);
        }  
        
        public byte[] ObterImagens()
        {
            var produtos = (from c in _Db.Produtos
                            select c).FirstOrDefault();
            //byte[] foto = null;

            //foreach(var item in produtos)
            //{
            //    foto = item.Imagem;
            //}

            //return foto;

            return produtos.Imagem;
        }


        public byte[] ObterImg()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\elipe\Desktop\ASP.NET\ExemploPesquisaAjax\PesquisaComAjax\PesquisaComAjax.Mvc\App_Data\DbPesquisaDB.mdf;Initial Catalog=DbPesquisaDB;Integrated Security=True";

            var comando = @"Select Imagem From Produto";

            using (var cnn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(comando, cnn);

                cnn.Open();

                byte[] foto = null;

                foto = (byte[])cmd.ExecuteScalar();

                return foto;
            }

        }
    }
}
