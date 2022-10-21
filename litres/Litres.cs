using System.Data;
using System.Xml;

namespace litres;

public class Litres
{
    private readonly Dictionary<string, Book> _books;
    
    public Litres()
    {
        _books = new Dictionary<string, Book>();

        var settings = new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Ignore
        };
        using (XmlReader xr = XmlReader.Create(@"/home/ilay/Downloads/audio_all.xml", settings))
        {
            int id = 0;
            string name = "";
            string url = "";
            string author = "";
            string description = "";
            string element = "";

            while (xr.Read())
            {
                switch (xr.NodeType)
                {
                    case XmlNodeType.Element:
                    {
                        element = xr.Name;
                        if (element == "offer") {
                            id = int.Parse(xr.GetAttribute("id"));
                        }

                        break;
                    }
                    case XmlNodeType.Text:
                        switch (element)
                        {
                            case "name":
                                name = xr.Value;
                                break;
                            case "url":
                                url = xr.Value;
                                break;
                            case "author":
                                author = xr.Value;
                                break;
                            case "description":
                                description = xr.Value;
                                break;
                        }

                        break;
                    case XmlNodeType.EndElement when xr.Name == "offer":
                        if (!_books.ContainsKey(name))
                        {
                            _books.Add(name, new Book(id, name, url, author, description));
                        }
                        break;
                }
            }
        }
    }

    public Book FindBook(string name)
    {
        if (!_books.ContainsKey(name))
        {
            throw new DataException();
        }

        return _books[name];
    }
}