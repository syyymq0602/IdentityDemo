import { Component, OnInit } from '@angular/core';
import { BookService } from '@proxy/app-services';
import { BookDto } from '@proxy/books-contracts/dtos';
import { ListService, PagedResultDto } from '@abp/ng.core';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [ListService],
})
export class BookComponent implements OnInit {
  book = {
    items: [],
    totalCount : 0
  } as PagedResultDto<BookDto>
  
  constructor(public readonly list:ListService, private bookService: BookService) { }

  ngOnInit(): void {
    const bookStreamCreator = (query) => this.bookService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });
  }
}
