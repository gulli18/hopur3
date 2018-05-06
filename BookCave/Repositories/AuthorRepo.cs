using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Repositories
{
  public class AuthorRepo
  {
    private DataContext _db;

    public AuthorRepo()
    {
      _db = new DataContext();
    }

    public List<AuthorListViewModel> GetAllAuthors()
    {   var booklist = (from a in _db.Authors
                          join ar in _db.Books
                          on a.Id equals ar.AuthorsId
                          select new BookListViewModel
                          {
                            Id = ar.Id,
                            Title = ar.Title
                          }).ToList();

          var authors = (from a in _db.Authors
                         select new AuthorListViewModel
                         {
                           Id = a.Id,
                           Name = a.Name,
                           Nationality = a.Nationality,
                           Book = booklist
                         }).ToList();

          return authors;
    }

    public AuthorListViewModel GetAuthor()
    {
      var booklist = (from a in _db.Authors
                          join ar in _db.Books
                          on a.Id equals ar.AuthorsId
                          select new BookListViewModel
                          {
                            Id = ar.Id,
                            Title = ar.Title
                          }).ToList();
                    
       var oneAuthor = (from a in _db.Authors
                        //where a.Id == id
                        select new AuthorListViewModel
                        {
                          Id = a.Id,
                          Name = a.Name,
                          Nationality = a.Nationality,
                          Book = booklist
                        }).SingleOrDefault();             
      return oneAuthor;
    }

  }
}