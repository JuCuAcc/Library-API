import { Component, OnInit } from '@angular/core';

import { from, Observable } from 'rxjs';
import { Author } from './author';
import { Router } from '@angular/router';
import { AuthorService } from './author.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  dataSaved = false;
  authorForm: any;
  allAuthor: Observable<Author[]>;
  authorIdUpdate = null;
  message = null;

  constructor(private formBuilder: FormBuilder, private routes: Router,
    private authorService: AuthorService) { }

  ngOnInit() {
    this.authorForm = this.formBuilder.group({
      authorName: ['', [Validators.required]],
      doB: ['', [Validators.required]],
      contactNo: ['', [Validators.required]],
      email: ['', [Validators.required]],
      isActive: [false],
    });
    this.loadAllAuthor();
  }

  loadAllAuthor() {
    this.allAuthor = this.authorService.getAllAuthor();
  }

  onFormSubmit() {
    this.dataSaved = false;
    const author = this.authorForm.value;
    this.createAuthor(author);
    this.authorForm.reset();
  }

  loadAuthorToEdit(authorId: any) {
    this.authorService.getAuthorById(authorId).subscribe(author => {
      this.message = null;
      this.dataSaved = false;
      this.authorIdUpdate = author.authorId;
      this.authorForm.get("authorName").setValue(author["authorName"]);
      this.authorForm.get("contactNo").setValue(author["contactNo"]);
      this.authorForm.get("doB").setValue(author["doB"]);
      this.authorForm.get("email").setValue(author["email"]);
      this.authorForm.get("isActive").setValue(author["isActive"]);
    })
  }
  createAuthor(author: Author) {
    if (this.authorIdUpdate == null) {
      this.authorService.createAuthor(author).subscribe(
        () => {
          this.dataSaved = true;
          this.message = "Record Saved Successfully!!!!!";
          this.loadAllAuthor();
          this.authorIdUpdate = null;
          this.authorForm.reset();
        }
      )
    }

    else {
      author.AuthorId = this.authorIdUpdate;
      this.authorService.updateAuthor(this.authorIdUpdate, author).subscribe(() => {
        this.dataSaved = true;
        this.message = "Record Updated Successfully!!!!!";
        this.loadAllAuthor();
        this.authorIdUpdate = null;
        this.authorForm.reset();
      })
    }
  }

  deleteAuthor(id: string) {
    if (confirm("Are You Sure You Want To Delete This Data?")) {
      this.authorService.deleteAuthor(id).subscribe(() => {
        this.dataSaved = true;
        this.message = "Record Deleted Successfully!!!!!";
        this.loadAllAuthor();
        this.authorIdUpdate = null;
        this.authorForm.reset();
      })
    }
  }

  resetForm() {
    this.authorForm.reset();
    this.message = null;
    this.dataSaved = false;
  }

}
