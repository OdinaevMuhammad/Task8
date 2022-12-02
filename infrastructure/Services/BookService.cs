namespace infrastructure.Services;
using Dapper;
using Npgsql;
using Domain.Dtos;
public class BookService
{
    private readonly DapperContext _context;

    public BookService(DapperContext context)
    {
        _context = context;
    }

    public List<GetAuthor> GetBooks()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql =  $"select b.id,  b.book_name as bookname, Concat(a.last_name , ' ' , a.first_name )  as fullname " +
                      $"from books as b " +
                      $"join authors as a " +
                   $"on a.id = b.author_id";

            var result = conn.Query<GetAuthor>(sql).ToList();
            return result;
            
        }
    }

    public int InsertBook(Book Book)
    {
       using (var conn = _context.CreateConnection())
        {
            var sql = 
              $"INSERT INTO Books (author_id,book_name) VALUES " +
              $"({Book.authorid}," + 
              $"'{Book.bookname}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
        public int UpdateBook(Book Book)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = 
                    $"UPDATE Books SET " +
                    $"author_id = {Book.authorid} ," + 
                    $"Book_name = '{Book.bookname} '" + 
                    $"where id = {Book.id}";

                var result = conn.Execute(sql);

                return result;
            }
        }
               public int DeleteBook(int id)
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"DELETE FROM Authors WHERE id = {id} ";

                var result = conn.Execute(sql);

                return result;
            }
        }
}