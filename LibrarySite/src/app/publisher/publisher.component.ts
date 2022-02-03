import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { Publisher} from './publisher';
import { PublisherService } from './publisher.service';

import { from, Observable } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})
export class PublisherComponent implements OnInit {
  dataSaved = false;
  publisherForm: any;
  allPublisher: Observable<Publisher[]>;
  publisherIdUpdate = null;
  message = null;
  constructor(private formBuilder: FormBuilder, private routes: Router,
    private publisherService: PublisherService) { }

  ngOnInit() {
    this.publisherForm = this.formBuilder.group({
      publisherName: ['', [Validators.required]],
      contactNo: ['', [Validators.required]],
      email: ['', [Validators.required]],
      isActive: [false]
    });
    this.loadAllPublisher();
  }
  loadAllPublisher() {
    this.allPublisher = this.publisherService.getAllPublisher();
  }

  onFormSubmit() {
    this.dataSaved = false;
    const publisher = this.publisherForm.value;
    this.createPublisher(publisher);
    this.publisherForm.reset();
  }

  loadPublisherToEdit(publisherId: any) {
    this.publisherService.getPublisherById(publisherId).subscribe(publisher => {
      this.message = null;
      this.dataSaved = false;
      this.publisherIdUpdate = publisher.publisherId;
      this.publisherForm.get('publisherName').setValue(publisher['publisherName']);
      this.publisherForm.get('contactNo').setValue(publisher['contactNo']);
      this.publisherForm.get('email').setValue(publisher['email']);
      this.publisherForm.get('isActive').setValue(publisher['isActive']);
    });
  }
  createPublisher(publisher: Publisher) {
    if (this.publisherIdUpdate == null) {
      this.publisherService.createPublisher(publisher).subscribe(() => {
        this.dataSaved = true;
        this.message = "Record Saved Successfully.";
        this.loadAllPublisher();
        this.publisherIdUpdate = null;
        this.publisherForm.reset();
      }
      )
    }
    else {
      publisher.PublisherId = this.publisherIdUpdate;
      this.publisherService.updatePublisher(this.publisherIdUpdate, publisher).subscribe(() => {
        this.dataSaved = true;
        this.message = "Record Update Successfully.";
        this.loadAllPublisher();
        this.publisherIdUpdate = null;
        this.publisherForm.reset();

      });
    }
  }

  deletePublisherById(id: string) {
    if (confirm("Are You Sure To Delete This?")) {
      this.publisherService.deletePublisherById(id).subscribe(() => {
        this.dataSaved = true;
        this.message = "Record Deleted Successfully.";
        this.loadAllPublisher();
        this.publisherIdUpdate = null;
        this.publisherForm.reset();
      })
    }
  }

  resetForm() {
    this.publisherForm.reset();
    this.message = null;
    this.dataSaved = false;
  }
}
