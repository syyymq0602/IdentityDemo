using Volo.Abp.Application.Dtos;

namespace BooksAppStore.Authors.DTOs
{
    public class GetAuthorListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}