namespace Domain.Dtos;

public class Author
{
    public int id { get; set; }
    public string firstname  { get; set; }
    public string lastname  { get; set; }

}

public class GetAuthor
{
    public int id { get; set; }
    public string firstname  { get; set; }
    public string lastname  { get; set; }
    public string bookname  { get; set; }
    public string fullname { get; set; }


}