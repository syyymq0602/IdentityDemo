using System;
using System.ComponentModel.DataAnnotations;
using BooksAppStore.DomainSharedAuthors;

namespace BooksAppStore.Authors.DTOs
{
    public class UpdateAuthorDto
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        public string ShortBio { get; set; }
    }
}