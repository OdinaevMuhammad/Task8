namespace infrastructure.Services;
using Dapper;
using Npgsql;
using Domain.Dtos;
public class AuthorService
{
     private readonly DapperContext _context;

    public AuthorService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<GetAuthor>> GetAuthors()
    {
       using (var conn = _context.CreateConnection())
        {
            var sql = $"select a.id, a.first_name as firstname, a.last_name as lastname " +
                      $"from authors as a ";
       

            var  result =  conn.Query<GetAuthor>(sql).ToList();
            return result;
            
        }
    }

    public  int  InsertAuthor(Author Author)
    {
      using (var conn = _context.CreateConnection())
        {
            var sql = 
              $"INSERT INTO authors (first_name,last_name) VALUES " +
              $"('{Author.firstname} '," + 
              $"'{Author.lastname}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
        public int UpdateAuthor(Author Author)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = 
                    $"UPDATE authors SET " +
                    $"first_name = '{Author.firstname}' ," + 
                    $"last_name = '{Author.lastname}'" + 
                    $"where id = {Author.id}";


                var result = conn.Execute(sql);

                return result;
            }
        }
        public int DeleteAuthor(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"DELETE FROM Authors WHERE id = {id} ";

                var result = conn.Execute(sql);

                return result;
            }
        }
}