import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Book {
  bookTitle: string;
  publisher: string;
  authors: string;
  type: string;
  isbn: string;
  category: string;
  availableCopies: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public books: Book[] = [];
  public searchs: any = [{ id: 'Select' }, { id: 'Author' }, { id: 'ISBN' }, { id: 'Category' }];
  public searchValue: string = '';
  public selectedOption: string = 'Select';

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }
  
  //validateFile(eventFile: any) {
  //  var files = eventFile.target.files;
  //  if (files.length == 1 && files[0].name.endsWith(".txt")) {
  //    this.file = files[0];
  //    this.isValidFile = true;
  //  }
  //  else {
  //    this.isValidFile = false;
  //    this.books = [];
  //  }
  //}

  //getBooksData() {
  //  this.books = [];
  //  let fileReader = new FileReader();
  //  let stringValue: string;
  //  fileReader.onload = (e) => {
  //    stringValue = (fileReader.result as string).replace(/(?:\r\n|\r|\n)/g, ',');
  //    this.getBooksDataApi(stringValue);
  //  }
  //  fileReader.readAsText(this.file);
  //}

  getBooksDataApi() {
    let params = new HttpParams();
    params = params.append('searchBy', this.selectedOption);
    params = params.append('searchValue', this.searchValue);

    this.http.get<Book[]>('/book', { params: params }).subscribe(
      (result) => {
        this.books = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Books';
}
